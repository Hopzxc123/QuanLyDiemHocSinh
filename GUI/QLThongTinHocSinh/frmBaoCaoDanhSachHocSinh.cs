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

namespace GUI.QLThongTinHocSinh
{
    public partial class frmBaoCaoDanhSachHocSinh : Form
    {
        public frmBaoCaoDanhSachHocSinh()
        {
            InitializeComponent();
        }

        private void frmBaoCaoDanhSachHocSinh_Load(object sender, EventArgs e)
        {
            rpvDSHS.LocalReport.ReportEmbeddedResource = "GUI.QLThongTinHocSinh.rptDanhSachHocSinh.rdlc";
            
            var list = HocSinhBLL.Instance.GetAllHocSinh();

            rpvDSHS.LocalReport.DataSources.Clear();
            rpvDSHS.LocalReport.DataSources.Add(
                new ReportDataSource("HocSinhDTO", list)
            );

            rpvDSHS.RefreshReport();
        }
    }
}
