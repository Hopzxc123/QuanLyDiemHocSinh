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
    public partial class frmKQHSCaNam : Form
    {
        public frmKQHSCaNam()
        {
            InitializeComponent();
        }

        private void frmKQHSCaNam_Load(object sender, EventArgs e)
        {
            cbbLop.DropDownStyle = ComboBoxStyle.DropDownList;
            cbbLop.IntegralHeight = false;
            cbbLop.DropDownHeight = 150;
            LoadLop();
            LoadNamHoc();
        }

        private void LoadLop()
        {
            var list = LopBLL.Instance.GetAllLop();

            cbbLop.DataSource = list;
            cbbLop.DisplayMember = "TenLop";
            cbbLop.ValueMember = "MaLop";
            cbbLop.SelectedIndex = -1;
        }

        private void LoadNamHoc()
        {
            var list = NamHocBLL.Instance.GetAllNamHoc();

            cbbNamHoc.DataSource = list;
            cbbNamHoc.DisplayMember = "TenNamHoc";
            cbbNamHoc.ValueMember = "MaNamHoc";
            cbbNamHoc.SelectedIndex = -1;
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            string maNamHoc = cbbNamHoc.SelectedValue.ToString();
            string maLop = cbbLop.SelectedValue.ToString();
            IList<ReportParameter> param = new List<ReportParameter>();
            param.Add(new ReportParameter("NgayLap", DateTime.Now.ToString("dd/MM/yyyy")));
            param.Add(new ReportParameter("NamHoc", cbbNamHoc.Text));
            param.Add(new ReportParameter("Lop", cbbLop.Text));


            DataTable dataTable = ReportBLL.Instance.ReportKQHSCaNam(maNamHoc, maLop);

            string reportPath = System.IO.Path.Combine(Application.StartupPath, @"Reports\rptKQHSCaNam.rdlc");
            rpvKQHSCaNam.LocalReport.ReportPath = reportPath;


            rpvKQHSCaNam.LocalReport.DataSources.Clear();
            rpvKQHSCaNam.LocalReport.DataSources.Add(
                new ReportDataSource ("dsKQHSCaNam", dataTable)
            );

            rpvKQHSCaNam.LocalReport.SetParameters(param);

            this.rpvKQHSCaNam.RefreshReport();
        }
    }
}
