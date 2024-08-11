using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Naqra___نقرة
{
    internal class DbConClass
    {
        public static SqlConnection conn = new SqlConnection();
       
        public static SqlConnection Con()
        {

            Properties.Settings set = new Properties.Settings();


            if (set.auth_type == 0)
            {
                // Connection  by Windows Authentication
               conn = new SqlConnection("Data Source = " + set.server_name + ";Initial Catalog=" + set.selected_db + " ; Integrated Security=True");
            }
            else if (set.auth_type == 2)
            {
                //Connection  by SQL Server Authentication
                conn = new SqlConnection("Data Source = " + set.server_name + ";Initial Catalog=" + set.selected_db + " ; User ID=" + set.user + ";Password=" + set.pass + "");
            }

            else if (set.auth_type == 1)
            {
                //Connection  by Network
                conn = new SqlConnection($"Data Source={set.server_name},{set.server_port};Network Library=DBMSSOCN;Initial Catalog={set.selected_db};User ID={set.user};Password={set.pass}");

            }

            return conn;

        }

        public static bool IsServerConnected()
        {
            try
            {
                Con();
                conn.Open();
                return true;
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message.ToString());
                return false;
            }
        }
    }
}
