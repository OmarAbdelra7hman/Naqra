using DevExpress.LookAndFeel;
using DevExpress.Xpf.Core;
using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Naqra___نقرة
{
    public partial class frm_main : DevExpress.XtraEditors.XtraForm

    {
        bool isLight = true;
        public frm_main()
        {
            InitializeComponent();
          

        }

        private void frm_main_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void frm_main_Load(object sender, EventArgs e)
        {
            searchControl1.Focus();
               searchControl1.Clear();
            frm_update frm_Update = new frm_update();
            if (frm_Update.checkUpdate())
            {
                frm_Update.ShowDialog();
            }
            
           
        }

        private void barToggleSwitchItem1_CheckedChanged(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            
            if (isLight)
            {
                UserLookAndFeel.Default.SetSkinStyle("Office 2019 Black");
                isLight= false;
                tileItem1.AppearanceItem.Normal.BackColor = Color.FromArgb(40, 40, 40);
                tileItem2.AppearanceItem.Normal.BackColor = Color.FromArgb(40, 40, 40);
                tileItem3.AppearanceItem.Normal.BackColor = Color.FromArgb(40, 40, 40);
                tileItem4.AppearanceItem.Normal.BackColor = Color.FromArgb(40, 40, 40);
                tileItem5.AppearanceItem.Normal.BackColor = Color.FromArgb(40, 40, 40);
                tileItem6.AppearanceItem.Normal.BackColor = Color.FromArgb(40, 40, 40);

            }
            else
            {
                UserLookAndFeel.Default.SetSkinStyle("The Bezier");
                tileItem1.AppearanceItem.Normal.BackColor = Color.WhiteSmoke;
                tileItem2.AppearanceItem.Normal.BackColor = Color.WhiteSmoke;
                tileItem3.AppearanceItem.Normal.BackColor = Color.WhiteSmoke;
                tileItem4.AppearanceItem.Normal.BackColor = Color.WhiteSmoke;
                tileItem5.AppearanceItem.Normal.BackColor = Color.WhiteSmoke;
                tileItem6.AppearanceItem.Normal.BackColor = Color.WhiteSmoke;
                isLight = true;

            }
            
        }

        private void تحديثالبرنامجToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_update frm_Update = new frm_update();
            frm_Update.ShowDialog(this);
        }

        private void حولالبرنامجToolStripMenuItem_MouseHover(object sender, EventArgs e)
        {
           
        }

        private void barButtonItem8_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frm_login frm_login = new frm_login();
            frm_login.ShowDialog(this);

        }

        private void barButtonItem7_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
           
        }

        private void barButtonItem15_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
           
        }

        private void barButtonItem13_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
           
        }

        private void barButtonItem41_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frm_update frm_Update = new frm_update();
            frm_Update.ShowDialog();
        }

        private void barButtonItem42_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frm_contact frm_Contact = new frm_contact();
            frm_Contact.Show(this);
        }

        private void barButtonItem23_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frm_company frm_Company = new frm_company();
            frm_Company.Show(this);
        }

        private void barButtonItem24_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
                       frm_branch frm_Branch = new frm_branch();   
            frm_Branch.Show(this);
        }

        private void barButtonItem26_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            
        }

        private void barButtonItem44_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frm_users frm_Users = new frm_users();
            frm_Users.Show(this);
        }

        private void barButtonItem45_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frm_account_tree frm_Account_Tree = new frm_account_tree();
            frm_Account_Tree.Show(this);
        }

        private void barButtonItem29_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frm_banks frm_banks = new frm_banks();
            frm_banks.Show(this);
        }

        private void barButtonItem46_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
           
            this.Hide();
        
            frm_login frm_login = new frm_login();
            frm_login.Show(this);

        }

        private void barButtonItem32_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frm_employee frm_Employee =  new frm_employee();
            frm_Employee.Show(this);
        }

        private void barButtonItem74_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }
    }
}