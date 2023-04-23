using Hotel_Project.Areas.RST_MenuType.Models;
using Hotel_Project.Areas.RST_Menu.Models;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;

namespace Hotel_Project.DAL
{
    public class RST_DAL_Base
    {
        #region RST_MenuType

        #region Select_All

        public DataTable? RST_MenuType_SelectAll(string connectionString, int userID)
        {
            try
            {
                SqlDatabase database = new SqlDatabase(connectionString);

                DbCommand command = database.GetStoredProcCommand("[dbo].[PR_RST_MenuType_SelectAll]");

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

        public RST_MenuTypeModel RST_MenuType_SelectByPK(string connectionString, int MenuTypeID, int userID)
        {
            try
            {
                SqlDatabase database = new SqlDatabase(connectionString);

                DbCommand command = database.GetStoredProcCommand("[dbo].[PR_RST_MenuType_SelectByPK]");

                database.AddInParameter(command, "@MenuTypeID", DbType.Int32, MenuTypeID);

                database.AddInParameter(command, "@UserID", SqlDbType.Int, userID);

                DataTable dt = new DataTable();

                RST_MenuTypeModel menutypeModel = new RST_MenuTypeModel();

                using (IDataReader dataReader = database.ExecuteReader(command))
                {
                    dt.Load(dataReader);

                    if (dt.Rows.Count > 0)
                    {
                        foreach (DataRow row in dt.Rows)
                        {
                            menutypeModel.MenuTypeName = Convert.ToString(row["RoomTypeName"]);
                        }
                    }
                }
                return menutypeModel;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                return null;
            }
        }

        #endregion

        #region INSERT

        public bool RST_MenuType_Insert(string connectionString, RST_MenuTypeModel roomtypeModel)
        {
            try
            {
                SqlDatabase database = new SqlDatabase(connectionString);

                DbCommand command = database.GetStoredProcCommand("[dbo].[PR_RST_MenuType_Insert]");

                database.AddInParameter(command, "@RoomTypeName", DbType.String, roomtypeModel.MenuTypeName);
              
                //database.AddInParameter(command, "@CreationDate", DbType.DateTime, DBNull.Value);
                //database.AddInParameter(command, "@ModificationDate", DbType.DateTime, DBNull.Value);

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

        public bool RST_MenuType_DeleteByPK(string connectionString, int MenuTypeID, int userID)
        {
            try
            {
                SqlDatabase database = new SqlDatabase(connectionString);

                DbCommand command = database.GetStoredProcCommand("[dbo].[PR_RST_MenuType_DeleteByPK]");

                database.AddInParameter(command, "@MenuTypeID", DbType.Int32, MenuTypeID);
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

        public bool RST_MenuType_UpdateByPK(string connectionString, RST_MenuTypeModel roomtypeModel)
        {
            try
            {
                SqlDatabase database = new SqlDatabase(connectionString);

                DbCommand command = database.GetStoredProcCommand("[dbo].[PR_RST_MenuType_UpdateByPK]");

                database.AddInParameter(command, "@MenuTypeID", DbType.Int32, roomtypeModel.MenuTypeID);
                database.AddInParameter(command, "@MenuTypeName", DbType.String, roomtypeModel.MenuTypeName);
               
                //database.AddInParameter(command, "@ModificationDate", DbType.DateTime, DBNull.Value);

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

        public DataTable? RST_MenuType_Search(string connectionString, RST_MenuType_SearchModel menutype_SearchModel, int userID)
        {
            try
            {
                SqlDatabase database = new SqlDatabase(connectionString);

                DbCommand command = database.GetStoredProcCommand("[dbo].[PR_RST_MenuType_SelectPage]");

                database.AddInParameter(command, "@MenuTypeName", DbType.String, menutype_SearchModel.MenuTypeName);
               
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

        #region RST_Menu

        #region SELECT_ALL

        public DataTable? RST_Menu_SelectAll(string connectionString, int userID)
        {
            try
            {
                SqlDatabase database = new SqlDatabase(connectionString);

                DbCommand command = database.GetStoredProcCommand("[dbo].[PR_RST_Menu_SelectAll]");

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

        public RST_MenuModel RST_Menu_SelectByPK(string connectionString, int MenuItemID, int userID)
        {
            try
            {
                SqlDatabase database = new SqlDatabase(connectionString);

                DbCommand command = database.GetStoredProcCommand("[dbo].[PR_RST_Menu_SelectByPK]");

                database.AddInParameter(command, "@MenuItemID", DbType.Int32, MenuItemID);

                database.AddInParameter(command, "@UserID", SqlDbType.Int, userID);

                DataTable dt = new DataTable();

                RST_MenuModel menuModel = new RST_MenuModel();

                using (IDataReader dataReader = database.ExecuteReader(command))
                {
                    dt.Load(dataReader);

                    if (dt.Rows.Count > 0)
                    {
                        foreach (DataRow dr in dt.Rows)
                        {
                            menuModel.MenuItemID = Convert.ToInt32(dr["MenuItemID"]);
                            menuModel.MenuName = Convert.ToString(dr["MenuName"]);
                            menuModel.Description = Convert.ToString(dr["Description"]);
                            menuModel.Price = Convert.ToInt32(dr["Price"]);
                            menuModel.PhotoPath = Convert.ToString(dr["PhotoPath"]);
                            menuModel.MenuTypeID = Convert.ToInt32(dr["MenuTypeID"]);
                           
                        }
                    }
                }
                return menuModel;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                return null;
            }
        }

        #endregion

        #region DELETE_By_PK

        public bool RST_Menu_DeleteByPK(string connectionString, int MenuItemID, int userID)
        {
            try
            {
                SqlDatabase database = new SqlDatabase(connectionString);

                DbCommand command = database.GetStoredProcCommand("[dbo].[PR_RST_Menu_DeleteByPK]");

                database.AddInParameter(command, "@MenuItemID", DbType.Int32, MenuItemID);

                database.AddInParameter(command, "@UserID", SqlDbType.Int, userID);
                 
                #region DELETE_FILE_IN_DATABASE

                DbCommand command2 = database.GetStoredProcCommand("[dbo].[PR_RST_Menu_SelectPhotoPathByPK]");

                database.AddInParameter(command2, "@MenuItemID", DbType.Int32, MenuItemID);
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

        public bool RST_Menu_Insert(string connectionString, RST_MenuModel menuModel)
        {
            try
            {
                SqlDatabase database = new SqlDatabase(connectionString);

                DbCommand command = database.GetStoredProcCommand("[dbo].[PR_RST_Menu_Insert]");

                database.AddInParameter(command, "@MenuName", DbType.String, menuModel.MenuName);             
                database.AddInParameter(command, "@Description", DbType.String, menuModel.Description);
                database.AddInParameter(command, "@Price", DbType.Int32, menuModel.Price);
                database.AddInParameter(command, "@PhotoPath", DbType.String, menuModel.PhotoPath);
                //database.AddInParameter(command, "@CreationDate", DbType.DateTime, DBNull.Value);
                //database.AddInParameter(command, "@ModificationDate", DbType.DateTime, DBNull.Value);
                database.AddInParameter(command, "@MenuTypeID", DbType.Int32, menuModel.MenuTypeID);
                database.AddInParameter(command, "@UserID", SqlDbType.Int, menuModel.UserID);

                #region FILE_UPLOAD

                if (menuModel.File != null)
                {
                    string file_loc = "wwwroot\\upload";
                    string full_path = Path.Combine(Directory.GetCurrentDirectory(), file_loc);

                    if (!Directory.Exists(full_path))
                    {
                        Directory.CreateDirectory(full_path);
                    }

                    string file_name_with_path = Path.Combine(full_path, menuModel.File.FileName);

                    //roombookingModel.PhotoPath = "~" + file_loc.Replace("wwwroot\\", "//") + roombookingModel.File.FileName;
                    menuModel.PhotoPath = menuModel.File.FileName;

                    database.AddInParameter(command, "@PhotoPath", DbType.String, menuModel.PhotoPath);

                    using (var stream = new FileStream(file_name_with_path, FileMode.Create))
                    {
                        menuModel.File.CopyTo(stream);
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

        public bool RST_Menu_UpdateByPK(string connectionString,RST_MenuModel menuModel/*, string delete_file_name*/)
        {
            try
            {
                SqlDatabase database = new SqlDatabase(connectionString);

                DbCommand command = database.GetStoredProcCommand("[dbo].[PR_RST_Menu_UpdateByPK]");

                database.AddInParameter(command, "@MenuItemID", DbType.Int32, menuModel.MenuItemID);
                database.AddInParameter(command, "@MenuName", DbType.String, menuModel.MenuName);
                database.AddInParameter(command, "@Description", DbType.String, menuModel.Description);
                database.AddInParameter(command, "@Price", DbType.Int32, menuModel.Price);
                database.AddInParameter(command, "@MenuTypeID", DbType.String, menuModel.MenuTypeID);
                //database.AddInParameter(command, "@ModificationDate", DbType.DateTime, DBNull.Value);
                database.AddInParameter(command, "@UserID", SqlDbType.Int, menuModel.UserID);

                #region FILE_UPLOAD

                if (menuModel.File != null)
                {
                    string file_loc = "wwwroot\\upload";
                    string full_path = Path.Combine(Directory.GetCurrentDirectory(), file_loc);

                    if (!Directory.Exists(full_path))
                    {
                        Directory.CreateDirectory(full_path);
                    }

                    string file_name_with_path = Path.Combine(full_path, menuModel.File.FileName);

                    string delete_old_file = Path.Combine(full_path, delete_file_name);
                    if (File.Exists(delete_old_file))
                    {
                        File.Delete(delete_old_file);
                    }

                    //roombookingModel.PhotoPath = "~" + file_loc.Replace("wwwroot\\", "//") + roombookingModel.File.FileName;
                    menuModel.PhotoPath = menuModel.File.FileName;
                    database.AddInParameter(command, "@PhotoPath", DbType.String, menuModel.PhotoPath);

                    using (var stream = new FileStream(file_name_with_path, FileMode.Create))
                    {
                        menuModel.File.CopyTo(stream);
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

        public DataTable? RST_Menu_Search(string connectionString,RST_Menu_SearchModel menu_SearchModel, int userID)
        {
            try
            {
                SqlDatabase database = new SqlDatabase(connectionString);
                DbCommand command = database.GetStoredProcCommand("[dbo].[PR_RST_Menu_SelectPage]");

                database.AddInParameter(command, "@MenuName", DbType.String, menu_SearchModel.MenuName);
                database.AddInParameter(command, "@Description", DbType.String, menu_SearchModel.Description);
                database.AddInParameter(command, "@Price", DbType.Int32, menu_SearchModel.Price);
                database.AddInParameter(command, "@PhotoPath", DbType.String, menu_SearchModel.PhotoPath);               
                database.AddInParameter(command, "@MenuTypeName", DbType.Int32, menu_SearchModel.MenuTypeName);
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