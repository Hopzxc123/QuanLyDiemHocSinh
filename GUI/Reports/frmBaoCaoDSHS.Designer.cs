namespace GUI.Reports
{
    partial class frmBaoCaoDSHS
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.rpvDSHS = new Microsoft.Reporting.WinForms.ReportViewer();
            this.SuspendLayout();
            // 
            // rpvDSHS
            // 
            this.rpvDSHS.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "HocSinhDTO";
            reportDataSource1.Value = null;
            this.rpvDSHS.LocalReport.DataSources.Add(reportDataSource1);
            this.rpvDSHS.LocalReport.ReportEmbeddedResource = "QuanLyHocSinh.Reports.rptDanhSachHocSinh.rdlc";
            this.rpvDSHS.Location = new System.Drawing.Point(0, 0);
            this.rpvDSHS.Name = "rpvDSHS";
            this.rpvDSHS.ServerReport.BearerToken = null;
            this.rpvDSHS.Size = new System.Drawing.Size(800, 450);
            this.rpvDSHS.TabIndex = 3;
            // 
            // frmBaoCaoDSHS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.rpvDSHS);
            this.Name = "frmBaoCaoDSHS";
            this.Text = "frmBaoCaoDSHS";
            this.Load += new System.EventHandler(this.frmBaoCaoDSHS_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer rpvDSHS;
    }
}