using BLL;
using DTO;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Linq;

namespace GUI.Reports
{
    public partial class HoSoLopHoc : Form
    {
        // Khai báo biến toàn cục để lưu danh sách Lớp và Năm Học
        private List<LopDTO> _listLop;
        private List<NamHocDTO> _listNamHoc;

        public HoSoLopHoc()
        {
            InitializeComponent();
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "GUI.Reports.rptHoSoLopHoc.rdlc";

            // CHỈ TẢI NĂM HỌC khi Form khởi tạo
            LoadNamHocData();

            // Gán sự kiện cho ComboBox Năm Học (Cần thiết lập trong Designer)
            this.cboNamHoc.SelectedIndexChanged += new System.EventHandler(this.cboNamHoc_SelectedIndexChanged);
        }

        private void HoSoLopHoc_Load(object sender, EventArgs e)
        {
            // Để trống
        }

        // ĐÃ ĐỔI TÊN: Chỉ tải Năm Học
        private void LoadNamHocData()
        {
            try
            {
                // 1. Load Năm Học
                _listNamHoc = NamHocBLL.Instance.GetAllNamHoc();
                cboNamHoc.DataSource = _listNamHoc;
                cboNamHoc.DisplayMember = "TenNamHoc";
                cboNamHoc.ValueMember = "MaNamHoc";
                cboNamHoc.SelectedIndex = -1;

                // Khởi tạo cboLop rỗng ban đầu
                cboLop.DataSource = null;
                cboLop.Items.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải dữ liệu cho bộ lọc: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // HÀM MỚI: Tải Lớp theo Mã Năm Học
        private void LoadLopByNamHoc(string maNamHoc)
        {
            try
            {
                // Xóa DataSource cũ để tránh lặp dữ liệu
                cboLop.DataSource = null;
                cboLop.Items.Clear();

                // Cần đảm bảo có phương thức GetLopByNamHoc(maNamHoc) trong LopBLL
                _listLop = LopBLL.Instance.GetLopByNamHoc(maNamHoc);

                cboLop.DataSource = _listLop;
                cboLop.DisplayMember = "TenLop";
                cboLop.ValueMember = "MaLop";
                cboLop.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải dữ liệu Lớp: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // SỰ KIỆN MỚI: Xử lý khi chọn Năm Học khác
        private void cboNamHoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Dùng SelectedValue để đảm bảo giá trị đã được chọn
            if (cboNamHoc.SelectedValue != null && cboNamHoc.SelectedIndex != -1)
            {
                string maNamHocDuocChon = cboNamHoc.SelectedValue.ToString();
                LoadLopByNamHoc(maNamHocDuocChon);
            }
            else
            {
                // Nếu không chọn Năm Học, làm rỗng ComboBox Lớp
                cboLop.DataSource = null;
                cboLop.Items.Clear();
            }
        }


        private void DisplayReport(string maLop, string maNamHoc)
        {
            // 1. Lấy dữ liệu học sinh theo Mã Lớp đã chọn
            // (Tuy nhiên cần kiểm tra: GetHocSinhByLop(maLop) có đảm bảo lọc theo Năm Học không?)
            List<HocSinhDTO> listHocSinh = HocSinhBLL.Instance.GetHocSinhByLop(maLop);
            this.reportViewer1.LocalReport.DataSources.Clear();

            if (listHocSinh == null || listHocSinh.Count == 0)
            {
                this.reportViewer1.RefreshReport();
                MessageBox.Show("Lớp này chưa có học sinh hoặc dữ liệu trống.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // 2. Lấy thông tin Tham số chi tiết
            LopDTO lopDuocChon = _listLop.FirstOrDefault(l => l.MaLop == maLop);
            string tenLop = lopDuocChon?.TenLop ?? maLop;

            NamHocDTO namHocDuocChon = _listNamHoc.FirstOrDefault(n => n.MaNamHoc == maNamHoc);
            string namHocText = namHocDuocChon?.TenNamHoc ?? maNamHoc;

            int siSo = listHocSinh.Count;
            string ngayLap = DateTime.Now.ToString("dd/MM/yyyy");

            // 3. Gán ReportDataSource
            ReportDataSource rds = new ReportDataSource("DataSet1", listHocSinh);
            this.reportViewer1.LocalReport.DataSources.Add(rds);

            // 4. Gán Tham số (Đã bổ sung)
            ReportParameter pNamHoc = new ReportParameter("NamHoc", namHocText);
            ReportParameter pLop = new ReportParameter("Lop", tenLop);
            ReportParameter pSiSo = new ReportParameter("SiSo", siSo.ToString());
            ReportParameter pNgayLap = new ReportParameter("NgayLap", ngayLap);

            this.reportViewer1.LocalReport.SetParameters(new ReportParameter[] { pNamHoc, pLop, pSiSo, pNgayLap });

            // 5. Làm mới ReportViewer
            this.reportViewer1.RefreshReport();
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            if (cboLop.SelectedValue == null || cboNamHoc.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn đầy đủ Năm học và Lớp.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string maLopDuocChon = cboLop.SelectedValue?.ToString();
            string maNamHocDuocChon = cboNamHoc.SelectedValue?.ToString();

            DisplayReport(maLopDuocChon, maNamHocDuocChon);
        }
    }
}