using Hotel_Project.Areas.HT_Document.Models;
using Hotel_Project.Areas.HT_RoomType.Models;
using Hotel_Project.Areas.HT_RoomBooking.Models;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System.Data.Common;
using System.Data;

namespace Hotel_Project.DAL
{
    public class HT_DAL : HT_DAL_Base
    {
        #region Document_DROPDOWN

        public List<HT_Document_DropDownModel> HT_Document_SelectComboBox(string connectionString, int userID)
        {
            try
            {
                SqlDatabase database = new SqlDatabase(connectionString);

                DbCommand command = database.GetStoredProcCommand("[dbo].[PR_HT_Document_SelectComboBox]");

                database.AddInParameter(command, "@UserID", SqlDbType.Int, userID);

                DataTable dt = new DataTable();

                List<HT_Document_DropDownModel> document_list = new List<HT_Document_DropDownModel>();

                using (IDataReader dataReader = database.ExecuteReader(command))
                {
                    dt.Load(dataReader);

                    if (dt.Rows.Count > 0)
                    {
                        foreach (DataRow dr in dt.Rows)
                        {
                            HT_Document_DropDownModel tuple = new HT_Document_DropDownModel();
                            tuple.DocumentID = Convert.ToInt32(dr["DocumentID"]);
                            tuple.DocumentType = Convert.ToString(dr["DocumentType"]);
                            document_list.Add(tuple);
                        }
                    }
                }
                return document_list;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                return null;
            }
        }

        #endregion

        #region RoomType_DROPDOWN

        public List<HT_RoomType_DropDownModel> HT_RoomType_SelectComboBox(string connectionString, int userID)
        {
            try
            {
                SqlDatabase database = new SqlDatabase(connectionString);

                DbCommand command = database.GetStoredProcCommand("[dbo].[PR_HT_RoomType_SelectComboBox]");

                database.AddInParameter(command, "@UserID", SqlDbType.Int, userID);

                DataTable dt = new DataTable();

                List<HT_RoomType_DropDownModel> roomtype_list = new List<HT_RoomType_DropDownModel>();

                using (IDataReader dataReader = database.ExecuteReader(command))
                {
                    dt.Load(dataReader);

                    if (dt.Rows.Count > 0)
                    {
                        foreach (DataRow dr in dt.Rows)
                        {
                            HT_RoomType_DropDownModel tuple = new HT_RoomType_DropDownModel();
                            tuple.RoomTypeID = Convert.ToInt32(dr["RoomTypeID"]);
                            tuple.RoomTypeName = Convert.ToString(dr["RoomTypeName"]);
                            roomtype_list.Add(tuple);
                        }
                    }
                }
                return roomtype_list;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                return null;
            }
        }

        #endregion

    }
}
