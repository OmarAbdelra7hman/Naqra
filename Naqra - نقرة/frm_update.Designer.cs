namespace Naqra___نقرة
{
    partial class frm_update
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_update));
            this.label_title = new System.Windows.Forms.Label();
            this.btn_update = new DevExpress.XtraEditors.SimpleButton();
            this.label_old = new System.Windows.Forms.Label();
            this.label_new = new System.Windows.Forms.Label();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.bw_update = new System.ComponentModel.BackgroundWorker();
            this.SuspendLayout();
            // 
            // label_title
            // 
            this.label_title.Dock = System.Windows.Forms.DockStyle.Top;
            this.label_title.Font = new System.Drawing.Font("beIN Normal ", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_title.Location = new System.Drawing.Point(0, 0);
            this.label_title.Name = "label_title";
            this.label_title.Size = new System.Drawing.Size(527, 37);
            this.label_title.TabIndex = 0;
            this.label_title.Text = "جاري التحقق من وجود تحديثات....";
            this.label_title.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btn_update
            // 
            this.btn_update.Enabled = false;
            this.btn_update.Location = new System.Drawing.Point(151, 241);
            this.btn_update.Name = "btn_update";
            this.btn_update.Size = new System.Drawing.Size(232, 44);
            this.btn_update.TabIndex = 1;
            this.btn_update.Text = "تحديث البرنامج الان";
            this.btn_update.Click += new System.EventHandler(this.btn_update_Click);
            // 
            // label_old
            // 
            this.label_old.AutoSize = true;
            this.label_old.Font = new System.Drawing.Font("beIN Normal ", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_old.Location = new System.Drawing.Point(37, 93);
            this.label_old.Name = "label_old";
            this.label_old.Size = new System.Drawing.Size(88, 37);
            this.label_old.TabIndex = 2;
            this.label_old.Text = "الإصدار الحالي";
            // 
            // label_new
            // 
            this.label_new.AutoSize = true;
            this.label_new.Font = new System.Drawing.Font("beIN Normal ", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_new.Location = new System.Drawing.Point(37, 134);
            this.label_new.Name = "label_new";
            this.label_new.Size = new System.Drawing.Size(89, 37);
            this.label_new.TabIndex = 3;
            this.label_new.Text = "الإصدار الجديد";
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.LinkColor = System.Drawing.Color.CornflowerBlue;
            this.linkLabel1.Location = new System.Drawing.Point(178, 188);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(175, 28);
            this.linkLabel1.TabIndex = 4;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "لمعرفة الجديد في التحديث اضغط هنا";
            // 
            // bw_update
            // 
            this.bw_update.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bw_update_DoWork);
            this.bw_update.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bw_update_RunWorkerCompleted);
            // 
            // frm_update
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 28F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(527, 330);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.label_new);
            this.Controls.Add(this.label_old);
            this.Controls.Add(this.btn_update);
            this.Controls.Add(this.label_title);
            this.IconOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("frm_update.IconOptions.LargeImage")));
            this.MaximizeBox = false;
            this.Name = "frm_update";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "تحديث البرنامج";
            this.Load += new System.EventHandler(this.frm_update_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_title;
        private DevExpress.XtraEditors.SimpleButton btn_update;
        private System.Windows.Forms.Label label_old;
        private System.Windows.Forms.Label label_new;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.ComponentModel.BackgroundWorker bw_update;
    }
}