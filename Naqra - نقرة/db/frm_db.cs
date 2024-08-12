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
using static System.ComponentModel.Design.ObjectSelectorEditor;
using System.Xml.Linq;

namespace Naqra___نقرة
{
    public partial class frm_db : DevExpress.XtraEditors.XtraForm
    {
        public frm_db()
        {
            InitializeComponent();
        }
        public String dbName;

        private void frm_db_Load(object sender, EventArgs e)
        {
            string connectionString = $"Data Source={Properties.Settings.Default.server_name};Initial Catalog=master;User ID={Properties.Settings.Default.user};Password={Properties.Settings.Default.pass};";
            string query = @"
                            SELECT 
                            ROW_NUMBER() OVER(ORDER BY db.name) AS [م], 
                            db.name AS 'اسم قاعدة البيانات', 
                            mf.physical_name AS 'المسار ومكان القاعدة'
                            FROM sys.databases db
                            JOIN sys.master_files mf ON db.database_id = mf.database_id
                            WHERE mf.type = 0 -- Filter to only show data files (type = 0) and exclude log files
                            AND db.name NOT IN ('master', 'tempdb', 'model', 'msdb')
                            ORDER BY [م]";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlDataAdapter dataAdapter = new SqlDataAdapter(query, connection);
                DataTable dataTable = new DataTable();
                dataAdapter.Fill(dataTable);

                // Bind the DataTable to the GridControl
                gridControl1.DataSource = dataTable;
                
                gridControl1.MainView.PopulateColumns();
                gridView1.Columns["م"].Width = 50;          // Set width for the 'No.' column
                gridView1.Columns["اسم قاعدة البيانات"].Width = 150; // Set width for the 'DatabaseName' column
                gridView1.Columns["المسار ومكان القاعدة"].Width = 300;
              

            }
        }
        string databaseName;
        
        private void gridView1_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
             databaseName = gridView1.GetRowCellValue(e.RowHandle, "اسم قاعدة البيانات").ToString();

            

            if(e.Clicks == 2 && e.Button == MouseButtons.Left)
            {
                Properties.Settings.Default.selected_db = databaseName;
                Properties.Settings.Default.Save();
                this.Close();
            }

            // Pass the database name to another form


        }

        private void barButtonItem4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Properties.Settings.Default.selected_db = databaseName;
            Properties.Settings.Default.Save();
            this.Close();

        }
    }
}