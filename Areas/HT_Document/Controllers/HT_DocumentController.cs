using Hotel_Project.Areas.HT_Document.Models;
using Hotel_Project.BAL;
using Hotel_Project.DAL;
using Microsoft.AspNetCore.Mvc;

namespace Hotel_Project.Areas.HT_Document.Controllers
{
    [CheckAccess]
    [Area("HT_Document")]
    [Route("HT_Document/[controller]/[action]")]
    public class HT_DocumentController : Controller
    {
        #region PRIVATE_VAR

        private IConfiguration Configuration;
        private HT_DAL dal = new HT_DAL();

        #endregion

        #region CONSTRUCTOR

        public HT_DocumentController(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        #endregion

        #region SELECT_ALL

        public IActionResult Index()
        {
            string connectionString = this.Configuration.GetConnectionString("Default");

            int userID = Convert.ToInt32(HttpContext.Session.GetString("UserID"));

            return View("../Home/Index", dal.HT_Document_SelectAll(connectionString, userID));
        }

        #endregion

        #region DELETE_BY_PK

        public IActionResult Delete(int DocumentID)
        {
            string connectionString = this.Configuration.GetConnectionString("Default");
            int userID = Convert.ToInt32(HttpContext.Session.GetString("UserID"));

            if (dal.HT_Document_DeleteByPK(connectionString, DocumentID, userID))
            {
                TempData["HT_Document_DeleteByPK_Msg"] = "Document Deleted Successfully.";
            }
            else
            {
                TempData["HT_Document_DeleteByPK_Msg"] = "Ooops !!Error in Document Deletion.";
            }

            return RedirectToAction("Index");
        }

        #endregion

        #region ADD

        public IActionResult Add(int? DocumentID)
        {
            string connectionString = this.Configuration.GetConnectionString("Default");

            //file_name = documentModel.PhotoPath.ToString();

            int userID = Convert.ToInt32(HttpContext.Session.GetString("UserID"));

            ViewBag.UserID = userID;

            if (DocumentID != null)
            {
                return View("../Home/HT_DocumentAddEdit", dal.HT_Document_SelectByPK(connectionString, (int)DocumentID, userID));
            }
            return View("../Home/HT_DocumentAddEdit");
        }

        #endregion

        #region SAVE

        public IActionResult Save(HT_DocumentModel documentModel)
        {
            string connectionString = this.Configuration.GetConnectionString("Default");

            if (documentModel.DocumentID == null)
            {
                if (dal.HT_Document_Insert(connectionString, documentModel))
                {
                    TempData["HT_Document_Insert_Msg"] = "Document inserted Successfully.";
                }
                else
                {
                    TempData["HT_Document_Insert_Msg"] = "Ooops !! Error in Document Insertion.";
                }
            }
            else
            {
                if (dal.HT_Document_UpdateByPK(connectionString, documentModel))
                {
                    TempData["HT_Document_UpdateByPK_Msg"] = "Document Updated Successfully.";
                }
                else
                {
                    TempData["HT_Document_UpdateByPK_Msg"] = "Ooops !! Error in Document Updation.";
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

            HT_Document_SearchModel document_SearchModel = new HT_Document_SearchModel();

            document_SearchModel.DocumentType = HttpContext.Request.Form["DocumentType"].ToString();

            ViewBag.document = document_SearchModel.DocumentType;

            int userID = Convert.ToInt32(HttpContext.Session.GetString("UserID"));

            return View("../Home/Index", dal.HT_Document_Search(connectionString, document_SearchModel, userID));
        }

        #endregion
    }
}

