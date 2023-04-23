using Hotel_Project.Areas.RST_MenuType.Models;
using Hotel_Project.BAL;
using Hotel_Project.DAL;
using Microsoft.AspNetCore.Mvc;

namespace Hotel_Project.Areas.RST_MenuType.Controllers
{
    [CheckAccess]
    [Area("RST_MenuType")]
    [Route("RST_MenuType/[controller]/[action]")]
    public class RST_MenuTypeController : Controller
    {

        #region PRIVATE_VAR

        private IConfiguration Configuration;

        private RST_DAL dal = new RST_DAL();

        #endregion

        #region CONSTRUCTOR

        public RST_MenuTypeController(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        #endregion

        #region SELECT_ALL

        public IActionResult Index()
        {
            string connectionString = this.Configuration.GetConnectionString("Default");

            int userID = Convert.ToInt32(HttpContext.Session.GetString("UserID"));

            return View("../Home/Index", dal.RST_MenuType_SelectAll(connectionString, userID));
        }

        #endregion

        #region DELETE

        public IActionResult Delete(int MenuTypeID)
        {
            string connectionString = this.Configuration.GetConnectionString("Default");

            int userID = Convert.ToInt32(HttpContext.Session.GetString("UserID"));

            if (dal.RST_MenuType_DeleteByPK(connectionString, MenuTypeID, userID))
            {
                TempData["RST_MenuType_DeleteByPK_Msg"] = "MenuType Deleted Successfully.";
            }
            else
            {
                TempData["RST_MenuType_DeleteByPK_Msg"] = "Ooops !! Error in MenuType Deletion.";
            }
            return RedirectToAction("Index");
        }

        #endregion

        #region ADD

        public IActionResult Add(int? MenuTypeID)
        {
            string connectionString = this.Configuration.GetConnectionString("Default");

            int userID = Convert.ToInt32(HttpContext.Session.GetString("UserID"));
        
            ViewBag.UserID = userID;

            if (MenuTypeID != null)
            {
                RST_MenuTypeModel menutypeModel = dal.RST_MenuType_SelectByPK(connectionString, (int)MenuTypeID, userID);

                //file_name = menutypeModel.PhotoPath.ToString();

                return View("../Home/RST_MenuTypeAddEdit", menutypeModel );
            }
            return View("../Home/RST_MenuTypeAddEdit");
        }

        #endregion

        #region SAVE

        public IActionResult Save(RST_MenuTypeModel menutypeModel)
        {
            string connectionString = this.Configuration.GetConnectionString("Default");

            if (menutypeModel.MenuTypeID == null)
            {
                if (dal.RST_MenuType_Insert(connectionString, menutypeModel))
                {
                    TempData["RST_MenuType_Insert_Msg"] = "MenuType Inserted Successfully.";
                }
                else
                {
                    TempData["RST_MenuType_Insert_Msg"] = "Ooops !! Error in MenuType Insertion.";
                }
            }
            else
            {
                if (dal.RST_MenuType_UpdateByPK(connectionString, menutypeModel))
                {
                    TempData["RST_MenuType_UpdateByPK_Msg"] = "MenuType Updated Successfully.";
                }
                else
                {
                    TempData["RST_MenuType_Update_Msg"] = "Ooops !! Error in MenuType Updation.";
                }
                return RedirectToAction("Index");
            }
            return RedirectToAction("Add");
        }

        #endregion

        #region SEARCH_BOX

        public IActionResult Search()
        {
            string connectionString = this.Configuration.GetConnectionString("Default");

            RST_MenuType_SearchModel menutype_SearchModel = new RST_MenuType_SearchModel();

            menutype_SearchModel.MenuTypeName = HttpContext.Request.Form["MenuTypeName"].ToString();

            int userID = Convert.ToInt32(HttpContext.Session.GetString("UserID"));

            ViewBag.MenuTypeName = menutype_SearchModel.MenuTypeName;

            return View("../Home/Index", dal.RST_MenuType_Search(connectionString,  menutype_SearchModel, userID));
        }

        #endregion

    }
}
