using Hotel_Project.Areas.RST_Menu.Models;
using Hotel_Project.Areas.RST_MenuType.Models;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System.Data;
using System.Data.Common;

namespace Hotel_Project.DAL
{
    public class RST_DAL : RST_DAL_Base
    {
        #region MenuType_DROPDOWN

        public List<RST_MenuType_DropDownModel> RST_MenuType_SelectComboBox(string connectionString, int userID)
        {
            try
            {
                SqlDatabase database = new SqlDatabase(connectionString);

                DbCommand command = database.GetStoredProcCommand("[dbo].[PR_RST_MenuType_SelectComboBox]");

                database.AddInParameter(command, "@UserID", SqlDbType.Int, userID);

                DataTable dt = new DataTable();

                List<RST_MenuType_DropDownModel> menutype_list = new List<RST_MenuType_DropDownModel>();

                using (IDataReader dataReader = database.ExecuteReader(command))
                {
                    dt.Load(dataReader);

                    if (dt.Rows.Count > 0)
                    {
                        foreach (DataRow dr in dt.Rows)
                        {
                            RST_MenuType_DropDownModel tuple = new RST_MenuType_DropDownModel();
                            tuple.MenuTypeID = Convert.ToInt32(dr["MenuTypeID"]);
                            tuple.MenuTypeName = Convert.ToString(dr["MenuTypeName"]);
                            menutype_list.Add(tuple);
                        }
                    }
                }
                return menutype_list;
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
