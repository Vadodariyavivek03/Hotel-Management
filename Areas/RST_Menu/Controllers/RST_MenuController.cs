using Hotel_Project.Areas.RST_MenuType.Models;
using Hotel_Project.Areas.RST_Menu.Models;
using Hotel_Project.BAL;
using Hotel_Project.DAL;
using Microsoft.AspNetCore.Mvc;

namespace Hotel_Project.Areas.RST_Menu.Controllers
{
    [CheckAccess]
    [Area("RST_Menu")]
    [Route("RST_Menu/[controller]/[action]")]
    public class RST_MenuController : Controller
    {
        #region PRIVATE_VAR

        private IConfiguration Configuration;

        public RST_DAL dal = new RST_DAL();
        #endregion

        #region CONSTRUCTOR

        public RST_MenuController(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        #endregion

        #region SELECT_ALL

        public IActionResult Index()
        {
            string connectionString = this.Configuration.GetConnectionString("Default");

            int userID = Convert.ToInt32(HttpContext.Session.GetString("UserID"));

            return View("../Home/Index", dal.RST_Menu_SelectAll(connectionString, userID));
        }

        #endregion

        #region DELETE_BY_PK

        public IActionResult Delete(int MenuItemID)
        {
            string connectionString = this.Configuration.GetConnectionString("Default");

            int userID = Convert.ToInt32(HttpContext.Session.GetString("UserID"));

            if (dal.RST_Menu_DeleteByPK(connectionString, MenuItemID, userID))
            {
                TempData["RST_Menu_DeleteByPK_Msg"] = "Menu Deleted Successfully.";
            }
            else
            {
                TempData["RST_Menu_DeleteByPK_Msg"] = "Ooops !! Error in Menu Deletion.";
            }

            return RedirectToAction("Index");
        }

        #endregion

        #region ADD

        public IActionResult Add(int? MenuItemID)
        {
            string connectionString = this.Configuration.GetConnectionString("Default");

            int userID = Convert.ToInt32(HttpContext.Session.GetString("UserID"));

            ViewBag.UserID = userID;

            ViewBag.MenuTypeList = dal.RST_MenuType_SelectComboBox(connectionString, userID);


            if (MenuItemID != null)
            {
                RST_MenuModel menumodel = dal.RST_Menu_SelectByPK(connectionString, (int)MenuItemID, userID);

                string file_name = menumodel.PhotoPath.ToString();

                return View("../Home/RST_MenuAddEdit", menumodel);
            }
            return View("../Home/RST_MenuAddEdit");
        }

        #endregion

        #region SAVE

        public IActionResult Save(RST_MenuModel menuModel)
        {

            string connectionString = this.Configuration.GetConnectionString("Default");

            if (menuModel.MenuItemID == null)
            {
                if (dal.RST_Menu_Insert(connectionString, menuModel))
                {
                    TempData["RST_Menu_Insert_Msg"] = "Menu Inserted Successfully.";
                }
                else
                {
                    TempData["RST_Menu_Insert_Msg"] = "Ooops !! Error in Menu Insertion.";
                }
            }
            else
            {
                if (dal.RST_Menu_UpdateByPK(connectionString, menuModel))
                {
                    TempData["RST_Menu_UpdateByPK_Msg"] = "Menu Updated Successfully.";
                }
                else
                {
                    TempData["RST_Menu_UpdateByPK_Msg"] = "Ooops !! Error in Menu Updation.";
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

            RST_Menu_SearchModel menu_SearchModel = new RST_Menu_SearchModel();

            menu_SearchModel.MenuName = HttpContext.Request.Form["MenuName"].ToString();
            //menu_SearchModel.Description = HttpContext.Request.Form["Description"].ToString();
            menu_SearchModel.Price = HttpContext.Request.Form["Price"].ToString();

            int userID = Convert.ToInt32(HttpContext.Session.GetString("UserID"));

            ViewBag.MenuName = menu_SearchModel.MenuName;
            ViewBag.Price = menu_SearchModel.Price;

            return View("../Home/Index", dal.RST_Menu_Search(connectionString, menu_SearchModel, userID));
        }

        #endregion

    }
}
