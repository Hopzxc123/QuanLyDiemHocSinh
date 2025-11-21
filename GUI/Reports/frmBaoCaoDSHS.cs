using BLL;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI.Reports
{
    public partial class frmBaoCaoDSHS : Form
    {
        public frmBaoCaoDSHS()
        {
            InitializeComponent();
            this.TopLevel = false;

            // 2. Tắt viền cửa sổ để nó trông giống một UserControl hơn.
            this.FormBorderStyle = FormBorderStyle.None;

            // 3. Đảm bảo Form con tự động điều chỉnh kích thước nếu cần.
            this.AutoScroll = true;
        }

        private void frmBaoCaoDSHS_Load(object sender, EventArgs e)
        {
            rpvDSHS.LocalReport.ReportEmbeddedResource = "GUI.Reports.rptDanhSachHocSinh.rdlc";

            var list = HocSinhBLL.Instance.GetAllHocSinh();

            rpvDSHS.LocalReport.DataSources.Clear();
            rpvDSHS.LocalReport.DataSources.Add(
                new ReportDataSource("HocSinhDTO", list)
            );

            rpvDSHS.RefreshReport();
        }
    }
}
