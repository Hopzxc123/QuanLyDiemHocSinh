using BLL;
using BLL.Reports;
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
    public partial class frmKQLHHocKy : Form
    {
        public frmKQLHHocKy()
        {
            InitializeComponent();
        }
     
        private void frmKQLHHocKy_Load(object sender, EventArgs e)
        {

            this.rpvKQLHHK.LocalReport.ReportEmbeddedResource = "GUI.Reports.rptKQLHHocKy.rdlc";
            LoadComboBoxNamHoc(); // Chỉ load Năm học

            // Vô hiệu hóa cbbHocKy ban đầu
            cbbHocKy.DataSource = null;
            cbbHocKy.Enabled = false;

            rpvKQLHHK.RefreshReport();

        }
        private void LoadComboBoxNamHoc()
        {
            cbbNamHoc.DataSource = NamHocBLL.Instance.GetAllNamHoc();
            cbbNamHoc.DisplayMember = "TenNamHoc";
            cbbNamHoc.ValueMember = "MaNamHoc";
            cbbNamHoc.SelectedIndex = -1; // Bỏ chọn mặc định
        }
        private void cbbNamHoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Kiểm tra xem người dùng đã thực sự chọn một item chưa
            if (cbbNamHoc.SelectedValue != null)
            {
                // Lấy mã năm học vừa chọn
                string maNamHoc = cbbNamHoc.SelectedValue.ToString();

                // Dùng mã này để load HocKy
                cbbHocKy.DataSource = HocKyBLL.Instance.GetHocKyByNamHoc(maNamHoc);
                cbbHocKy.DisplayMember = "TenHocKy";
                cbbHocKy.ValueMember = "MaHocKy";
                cbbHocKy.SelectedIndex = -1; // Bỏ chọn mặc định

                // Mở lại ComboBox Học kỳ
                cbbHocKy.Enabled = true;
            }
            else
            {
                // Nếu người dùng không chọn gì (ví dụ: reset), thì làm trống cbbHocKy
                cbbHocKy.DataSource = null;
                cbbHocKy.Enabled = false;
            }
        }
        private void btnXem_Click(object sender, EventArgs e)
        {
            // 1. Kiểm tra null (Giữ nguyên)
            if (cbbNamHoc.SelectedValue == null || cbbHocKy.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn đầy đủ năm học và học kỳ.", "Thông báo",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2. Lấy giá trị (Thêm NgayLap)
            string namHoc = cbbNamHoc.SelectedValue.ToString();
            string hocKy = cbbHocKy.SelectedValue.ToString();

            // Thêm dòng này để lấy ngày hiện tại
            // 2.2. Lấy TÊN (Text) để hiển thị lên Report
            string tenNamHoc = cbbNamHoc.Text;
            string tenHocKy = cbbHocKy.Text;
            string ngayLap = DateTime.Now.ToString("dd/MM/yyyy");

            // 3. Gọi BLL (Giữ nguyên)
            DataTable dt = KQLHHocKyBLL.Instance.GetBaoCaoHocKy(namHoc, hocKy);

            // 4. Đổ dữ liệu vào ReportViewer
            rpvKQLHHK.LocalReport.DataSources.Clear();

            // --- SỬA 1: Tên DataSet phải là "KQLHocKyDTO" ---
            // (Để khớp với dòng 223 trong file XML của bạn)
            rpvKQLHHK.LocalReport.DataSources.Add(
                new ReportDataSource("KQLHocKyDTO", dt)
            );

            // 5. Set Parameters
            // --- SỬA 2: Tên Parameters phải là "NamHoc", "HocKy", "NgayLap" ---
            // (Để khớp với các dòng 275, 280, 285 trong file XML)
            ReportParameter[] rp = new ReportParameter[]
            {
        new ReportParameter("NamHoc", tenNamHoc),  // Bỏ chữ 'p'
        new ReportParameter("HocKy", tenHocKy),    // Bỏ chữ 'p'
        new ReportParameter("NgayLap", ngayLap) // Thêm tham số NgayLap
            };
            rpvKQLHHK.LocalReport.SetParameters(rp);

            // 6. Refresh report
            rpvKQLHHK.RefreshReport();
        }
    }
}
