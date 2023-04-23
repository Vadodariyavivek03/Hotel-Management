using Hotel_Project.Areas.HT_Document.Models;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System.Data.Common;
using System.Data;
using Hotel_Project.Areas.HT_RoomType.Models;
using Hotel_Project.Areas.HT_RoomBooking.Models;

namespace Hotel_Project.DAL
{
    public class HT_DAL_Base
    {
        #region HT_Document

        #region Select_All

        public DataTable? HT_Document_SelectAll(string connectionString, int userID)
        {
            try
            {
                SqlDatabase database = new SqlDatabase(connectionString);

                DbCommand command = database.GetStoredProcCommand("[dbo].[PR_HT_Document_SelectAll]");

                database.AddInParameter(command, "@UserID", SqlDbType.Int, userID);

                DataTable dt = new DataTable();

                using (IDataReader dr = database.ExecuteReader(command))
                {
                    dt.Load(dr);
                    return dt;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                return null;
            }
        }

        #endregion

        #region SELECT_By_PK

        public HT_DocumentModel HT_Document_SelectByPK(string connectionString, int DocumentID, int userID)
        {
            try
            {
                SqlDatabase database = new SqlDatabase(connectionString);
                DbCommand command = database.GetStoredProcCommand("[dbo].[PR_HT_Document_SelectByPK]");

                database.AddInParameter(command, "@DocumentID", DbType.Int32, DocumentID);
                database.AddInParameter(command, "@UserID", SqlDbType.Int, userID);

                DataTable dt = new DataTable();
                HT_DocumentModel documentModel = new HT_DocumentModel();

                using (IDataReader dataReader = database.ExecuteReader(command))
                {
                    dt.Load(dataReader);

                    if (dt.Rows.Count > 0)
                    {
                        foreach (DataRow row in dt.Rows)
                        {
                            documentModel.DocumentType = Convert.ToString(row["DocumentType"]);
                        }
                    }
                }
                return documentModel;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                return null;
            }
        }

        #endregion

        #region INSERT

        public bool HT_Document_Insert(string connectionString, HT_DocumentModel documentModel)
        {
            try
            {
                SqlDatabase database = new SqlDatabase(connectionString);
                DbCommand command = database.GetStoredProcCommand("[dbo].[PR_HT_Document_Insert]");

                database.AddInParameter(command, "@DocumentType", DbType.String, documentModel.DocumentType);
                database.AddInParameter(command, "@CreationDate", DbType.DateTime, DBNull.Value);
                database.AddInParameter(command, "@ModificationDate", DbType.DateTime, DBNull.Value);
                database.AddInParameter(command, "@UserID", SqlDbType.Int, documentModel.UserID);

                return Convert.ToBoolean(database.ExecuteNonQuery(command));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                return false;
            }
        }

        #endregion

        #region DELETE_By_PK

        public bool HT_Document_DeleteByPK(string connectionString, int DocumentID, int userID)
        {
            try
            {
                SqlDatabase database = new SqlDatabase(connectionString);

                DbCommand command = database.GetStoredProcCommand("[dbo].[PR_HT_Document_DeleteByPK]");

                database.AddInParameter(command, "@DocumentID", DbType.Int32, DocumentID);
                database.AddInParameter(command, "@UserID", SqlDbType.Int, userID);

                return Convert.ToBoolean(database.ExecuteNonQuery(command));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                return false;
            }
        }

        #endregion

        #region UPDATE_By_PK

        public bool HT_Document_UpdateByPK(string connectionString, HT_DocumentModel documentModel)
        {
            try
            {
                SqlDatabase database = new SqlDatabase(connectionString);

                DbCommand command = database.GetStoredProcCommand("[dbo].[PR_HT_Document_UpdateByPK]");

                database.AddInParameter(command, "@DocumentID", DbType.Int32, documentModel.DocumentID);
                database.AddInParameter(command, "@DocumentType", DbType.String, documentModel.DocumentType);
                database.AddInParameter(command, "@ModificationDate", DbType.DateTime, DBNull.Value);
                database.AddInParameter(command, "@UserID", SqlDbType.Int, documentModel.UserID);

                return Convert.ToBoolean(database.ExecuteNonQuery(command));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                return false;
            }
        }

        #endregion

        #region SEARCH

        public DataTable? HT_Document_Search(string connectionString, HT_Document_SearchModel document_SearchModel, int userID)
        {
            try
            {
                SqlDatabase database = new SqlDatabase(connectionString);

                DbCommand command = database.GetStoredProcCommand("[dbo].[PR_HT_Document_SelectPage]");

                database.AddInParameter(command, "@DocumentType", DbType.String, document_SearchModel.DocumentType);
                database.AddInParameter(command, "@UserID", SqlDbType.Int, userID);

                DataTable dt = new DataTable();

                using (IDataReader dataReader = database.ExecuteReader(command))
                {
                    dt.Load(dataReader);
                }
                return dt;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                return null;
            }
        }

        #endregion

        #endregion

        #region HT_RoomType

        #region Select_All

        public DataTable? HT_RoomType_SelectAll(string connectionString, int userID)
        {
            try
            {
                SqlDatabase database = new SqlDatabase(connectionString);

                DbCommand command = database.GetStoredProcCommand("[dbo].[PR_HT_RoomType_SelectAll]");

                database.AddInParameter(command, "@UserID", SqlDbType.Int, userID);

                DataTable dt = new DataTable();

                using (IDataReader dr = database.ExecuteReader(command))
                {
                    dt.Load(dr);
                    return dt;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                return null;
            }
        }

        #endregion

        #region SELECT_By_PK

        public HT_RoomTypeModel HT_RoomType_SelectByPK(string connectionString, int RoomTypeID, int userID)
        {
            try
            {
                SqlDatabase database = new SqlDatabase(connectionString);

                DbCommand command = database.GetStoredProcCommand("[dbo].[PR_HT_RoomType_SelectByPK]");

                database.AddInParameter(command, "@RoomTypeID", DbType.Int32, RoomTypeID);

                database.AddInParameter(command, "@UserID", SqlDbType.Int, userID);

                DataTable dt = new DataTable();

                HT_RoomTypeModel roomtypeModel = new HT_RoomTypeModel();

                using (IDataReader dataReader = database.ExecuteReader(command))
                {
                    dt.Load(dataReader);

                    if (dt.Rows.Count > 0)
                    {
                        foreach (DataRow row in dt.Rows)
                        {
                            roomtypeModel.RoomTypeName = Convert.ToString(row["RoomTypeName"]);
                        }
                    }
                }
                return roomtypeModel;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                return null;
            }
        }

        #endregion

        #region INSERT

        public bool HT_RoomType_Insert(string connectionString, HT_RoomTypeModel roomtypeModel)
        {
            try
            {
                SqlDatabase database = new SqlDatabase(connectionString);

                DbCommand command = database.GetStoredProcCommand("[dbo].[PR_HT_RoomType_Insert]");

                database.AddInParameter(command, "@RoomTypeName", DbType.String, roomtypeModel.RoomTypeName);
                database.AddInParameter(command, "@Capacity", DbType.String, roomtypeModel.Capacity);
                database.AddInParameter(command, "@RoomNumber", DbType.String, roomtypeModel.RoomNumber);
                database.AddInParameter(command, "@Facilities", DbType.String, roomtypeModel.Facilities);
                database.AddInParameter(command, "@Price", DbType.String, roomtypeModel.Price);
                database.AddInParameter(command, "@CreationDate", DbType.DateTime, DBNull.Value);
                database.AddInParameter(command, "@ModificationDate", DbType.DateTime, DBNull.Value);
                database.AddInParameter(command, "@UserID", SqlDbType.Int, roomtypeModel.UserID);

                return Convert.ToBoolean(database.ExecuteNonQuery(command));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                return false;
            }
        }

        #endregion

        #region DELETE_By_PK

        public bool HT_RoomType_DeleteByPK(string connectionString, int RoomTypeID, int userID)
        {
            try
            {
                SqlDatabase database = new SqlDatabase(connectionString);

                DbCommand command = database.GetStoredProcCommand("[dbo].[PR_HT_RoomType_DeleteByPK]");

                database.AddInParameter(command, "@RoomTypeID", DbType.Int32, RoomTypeID);
                database.AddInParameter(command, "@UserID", SqlDbType.Int, userID);

                return Convert.ToBoolean(database.ExecuteNonQuery(command));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                return false;
            }
        }

        #endregion

        #region UPDATE_By_PK

        public bool HT_RoomType_UpdateByPK(string connectionString, HT_RoomTypeModel roomtypeModel)
        {
            try
            {
                SqlDatabase database = new SqlDatabase(connectionString);

                DbCommand command = database.GetStoredProcCommand("[dbo].[PR_HT_RoomType_UpdateByPK]");

                database.AddInParameter(command, "@RoomTypeID", DbType.Int32, roomtypeModel.RoomTypeID);
                database.AddInParameter(command, "@RoomTypeName", DbType.String, roomtypeModel.RoomTypeName);
                database.AddInParameter(command, "@Capacity", DbType.String, roomtypeModel.Capacity);
                database.AddInParameter(command, "@RoomNumber", DbType.String, roomtypeModel.RoomNumber);
                database.AddInParameter(command, "@Facilities", DbType.String, roomtypeModel.Facilities);
                database.AddInParameter(command, "@Price", DbType.String, roomtypeModel.Price);
                database.AddInParameter(command, "@ModificationDate", DbType.DateTime, DBNull.Value);
                database.AddInParameter(command, "@UserID", SqlDbType.Int, roomtypeModel.UserID);

                return Convert.ToBoolean(database.ExecuteNonQuery(command));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                return false;
            }
        }

        #endregion

        #region SEARCH

        public DataTable? HT_RoomType_Search(string connectionString, HT_RoomType_SearchModel roomtype_SearchModel, int userID)
        {
            try
            {
                SqlDatabase database = new SqlDatabase(connectionString);

                DbCommand command = database.GetStoredProcCommand("[dbo].[PR_HT_RoomType_SelectPage]");

                database.AddInParameter(command, "@RoomTypeName", DbType.String, roomtype_SearchModel.RoomTypeName);
                database.AddInParameter(command, "@Capacity", DbType.String, roomtype_SearchModel.Capacity);
                database.AddInParameter(command, "@RoomNumber", DbType.String, roomtype_SearchModel.RoomNumber);
                database.AddInParameter(command, "@Facilities", DbType.String, roomtype_SearchModel.Facilities);
                database.AddInParameter(command, "@Price", DbType.String, roomtype_SearchModel.Price);
                database.AddInParameter(command, "@UserID", SqlDbType.Int, userID);

                DataTable dt = new DataTable();

                using (IDataReader dataReader = database.ExecuteReader(command))
                {
                    dt.Load(dataReader);
                }
                return dt;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                return null;
            }
        }

        #endregion

        #endregion

        #region HT_RoomBooking

        #region SELECT_ALL

        public DataTable? HT_RoomBooking_SelectAll(string connectionString, int userID)
        {
            try
            {
                SqlDatabase database = new SqlDatabase(connectionString);

                DbCommand command = database.GetStoredProcCommand("[dbo].[PR_HT_RoomBooking_SelectAll]");

                database.AddInParameter(command, "@UserID", SqlDbType.Int, userID);

                DataTable dt = new DataTable();
                using (IDataReader dr = database.ExecuteReader(command))
                {
                    dt.Load(dr);
                }
                return dt;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                return null;
            }
        }

        #endregion

        #region SELECT_BY_PK

        public HT_RoomBookingModel HT_RoomBooking_SelectByPK(string connectionString, int RoomBookingID, int userID)
        {
            try
            {
                SqlDatabase database = new SqlDatabase(connectionString);

                DbCommand command = database.GetStoredProcCommand("[dbo].[PR_HT_RoomBooking_SelectByPK]");

                database.AddInParameter(command, "@RoomBookingID", DbType.Int32, RoomBookingID);
                database.AddInParameter(command, "@UserID", SqlDbType.Int, userID);

                DataTable dt = new DataTable();

                HT_RoomBookingModel roombookingModel = new HT_RoomBookingModel();

                using (IDataReader dataReader = database.ExecuteReader(command))
                {
                    dt.Load(dataReader);

                    if (dt.Rows.Count > 0)
                    {
                        foreach (DataRow dr in dt.Rows)
                        {
                            roombookingModel.RoomBookingID = Convert.ToInt32(dr["RoomBookingID"]);
                            roombookingModel.FirstName = Convert.ToString(dr["FirstName"]);
                            roombookingModel.MiddleName = Convert.ToString(dr["MiddleName"]);
                            roombookingModel.LastName = Convert.ToString(dr["LastName"]);
                            roombookingModel.MobileNo = Convert.ToInt32(dr["MobileNo"]);
                            roombookingModel.Email = Convert.ToString(dr["Email"]);
                            roombookingModel.Country = Convert.ToString(dr["Country"]);
                            roombookingModel.State = Convert.ToString(dr["State"]);
                            roombookingModel.City = Convert.ToString(dr["City"]);
                            roombookingModel.DocumentNumber = Convert.ToInt32(dr["DocumentNumber"]);
                            roombookingModel.DocumentID = Convert.ToInt32(dr["DocumentID"]);
                            roombookingModel.RoomTypeID = Convert.ToInt32(dr["RoomTypeID"]);
                            roombookingModel.PhotoPath = Convert.ToString(dr["PhotoPath"]);
                        }
                    }
                }
                return roombookingModel;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                return null;
            }
        }

        #endregion

        #region DELETE_By_PK

        public bool HT_RoomBooking_DeleteByPK(string connectionString, int RoomBookingID, int userID)
        {
            try
            {
                SqlDatabase database = new SqlDatabase(connectionString);

                DbCommand command = database.GetStoredProcCommand("[dbo].[PR_HT_RoomBooking_DeleteByPK]");

                database.AddInParameter(command, "@RoomBookingID", DbType.Int32, RoomBookingID);
                database.AddInParameter(command, "@UserID", SqlDbType.Int, userID);

                #region DELETE_FILE_IN_DATABASE

                DbCommand command2 = database.GetStoredProcCommand("[dbo].[PR_HT_RoomBooking_SelectPhotoPathByPK]");

                database.AddInParameter(command2, "@RoomBookingID", DbType.Int32, RoomBookingID);
                database.AddInParameter(command2, "@UserID", SqlDbType.Int, userID);

                DataTable dt = new DataTable();

                string file_name, file_name_with_path;

                string full_path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\upload");

                using (IDataReader reader = database.ExecuteReader(command2))
                {
                    dt.Load(reader);
                    file_name = Convert.ToString(dt.Rows[0][1]);
                    file_name_with_path = Path.Combine(full_path, file_name);
                }

                //Delete File
                if (File.Exists(file_name_with_path))
                {
                    File.Delete(file_name_with_path);
                }

                #endregion

                return Convert.ToBoolean(database.ExecuteNonQuery(command));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                return false;
            }
        }

        #endregion

        #region INSERT

        public bool HT_RoomBooking_Insert(string connectionString, HT_RoomBookingModel roombookingModel)
        {
            try
            {
                SqlDatabase database = new SqlDatabase(connectionString);

                DbCommand command = database.GetStoredProcCommand("[dbo].[PR_HT_RoomBooking_Insert]");

                database.AddInParameter(command, "@FirstName", DbType.String, roombookingModel.FirstName);
                database.AddInParameter(command, "@MiddleName", DbType.String, roombookingModel.MiddleName);
                database.AddInParameter(command, "@LastName", DbType.String, roombookingModel.LastName);
                database.AddInParameter(command, "@MobileNo", DbType.String, roombookingModel.MobileNo);
                database.AddInParameter(command, "@Email", DbType.String, roombookingModel.Email);
                database.AddInParameter(command, "@Country", DbType.Int32, roombookingModel.Country);
                database.AddInParameter(command, "@State", DbType.Int32, roombookingModel.State);
                database.AddInParameter(command, "@City", DbType.Int32, roombookingModel.City);
                database.AddInParameter(command, "@DocumentNumber", DbType.Int32, roombookingModel.DocumentNumber);
                //database.AddInParameter(command, "@CreationDate", DbType.DateTime, DBNull.Value);
                //database.AddInParameter(command, "@ModificationDate", DbType.DateTime, DBNull.Value);
                database.AddInParameter(command, "@DocumentID", DbType.Int32, roombookingModel.DocumentID);
                database.AddInParameter(command, "@RoomTypeID", DbType.Int32, roombookingModel.RoomTypeID);
                database.AddInParameter(command, "@UserID", SqlDbType.Int, roombookingModel.UserID);

                #region FILE_UPLOAD

                if (roombookingModel.File != null)
                {
                    string file_loc = "wwwroot\\upload";
                    string full_path = Path.Combine(Directory.GetCurrentDirectory(), file_loc);

                    if (!Directory.Exists(full_path))
                    {
                        Directory.CreateDirectory(full_path);
                    }

                    string file_name_with_path = Path.Combine(full_path, roombookingModel.File.FileName);

                    //roombookingModel.PhotoPath = "~" + file_loc.Replace("wwwroot\\", "//") + roombookingModel.File.FileName;
                    roombookingModel.PhotoPath = roombookingModel.File.FileName;

                    database.AddInParameter(command, "@PhotoPath", DbType.String, roombookingModel.PhotoPath);

                    using (var stream = new FileStream(file_name_with_path, FileMode.Create))
                    {
                        roombookingModel.File.CopyTo(stream);
                    }
                }

                #endregion

                return Convert.ToBoolean(database.ExecuteNonQuery(command));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                return false;
            }
        }

        #endregion

        #region UPDATE_By_PK

        public bool HT_RoomBooking_UpdateByPK(string connectionString, HT_RoomBookingModel roombookingModel /*string delete_file_name*/)
        {
            try
            {
                SqlDatabase database = new SqlDatabase(connectionString);

                DbCommand command = database.GetStoredProcCommand("[dbo].[PR_HT_RoomBooking_UpdateByPK]");

                database.AddInParameter(command, "@RoomBookingID", DbType.Int32, roombookingModel.RoomBookingID);
                database.AddInParameter(command, "@FirstName", DbType.String, roombookingModel.FirstName);
                database.AddInParameter(command, "@MiddleName", DbType.String, roombookingModel.MiddleName);
                database.AddInParameter(command, "@LastName", DbType.String, roombookingModel.LastName);
                database.AddInParameter(command, "@MobileNo", DbType.String, roombookingModel.MobileNo);
                database.AddInParameter(command, "@Email", DbType.String, roombookingModel.Email);
                database.AddInParameter(command, "@Country", DbType.Int32, roombookingModel.Country);
                database.AddInParameter(command, "@State", DbType.Int32, roombookingModel.State);
                database.AddInParameter(command, "@City", DbType.Int32, roombookingModel.City);
                database.AddInParameter(command, "@DocumentNumber", DbType.String, roombookingModel.DocumentNumber);
                database.AddInParameter(command, "@DocumentID", DbType.Int32, roombookingModel.DocumentID);
                database.AddInParameter(command, "@RoomTypeID", DbType.Int32, roombookingModel.RoomTypeID);
                database.AddInParameter(command, "@ModificationDate", DbType.DateTime, DBNull.Value);
                database.AddInParameter(command, "@UserID", SqlDbType.Int, roombookingModel.UserID);

                #region FILE_UPLOAD

                if (roombookingModel.File != null)
                {
                    string file_loc = "wwwroot\\upload";
                    string full_path = Path.Combine(Directory.GetCurrentDirectory(), file_loc);

                    if (!Directory.Exists(full_path))
                    {
                        Directory.CreateDirectory(full_path);
                    }

                    string file_name_with_path = Path.Combine(full_path, roombookingModel.File.FileName);

                    string delete_old_file = Path.Combine(full_path, delete_file_name);
                    if (File.Exists(delete_old_file))
                    {
                        File.Delete(delete_old_file);
                    }

                    //roombookingModel.PhotoPath = "~" + file_loc.Replace("wwwroot\\", "//") + roombookingModel.File.FileName;
                    roombookingModel.PhotoPath = roombookingModel.File.FileName;
                    database.AddInParameter(command, "@PhotoPath", DbType.String, roombookingModel.PhotoPath);

                    using (var stream = new FileStream(file_name_with_path, FileMode.Create))
                    {
                        roombookingModel.File.CopyTo(stream);
                    }
                }

                #endregion

                return Convert.ToBoolean(database.ExecuteNonQuery(command));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }
        }

        #endregion

        #region SEARCH

        public DataTable? HT_RoomBooking_Search(string connectionString, HT_RoomBooking_SearchModel roombooking_SearchModel, int userID)
        {
            try
            {
                SqlDatabase database = new SqlDatabase(connectionString);
                DbCommand command = database.GetStoredProcCommand("[dbo].[PR_HT_RoomBooking_SelectPage]");

                database.AddInParameter(command, "@FirstName", DbType.String, roombooking_SearchModel.FirstName);
                database.AddInParameter(command, "@MiddleName", DbType.String, roombooking_SearchModel.MiddleName);
                database.AddInParameter(command, "@LastName", DbType.String, roombooking_SearchModel.LastName);
                database.AddInParameter(command, "@MobileNo", DbType.String, roombooking_SearchModel.MobileNo);
                database.AddInParameter(command, "@Email", DbType.String, roombooking_SearchModel.Email);
                database.AddInParameter(command, "@Country", DbType.Int32, roombooking_SearchModel.Country);
                database.AddInParameter(command, "@State", DbType.Int32, roombooking_SearchModel.State);
                database.AddInParameter(command, "@City", DbType.Int32, roombooking_SearchModel.City);
                database.AddInParameter(command, "@DocumentNumber", DbType.String, roombooking_SearchModel.DocumentNumber);
                database.AddInParameter(command, "@DocumentType", DbType.Int32, roombooking_SearchModel.DocumentType);
                database.AddInParameter(command, "@RoomTypeName", DbType.Int32, roombooking_SearchModel.RoomTypeName);
                database.AddInParameter(command, "@UserID", SqlDbType.Int, userID);

                DataTable dt = new DataTable();

                using (IDataReader dataReader = database.ExecuteReader(command))
                {
                    dt.Load(dataReader);
                }
                return dt;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                return null;
            }
        }

        #endregion

        #endregion
    }
}
