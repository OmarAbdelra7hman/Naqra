using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Naqra___نقرة
{
    public partial class frm_update : DevExpress.XtraEditors.XtraForm
    {
        static   public WebClient webClient;
        frm_donwload frm_Donwload = new frm_donwload();
        private void InitializeWebClient()
        {
            webClient = new WebClient();
            webClient.DownloadProgressChanged += WebClient_DownloadProgressChanged;
            webClient.DownloadFileCompleted += WebClient_DownloadFileCompleted;
            
        }

        private void WebClient_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            frm_Donwload.guna2CircleProgressBar1.Value = e.ProgressPercentage;
           
           
        }

        public frm_update()
        {
            InitializeComponent();
            InitializeWebClient();
            checkUpdate();
        }
        void initScript()
        {


            Process myProcess = new Process();
            myProcess.StartInfo.FileName = "msiexec";
            myProcess.StartInfo.WorkingDirectory = @"C:\Users\Public\Downloads\";
            myProcess.StartInfo.Arguments = "  /i naqraSetup.msi ADDLOCAL=test";
            myProcess.StartInfo.Verb = "runas";
            myProcess.Start();
            myProcess.WaitForExit();
            this.Close();
        }
        public  bool checkUpdate()
        {
            
             label_new.Hide();
            String urlVersion = "http://naqra.rf.gd/version.txt";
            var newVersion = new WebClient().DownloadString(urlVersion);
            var currentVersion = Application.ProductVersion.ToString();

            newVersion = newVersion.Replace(".","");
            currentVersion = currentVersion.Replace(".","");
            

            if (int.Parse(newVersion) > int.Parse(currentVersion))
            {
               
                btn_update.Enabled = true;
                label_title.Text = " يوجد اصدار احدث هل تريد التحديث ؟";
                label_new.Text = "  الإصدار الجديد  " + new WebClient().DownloadString(urlVersion);
                label_new.Show();

                return true;
            }
            else
            {
                label_title.Text = "انت على احدث نسخة";
                label_new.Hide();
                return false;
            }
        }

        private void frm_update_Load(object sender, EventArgs e)
        {
            label_old.Text = "  الإصدار الحالي  " + Application.ProductVersion.ToString();
        }

        private void bw_update_DoWork(object sender, DoWorkEventArgs e)
        {
            checkUpdate();
        }

        private void bw_update_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            bw_update.RunWorkerAsync();
        }

        private void btn_update_Click(object sender, EventArgs e)
        {
           
            
           

            try
            {
                webClient.DownloadFileAsync(new Uri("http://naqra.rf.gd/naqraSetup.msi"), "C:\\Users\\Public\\Downloads\\naqraSetup" + "" + ".msi");
               

                frm_Donwload.ShowDialog();
            }
            catch (Exception ex) {
                MessageBox.Show("تعذر تحميل الملف");
            }
            
         
           

        }

        private void WebClient_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            MessageBox.Show("اكتمل التحميل");
            initScript();

        }
    }
}