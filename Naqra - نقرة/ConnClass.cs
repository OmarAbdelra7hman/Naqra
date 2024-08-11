using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Naqra___نقرة
{
    internal class ConnClass
    {
        public static SqlConnection Con()
        {
            SqlConnection conn = new SqlConnection();
            Properties.Settings set = new Properties.Settings();

            if (set.LoginMothed == 0)
            {
                // Connection  by Windows Authentication
                conn = new SqlConnection("Data Source = " + set.ServerName + ";Initial Catalog=" + set.DataBaseName + " ; Integrated Security=True");
            }
            else if (set.LoginMothed == 1)
            {
                //Connection  by SQL Server Authentication
                conn = new SqlConnection("Data Source = " + set.ServerName + ";Initial Catalog=" + set.DataBaseName + " ; User ID=" + set.UserID + ";Password=" + set.UserPassword + "");
            }

            else if (set.LoginMothed == 2)
            {
                //Connection  by Network
                conn = new SqlConnection("Data Source = " + set.ServerIP + "," + set.LoginPort + ";Network Library=DBMSSOCN;Initial Catalog=" + set.DataBaseName + " User ID=" + set.UserID + ";Password=" + set.UserPassword + "");
            }

            return conn;

        }

    }
}
