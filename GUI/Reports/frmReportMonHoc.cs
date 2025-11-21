using BLL;
using DTO;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI.Reports
{
    public partial class frmReportMonHoc : Form
    {
        public frmReportMonHoc()
        {
            InitializeComponent();
        }

        //private void LoadData()
        //{
        //    var list = ReportBLL.Instance.ReportMonHoc();
        //    string path = Path.Combine(Application.StartupPath, "Reports", "ReportMocHocDTO.rdlc");
        //    this.reportViewer1.LocalReport.ReportPath = path;
        //    ReportDataSource rds = new ReportDataSource("DataSet2", list);
        //    reportViewer1.LocalReport.DataSources.Add(rds);
        //    this.reportViewer1.RefreshReport();
        //}

        private void LoadComBoBox()
        {
            var list = MonHocBLL.Instance.GetAllMonHoc();
            list.Insert(0, new MonHocDTO { MaMonHoc = "", TenMonHoc = "Tất cả" });
            cboMonHoc.DataSource = list;
            cboMonHoc.DisplayMember = "TenMonHoc";
            cboMonHoc.ValueMember = "MaMonHoc";

            var list1 = NamHocBLL.Instance.GetAllNamHoc();
            list1.Insert(0, new NamHocDTO { MaNamHoc = "", TenNamHoc = "Tất cả" });
            cboNamHoc.DataSource = list1;
            cboNamHoc.DisplayMember = "TenNamHoc";
            cboNamHoc.ValueMember = "MaNamHoc";
        }

        private void frmReportMonHoc_Load(object sender, EventArgs e)
        {
            //LoadData();
            LoadComBoBox();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string maMon = cboMonHoc.SelectedValue?.ToString();
            string maNam = cboNamHoc.SelectedValue?.ToString();
            string maKy = cboHocKi.SelectedValue?.ToString();


            var list = ReportBLL.Instance.ReportMonHoc();


            if (!string.IsNullOrEmpty(maNam))
            {
                list = list.Where(x => x.MaNamHoc == maNam).ToList();
            }


            if (!string.IsNullOrEmpty(maKy))
            {
                list = list.Where(x => x.MaHocKy == maKy).ToList();
            }


            if (!string.IsNullOrEmpty(maMon))
            {
                list = list.Where(x => x.MaMonHoc == maMon).ToList();
            }

            reportViewer1.LocalReport.DataSources.Clear();
            string path = Path.Combine(Application.StartupPath, "Reports", "ReportMonHocDTO.rdlc");
            this.reportViewer1.LocalReport.ReportPath = path;
            ReportDataSource rds = new ReportDataSource("DataSet2", list);
            reportViewer1.LocalReport.DataSources.Add(rds);
            reportViewer1.RefreshReport();
        }


        private void cboNamHoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboNamHoc.SelectedValue == null) return;

            string maNam = cboNamHoc.SelectedValue.ToString();

            var listHocKy = HocKyBLL.Instance.GetAllHocKy()
                                .Where(x => x.MaNamHoc == maNam)
                                .ToList();
            listHocKy.Insert(0, new HocKyDTO { MaHocKy = "", TenHocKy = "Tất cả" });
            cboHocKi.DataSource = listHocKy;
            cboHocKi.DisplayMember = "TenHocKy";
            cboHocKi.ValueMember = "MaHocKy";
        }
    }
}
