using Hotel_Project.Areas.HT_RoomType.Models;
using Hotel_Project.BAL;
using Hotel_Project.DAL;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace Hotel_Project.Areas.HT_RoomType.Controllers
{
    [CheckAccess]
    [Area("HT_RoomType")]
    [Route("HT_RoomType/[controller]/[action]")]
    public class HT_RoomTypeController : Controller
    {
        #region PRIVATE_VAR

        private IConfiguration Configuration;
        private static string file_name = "";

        #endregion

        #region DAL_Object

        private HT_DAL dal = new HT_DAL();

        #endregion

        #region CONSTRUCTOR

        public HT_RoomTypeController(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        #endregion

        #region SELECT_ALL

        public IActionResult Index()
        {
            string connectionString = this.Configuration.GetConnectionString("Default");

            int userID = Convert.ToInt32(HttpContext.Session.GetString("UserID"));

            return View("../Home/Index", dal.HT_RoomType_SelectAll(connectionString, userID));
        }

        #endregion

        #region DELETE

        public IActionResult Delete(int RoomTypeID)
        {
            string connectionString = this.Configuration.GetConnectionString("Default");

            int userID = Convert.ToInt32(HttpContext.Session.GetString("UserID"));

            if (dal.HT_RoomType_DeleteByPK(connectionString, RoomTypeID, userID))
            {
                TempData["HT_RoomType_DeleteByPK_Msg"] = "RoomType Deleted Successfully.";
            }
            else
            {
                TempData["HT_RoomType_DeleteByPK_Msg"] = "Ooops !! Error in RoomType Deletion.";
            }
            return RedirectToAction("Index");
        }

        #endregion

        #region ADD

        public IActionResult Add(int? RoomTypeID)
        {
            string connectionString = this.Configuration.GetConnectionString("Default");

            int userID = Convert.ToInt32(HttpContext.Session.GetString("UserID"));

            ViewBag.UserID = userID;

            if (RoomTypeID != null)
            {
                HT_RoomTypeModel roomtypeModel = dal.HT_RoomType_SelectByPK(connectionString, (int)RoomTypeID, userID);

                //file_name = roomtypeModel.PhotoPath.ToString();

                return View("../Home/HT_RoomTypeAddEdit", roomtypeModel);

            }
            return View("../Home/HT_RoomTypeAddEdit");
        }

        #endregion

        #region SAVE

        public IActionResult Save(HT_RoomTypeModel roomtypeModel)
        {
            string connectionString = this.Configuration.GetConnectionString("Default");

            if (roomtypeModel.RoomTypeID == null)
            {
                if (dal.HT_RoomType_Insert(connectionString, roomtypeModel))
                {
                    TempData["HT_RoomType_Insert_Msg"] = "Room Type Inserted Successfully.";
                }
                else
                {
                    TempData["HT_RoomType_Insert_Msg"] = "Ooops !! Error in Room Type Insertion.";
                }
            }
            else
            {
                if (dal.HT_RoomType_UpdateByPK(connectionString, roomtypeModel))
                {
                    TempData["HT_RoomType_UpdateByPK_Msg"] = "Room Type Updated Successfully.";
                }
                else
                {
                    TempData["HT_RoomType_UpdateByPK_Msg"] = "Ooops !! Error in Room Type Updation.";
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

            HT_RoomType_SearchModel roomtype_SearchModel = new HT_RoomType_SearchModel();

            roomtype_SearchModel.RoomTypeName = HttpContext.Request.Form["RoomTypeName"].ToString();
            roomtype_SearchModel.Capacity = HttpContext.Request.Form["Capacity"].ToString();
            roomtype_SearchModel.RoomNumber = HttpContext.Request.Form["RoomNumber"].ToString();
            roomtype_SearchModel.Facilities = HttpContext.Request.Form["Facilities"].ToString();
            roomtype_SearchModel.Price = HttpContext.Request.Form["Price"].ToString();

            ViewBag.RoomTypeName = roomtype_SearchModel.RoomTypeName;
            ViewBag.Capacity = roomtype_SearchModel.Capacity;
            ViewBag.RoomNumber = roomtype_SearchModel.RoomNumber;
            ViewBag.Facilities = roomtype_SearchModel.Facilities;
            ViewBag.Price = roomtype_SearchModel.Price;
         

            int userID = Convert.ToInt32(HttpContext.Session.GetString("UserID"));

            return View("../Home/Index", dal.HT_RoomType_Search(connectionString, roomtype_SearchModel, userID));
        }

        #endregion

    }
}

