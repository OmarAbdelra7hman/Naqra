using DevExpress.XtraCharts.Native;
using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Naqra___نقرة
{
    public partial class frm_connection : DevExpress.XtraEditors.XtraForm
    {
        public frm_connection()
        {
            InitializeComponent();
            getConnData();
            selected_db_DropDown();
        }

        private  void getConnData()
        {
            int auth_type = Properties.Settings.Default.auth_type;
            if (auth_type == 0)
            {
                radio_local.Checked = true;
                radio_wide.Checked = false;
                pc_name.Text = Properties.Settings.Default.server_name;

            }
            else if (auth_type == 1) 
            { 
                radio_local.Checked = false;
                radio_wide.Checked = true;
                server_ip.Text = Properties.Settings.Default.server_name;
                user.Text = Properties.Settings.Default.user;
                pass.Text = Properties.Settings.Default.pass;
                server_port.Text = Properties.Settings.Default.server_port;
                
            }
        }

        private void radio_local_CheckedChanged_1(object sender, EventArgs e)
        {
            grp_wide.Enabled = false;
            grp_local.Enabled = true;
        
        }

        private void radio_wide_CheckedChanged_1(object sender, EventArgs e)
        {
            grp_local.Enabled = false;
            grp_wide.Enabled = true;
          
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
       
            if (DbConClass.IsServerConnected()) {
                MessageBox.Show("تم الاتصال بنجاح");
            }
            else
            {
                MessageBox.Show("خطأ في الاتصال");
            }
        }

        private void selected_db_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void selected_db_DropDown()
        {
            // Check if the server is connected
            if (DbConClass.IsServerConnected())
            {
                try
                {
                    // Define the SQL query to get the list of user databases excluding system databases
                    string query = "SELECT name FROM sys.databases WHERE name NOT IN ('master', 'model', 'msdb', 'tempdb')";

                    // Initialize SqlDataAdapter and DataTable
                    SqlDataAdapter da = new SqlDataAdapter(query, DbConClass.conn);
                    DataTable dt = new DataTable();

                    // Fill the DataTable with the results of the query
                    da.Fill(dt);

                    // Clear existing items
                    selected_db.Properties.Items.Clear();

                    // Add each database name to the items list
                    foreach (DataRow row in dt.Rows)
                    {
                        string dbName = row["name"].ToString();
                        selected_db.Properties.Items.Add(dbName);
                    }
                }
                catch (Exception ex)
                {
                    // Handle exceptions
                    MessageBox.Show("An error occurred: " + ex.Message);
                }
            }
            else
            {
                // Handle the case when the server is not connected
                MessageBox.Show("Server is not connected.");
            }
            
        }

        private void setData()
        {
            Properties.Settings.Default.server_name = server_ip.Text;
           Properties.Settings.Default.user = user.Text;
           Properties.Settings.Default.pass = pass.Text;
           Properties.Settings.Default.server_port = server_port.Text;
            if (radio_wide.Checked)
            {
                Properties.Settings.Default.auth_type = 1;
            }
            else
            {
                Properties.Settings.Default.auth_type = 0;
            }
            Properties.Settings.Default.Save();
        }

        private void barButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
           
            setData();
            MessageBox.Show("تم حفظ البيانات بنجاح");
        }
    }
}