using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Naqra___نقرة
{
    internal class GeneralClass
    {
        #region Public Variables
        public static Int16 user_id = 1;
        public static String user_name = "omar mohamed";
        public static Int16 branch_id = 1;
        public static String branch_name = "main branch";
        public static String pc_name = System.Environment.MachineName;



        #endregion

        #region fill data table
        public static void fillDataTable(DataTable dt,String sqlQuery)
        {
            SqlDataAdapter da;
            da = new SqlDataAdapter(sqlQuery, DbConClass.Con());
            dt.Clear();
            da.Fill(dt);
            da.Dispose();
        }

        #endregion

        #region get max id from table

        public static int getMaxIDFromTable(String tableName,String columnName)
        {
            DataTable dt = new DataTable();
            String sqlQuery;
            sqlQuery = ("SELECT MAX("+columnName+") FROM "+tableName+"");

            fillDataTable(dt,sqlQuery);
            if (Convert.IsDBNull(dt.Rows[0][0]) == true)
            {
                return 1;

            }
            else
            {
              return  Convert.ToInt32(dt.Rows[0][0]) + 1;
            }
            dt.Dispose();
        }

        #endregion

        #region get max id from table with condition
        public static int getMaxIDFromTableWithCondition(String tableName, String columnName,String condition,String Result)
        {
            DataTable dt = new DataTable();
            String sqlQuery;
            sqlQuery = ("SELECT MAX(" + columnName + ") FROM " + tableName + " WHERE "+condition+" = "+Result+" ");

            fillDataTable(dt, sqlQuery);
            if (Convert.IsDBNull(dt.Rows[0][0]) == true)
            {
                return 1;

            }
            else
            {
                return Convert.ToInt32(dt.Rows[0][0]) + 1;
            }
            dt.Dispose();
        }
        #endregion
    }
}
