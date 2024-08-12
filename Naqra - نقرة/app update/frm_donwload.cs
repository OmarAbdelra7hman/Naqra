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
    public partial class frm_donwload : DevExpress.XtraEditors.XtraForm
    {
        public frm_donwload()
        {
            InitializeComponent();
        }

        public void guna2Button1_Click(object sender, EventArgs e)
        {
            frm_update.webClient.CancelAsync();
            this.Close();
            
        }

        private void frm_donwload_FormClosing(object sender, FormClosingEventArgs e)
        {
            frm_update.webClient.CancelAsync();
            this.Close();
        }

        private void guna2CircleProgressBar1_ValueChanged(object sender, EventArgs e)
        {
           if(guna2CircleProgressBar1.Value == 100)
            {
                this.Close();
            }
        }
    }
}