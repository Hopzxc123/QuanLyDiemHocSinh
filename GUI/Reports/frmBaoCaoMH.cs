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
    public partial class frmBaoCaoMH : Form
    {
        public frmBaoCaoMH()
        {
            InitializeComponent();
            this.TopLevel = false;

            // 2. Tắt viền cửa sổ để nó trông giống một UserControl hơn.
            this.FormBorderStyle = FormBorderStyle.None;

            // 3. Đảm bảo Form con tự động điều chỉnh kích thước nếu cần.
            this.AutoScroll = true;
        }

        private void frmBaoCaoMH_Load(object sender, EventArgs e)
        {
            CapNhatNamHoc();
            string path = Path.Combine(Application.StartupPath, "Reports", "BaoCaoMH.rdlc");
            this.rpBaoCaoMH.LocalReport.ReportPath = path;
            this.rpBaoCaoMH.RefreshReport();
        }
        private void CapNhatNamHoc()
        {
            List<NamHocDTO> nams = NamHocBLL.Instance.GetAllNamHoc();
            nams.Sort((x, y) => y.NgayKetThuc.CompareTo(x.NgayBatDau)); // Sắp xếp giảm dần theo Năm Bắt Đầu
            nams.Insert(0, new NamHocDTO { MaNamHoc = "", TenNamHoc = "-Năm học-" });
            cbbNamHoc.DataSource = nams;
            cbbNamHoc.DisplayMember = "TenNamHoc";
            cbbNamHoc.ValueMember = "MaNamHoc";

            // MON HOC
            List<MonHocDTO> mons = MonHocBLL.Instance.GetAllMonHoc();
            mons.Sort((x, y) => string.Compare(x.TenMonHoc, y.TenMonHoc));
            mons.Insert(0, new MonHocDTO
            {
                MaMonHoc = "",
                TenMonHoc = "-- Môn học --"
            });
            cbbMonHoc.DataSource = mons;
            cbbMonHoc.DisplayMember = "TenMonHoc";  // Cái hiện ra
            cbbMonHoc.ValueMember = "MaMonHoc";      // Giá trị thật

        }

        private void cbbNamHoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            //fix loi khi load form gan datasoure vao cbb thi no se tu dong kich hoat su kien nay
            if (cbbNamHoc.SelectedValue == null)
            {
                MessageBox.Show(this, "Vui lòng chọn năm học để lọc!");
                return;
            }

            cbbHocKy.DataSource = null;
            string maNamHoc = cbbNamHoc.SelectedValue.ToString();
            List<HocKyDTO> hocKys = HocKyBLL.Instance.GetHocKyByNamHoc(maNamHoc);
            hocKys.Sort((x, y) => string.Compare(x.TenHocKy, y.TenHocKy));
            hocKys.Insert(0, new HocKyDTO
            {
                MaHocKy = "",
                TenHocKy = "-- Chọn học kỳ --"
            });
            cbbHocKy.DataSource = hocKys;
            cbbHocKy.DisplayMember = "TenHocKy";
            cbbHocKy.ValueMember = "MaHocKy";
            cbbHocKy.SelectedIndex = 0;



        }

        private void cbbLop_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void cbbMonHoc_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            IList<ReportParameter> param = new List<ReportParameter>();
            param.Add(new ReportParameter("NgayLap", DateTime.UtcNow.ToString("dd/MM/yyyy")));
            param.Add(new ReportParameter("NamHoc", cbbNamHoc.Text));
            param.Add(new ReportParameter("HocKy", cbbHocKy.Text));
            param.Add(new ReportParameter("MonHoc", cbbMonHoc.Text));

            this.rpBaoCaoMH.LocalReport.SetParameters(param);
            string maHocKy = cbbHocKy.SelectedValue.ToString().Trim();
            string maMonHoc = cbbMonHoc.SelectedValue.ToString().Trim();
            List<frmBaoCaoTKMHDTO> list = ReportBLL.Instance.ReportTongKetMon(maHocKy, maMonHoc);
            //bsTongKetMonHoc.DataSource = null;
            if (cbbMonHoc.SelectedValue != null && cbbHocKy.SelectedValue != null && cbbNamHoc.SelectedValue != null)
            {
                this.rpBaoCaoMH.LocalReport.DataSources.Clear();
                ReportDataSource rds = new ReportDataSource("DataSet1", list);
                this.rpBaoCaoMH.LocalReport.DataSources.Add(rds);

            }
           
            this.rpBaoCaoMH.RefreshReport();


        }
    }
}
