using BLL;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace GUI.UserControls
{
    public partial class ucThongKeTongQuan : UserControl
    {
        public ucThongKeTongQuan()
        {
            InitializeComponent();
            LoadThongKe();
            LoadHocSinhGioi();
        }

        private void LoadThongKe()
        {
            try
            {
                int tongHocSinh = HocSinhBLL.Instance.GetAllHocSinh().Count;
                int tongLop = LopBLL.Instance.GetAllLop().Count;
                int tongMon = MonHocBLL.Instance.GetAllMonHoc().Count;

                lblHocSinh.Text = tongHocSinh.ToString();
                lblLop.Text = tongLop.ToString();
                lblMonHoc.Text = tongMon.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải thống kê: " + ex.Message);
            }
        }

        private void LoadHocSinhGioi()
        {
            try
            {
                var dsHS = HocSinhBLL.Instance.GetAllHocSinh();
                var dsDiem = DiemBLL.Instance.GetAllDiem();

                // Gộp dữ liệu điểm và học sinh theo MaHocSinh
                var hocSinhGioi = (from hs in dsHS
                                   join d in dsDiem on hs.MaHocSinh equals d.MaHocSinh
                                   group d by new { hs.MaHocSinh, hs.HoTen, hs.MaLop } into g
                                   let diemTrungBinh = g.Average(x => x.DiemTongKet)
                                   where diemTrungBinh >= 8.0
                                   orderby diemTrungBinh descending
                                   select new
                                   {
                                       g.Key.MaHocSinh,
                                       g.Key.HoTen,
                                       g.Key.MaLop,
                                       DiemTongKet = Math.Round(Convert.ToDouble(diemTrungBinh), 2),
                                       XepLoai = diemTrungBinh >= 9 ? "Xuất sắc" :
                                                 diemTrungBinh >= 8 ? "Giỏi" :
                                                 diemTrungBinh >= 6.5 ? "Khá" :
                                                 diemTrungBinh >= 5 ? "Trung bình" : "Yếu"
                                   }).ToList();



                dgvHocSinhGioi.DataSource = hocSinhGioi;
                dgvHocSinhGioi.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                dgvHocSinhGioi.Columns["MaHocSinh"].HeaderText = "Mã HS";
                dgvHocSinhGioi.Columns["HoTen"].HeaderText = "Họ tên";
                dgvHocSinhGioi.Columns["MaLop"].HeaderText = "Lớp";
                dgvHocSinhGioi.Columns["DiemTongKet"].HeaderText = "Điểm tổng kết";
                dgvHocSinhGioi.Columns["DiemTongKet"].DefaultCellStyle.Format = "0.00";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh sách học sinh giỏi: " + ex.Message);
            }
        }


        private void ucThongKeTongQuan_Load(object sender, EventArgs e)
            {
                // Có thể để trống hoặc xóa
            }

        
    }
}