using Hotel_Project.Areas.HT_RoomBooking.Models;
using Hotel_Project.Areas.HT_Document.Models;
using Hotel_Project.Areas.HT_RoomType.Models;
using Hotel_Project.BAL;
using Hotel_Project.DAL;
using Microsoft.AspNetCore.Mvc;

namespace Hotel_Project.Areas.HT_RoomBooking.Controllers
{
    [CheckAccess]
    [Area("HT_RoomBooking")]
    [Route("HT_RoomBooking/[controller]/[action]")]
    public class HT_RoomBookingController : Controller
    {

        #region PRIVATE_VAR

        private IConfiguration configuration;

        #endregion

        #region CONSTRUCTOR

        public HT_RoomBookingController(IConfiguration _configuration)
        {
            this.configuration = _configuration;
        }

        #endregion

        #region DAL Object

        private HT_DAL dal = new HT_DAL();

        #endregion

        #region SELECT_ALL

        public IActionResult Index()
        {
            string connectionString = this.configuration.GetConnectionString("Default");

            int userID = Convert.ToInt32(HttpContext.Session.GetString("UserID"));
            
            return View("../Home/Index", dal.HT_RoomBooking_SelectAll(connectionString, userID));
        }

        #endregion

        #region DELETE

        public IActionResult Delete(int RoomBookingID)
        {
            string connectionString = this.configuration.GetConnectionString("Default");

            int userID = Convert.ToInt32(HttpContext.Session.GetString("UserID"));

            if (dal.HT_RoomBooking_DeleteByPK(connectionString, RoomBookingID, userID))
            {
                TempData["HT_RoomBooking_DeleteByPK_Msg"] = "Booking Room Deleted Successfully.";
            }
            else
            {
                TempData["HT_RoomBooking_DeleteByPK_Msg"] = "Ooops !! Error in Booking Room Deletion.";
            }
            return RedirectToAction("Index");
        }

        #endregion

        #region ADD

        public IActionResult Add(int? RoomBookingID)
        {
            string connectionString = this.configuration.GetConnectionString("Default");

            int userID = Convert.ToInt32(HttpContext.Session.GetString("UserID"));

            ViewBag.UserID = userID;

            ViewBag.DocumentList = dal.HT_Document_SelectComboBox(connectionString, userID);

            ViewBag.RoomTypeList = dal.HT_RoomType_SelectComboBox(connectionString, userID);

            if (RoomBookingID != null)
            {
                HT_RoomBookingModel roombookingModel = dal.HT_RoomBooking_SelectByPK(connectionString, (int)RoomBookingID, userID);

              string  file_name = roombookingModel.PhotoPath.ToString();

                return View("../Home/HT_RoomBookingAddEdit", roombookingModel);
            }
            return View("../Home/HT_RoomBookingAddEdit");
        }

        #endregion

        #region SAVE

        public IActionResult Save(HT_RoomBookingModel roombookingModel)
        {
            string connectionString = this.configuration.GetConnectionString("Default");

            if (roombookingModel.RoomBookingID == null)
            {
                if (dal.HT_RoomBooking_Insert(connectionString, roombookingModel))
                {
                    TempData["HT_RoomBooking_Insert_Msg"] = "Booking Room Inserted Successfully.";
                }
                else
                {
                    TempData["HT_RoomBooking_Insert_Msg"] = "Ooops !! Error in Room Booking Insertion.";
                }
            }
            else
            {
                if (dal.HT_RoomBooking_UpdateByPK(connectionString, roombookingModel))
                {
                    TempData["HT_RoomBooking_UpdateByPK_Msg"] = "Booking Room Updated Successfully.";
                }
                else
                {
                    TempData["HT_RoomBooking_UpdateByPK_Msg"] = "Ooops !! Error in Room Booking Updation.";
                }
                return RedirectToAction("Index");
            }
            return RedirectToAction("Add");
        }

        #endregion

        #region SEARCH_BOX

        public IActionResult Search()
        {
            string connectionString = this.configuration.GetConnectionString("Default");

            HT_RoomBooking_SearchModel roombooking_SearchModel = new HT_RoomBooking_SearchModel();

            roombooking_SearchModel.DocumentType = HttpContext.Request.Form["DocumentType"].ToString();
            roombooking_SearchModel.RoomTypeName = HttpContext.Request.Form["RoomTypeName"].ToString();
            roombooking_SearchModel.FirstName = HttpContext.Request.Form["FirstName"].ToString();
            roombooking_SearchModel.MiddleName = HttpContext.Request.Form["MiddleName"].ToString();
            roombooking_SearchModel.LastName = HttpContext.Request.Form["LastName"].ToString();
            roombooking_SearchModel.MobileNo = HttpContext.Request.Form["MobileNo"].ToString();
            roombooking_SearchModel.Email = HttpContext.Request.Form["Email"].ToString();
            roombooking_SearchModel.City = HttpContext.Request.Form["City"].ToString();
            roombooking_SearchModel.State = HttpContext.Request.Form["State"].ToString();
            roombooking_SearchModel.Country = HttpContext.Request.Form["Country"].ToString();
            roombooking_SearchModel.DocumentNumber = HttpContext.Request.Form["DocumentNumber"].ToString();

            ViewBag.DocumentType = roombooking_SearchModel.DocumentType;
            ViewBag.RoomTypeName = roombooking_SearchModel.RoomTypeName;
            ViewBag.FirstName = roombooking_SearchModel.FirstName;
            ViewBag.MiddleName = roombooking_SearchModel.MiddleName;
            ViewBag.LastName = roombooking_SearchModel.LastName;
            ViewBag.MobileNo = roombooking_SearchModel.MobileNo;
            ViewBag.Email = roombooking_SearchModel.Email;
            ViewBag.City = roombooking_SearchModel.City;
            ViewBag.State = roombooking_SearchModel.State;
            ViewBag.Country = roombooking_SearchModel.Country;
            ViewBag.DocumentNumber = roombooking_SearchModel.DocumentNumber;

            int userID = Convert.ToInt32(HttpContext.Session.GetString("UserID"));

            return View("../Home/Index", dal.HT_RoomBooking_Search(connectionString, roombooking_SearchModel, userID));
        }

        #endregion

    }
}
