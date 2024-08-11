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
                db_name.Text = Properties.Settings.Default.selected_db;
                
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

      

        private void setData()
        {
            Properties.Settings.Default.server_name = server_ip.Text;
           Properties.Settings.Default.user = user.Text;
           Properties.Settings.Default.pass = pass.Text;
           Properties.Settings.Default.server_port = server_port.Text;
            Properties.Settings.Default.selected_db = db_name.Text;
            if (radio_wide.Checked)
            {
                Properties.Settings.Default.auth_type = 1;
            }
            else
            {
                Properties.Settings.Default.auth_type = 0;
            }
            Properties.Settings.Default.Save();
            Properties.Settings.Default.Upgrade();
        }

        private void barButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
           
            setData();
            MessageBox.Show("تم حفظ البيانات بنجاح");
            groupBox1.Enabled = false;
        }

        private void frm_connection_Load(object sender, EventArgs e)
        {

        }

        private void selected_db_MouseClick(object sender, MouseEventArgs e)
        {
           
        }

        private void barButtonItem4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DbConClass.Con();
            DbConClass.conn.Open();
            string databaseName = Properties.Settings.Default.selected_db;
            string backupFilePath = txtBackupPath.Text;

            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "Backup files (*.bak)|*.bak|All files (*.*)|*.*";
                saveFileDialog.Title = "Save Database Backup As";
                saveFileDialog.DefaultExt = "bak";
                saveFileDialog.AddExtension = true;
                saveFileDialog.FileName = $"{Properties.Settings.Default.selected_db}_Backup_{DateTime.Now.ToString("yyyyMMddHHmmss")}.bak";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    txtBackupPath.Text = saveFileDialog.FileName;
                    try
                    {


                        // Connection string - replace with your server and authentication details
                        string connectionString = "Server=YOUR_SERVER_NAME;Database=master;Integrated Security=True;";

                        using (SqlConnection conn = new SqlConnection(connectionString))
                        {
                                    string backupQuery = $@"
                                BACKUP DATABASE [{databaseName}] 
                                TO DISK = '{backupFilePath}' 
                                WITH FORMAT, INIT, 
                                NAME = 'Full Backup of {databaseName}', 
                                SKIP, NOREWIND, NOUNLOAD, STATS = 10";

                            using (SqlCommand cmd = new SqlCommand(backupQuery, DbConClass.conn))
                            {
                                cmd.ExecuteNonQuery();
                            }

                            MessageBox.Show($"عملية النسخ الاحتياطي لقاعدة البيانات {databaseName} تمت بنجاح.", "تم الانتهاء بنجاح", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"An error occurred while backing up the database: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
           

            if (string.IsNullOrEmpty(databaseName) || string.IsNullOrEmpty(backupFilePath))
            {
                MessageBox.Show("Please specify the database name and backup file path.");
                return;
            }

           
        }

        private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
          
        }

        private void barButtonItem5_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            groupBox1.Enabled = true;
        }
    }
}