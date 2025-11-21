using BLL;
using DTO;
using GUI.Helper;
using GUI.Reports;
using Guna.Charts.WinForms;
using Microsoft.Office.Interop.Excel;
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
using Excel = Microsoft.Office.Interop.Excel;

namespace GUI
{
    public partial class frmThongKe : Form
    {
        public frmThongKe()
        {
            InitializeComponent();
            // KHÔNG NÊN TẢI DỮ LIỆU NẶNG TRONG HÀM DỰNG (CONSTRUCTOR)
            // Chúng ta sẽ di chuyển LoadThongKe() sang sự kiện Form_Load
        }

        private void LoadThongKe()
        {
            try
            {
                // Các thao tác này khá nhanh, không phải là vấn đề chính
                int tongHocSinh = HocSinhBLL.Instance.GetAllHocSinh().Count;
                int tongLop = LopBLL.Instance.GetAllLop().Count;
                int tongMon = MonHocBLL.Instance.GetAllMonHoc().Count;

                // (Nếu bạn có các Label để hiển thị, hãy thêm chúng ở đây,
                // ví dụ: lblHocSinh.Text = tongHocSinh.ToString();)
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải thống kê: " + ex.Message);
            }
        }

        //private void LoadHocSinhGioi()
        //{
        //    try
        //    {
        //        var dsHS = HocSinhBLL.Instance.GetAllHocSinh();
        //        var dsDiem = DiemBLL.Instance.GetAllDiem();
        //        // Gộp dữ liệu điểm và học sinh theo MaHocSinh
        //        var hocSinhGioi = (from hs in dsHS
        //                          join d in dsDiem on hs.MaHocSinh equals d.MaHocSinh
        //                          group d by new { hs.MaHocSinh, hs.HoTen, hs.MaLop } into g
        //                          let diemTrungBinh = g.Average(x => x.DiemTongKet)
        //                          where diemTrungBinh >= 8.0
        //                          orderby diemTrungBinh descending
        //                          select new
        //                          {
        //                              g.Key.MaHocSinh,
        //                              g.Key.HoTen,
        //                              g.Key.MaLop,
        //                              DiemTongKet = Math.Round(Convert.ToDouble(diemTrungBinh), 2),
        //                              XepLoai = diemTrungBinh >= 9 ? "Xuất sắc" :
        //                                          diemTrungBinh >= 8 ? "Giỏi" :
        //                                          diemTrungBinh >= 6.5 ? "Khá" :
        //                                          diemTrungBinh >= 5 ? "Trung bình" : "Yếu"
        //                          }).ToList();
        //        // dgvHocSinhGioi.DataSource = hocSinhGioi;
        //        // ... (các gán dgvHocSinhGioi) ...
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("Lỗi khi tải danh sách học sinh giỏi: " + ex.Message);
        //    }
        //}


        

        

        private void frmThongKe_Load(object sender, EventArgs e)
        {
            LoadThongKe(); // <--- CHUYỂN XUỐNG ĐÂY
            //LoadHocSinhGioi();
            CapNhatCBB();
            HocKyDTO hocKyHienTai = HocKyBLL.Instance.GetCurrentNamHoc();

            // HÀM GÂY CHẬM - CẦN TỐI ƯU HÓA
            SetUpGunaChart(hocKyHienTai.MaHocKy);

            grThongKe.Text = "Học kì hiện tại";

        }

        private void CapNhatCBB()
        {
            List<NamHocDTO> nams = NamHocBLL.Instance.GetAllNamHoc();
            nams.Sort((x, y) => y.NgayKetThuc.CompareTo(x.NgayBatDau)); // Sắp xếp giảm dần theo Năm Bắt Đầu
            nams.Insert(0, new NamHocDTO { MaNamHoc = "", TenNamHoc = "-Năm học-" });
            cbbNamHoc.DataSource = nams;
            cbbNamHoc.DisplayMember = "TenNamHoc";
            cbbNamHoc.ValueMember = "MaNamHoc";
        }


        // ====================================================================
        // HÀM ĐÃ ĐƯỢC TỐI ƯU HÓA (LOẠI BỎ LỖI N+1 QUERY)
        // ====================================================================
        private void SetUpGunaChart(string maHocKy)
        {
            string[] diems = { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10" };

            // Chart configuration 
            chart.YAxes.GridLines.Display = false;

            // Create a new dataset 
            var Diem = new Guna.Charts.WinForms.GunaLineDataset();
            Diem.Label = "Phổ điểm học sinh theo học kỳ";
            Diem.PointRadius = 10;
            Diem.PointStyle = PointStyle.Circle;

            // === BẮT ĐẦU TỐI ƯU HÓA ===

            // 1. Lấy TẤT CẢ dữ liệu cần thiết CHỈ MỘT LẦN (hoặc 2 lần)
            var allHocSinh = HocSinhBLL.Instance.GetAllHocSinh();
            var allDiem = DiemBLL.Instance.GetAllDiem(); // Lấy tất cả điểm

            // 2. Lọc và Tính toán điểm TBC của học sinh cho học kỳ này (TRONG BỘ NHỚ)
            //    (Logic này tương tự hàm LoadHocSinhGioi của bạn)
            var diemTrungBinhList = (from hs in allHocSinh
                                     join d in allDiem on hs.MaHocSinh equals d.MaHocSinh
                                     where d.MaHocKy == maHocKy // Chỉ lọc điểm của học kỳ này
                                     group d by hs.MaHocSinh into g
                                     select g.Average(x => x.DiemTongKet) // Tính TBC
                                ).ToList();

            // 3. Đếm số lượng TỪ DANH SÁCH BỘ NHỚ (Rất nhanh)
            for (int i = 0; i < diems.Length; i++)
            {
                int diem = i + 1;
                int count = 0;

                // Thay vì lặp (HocSinh * DB Call),
                // chúng ta lặp qua danh sách TBC (đã tính ở trên)
                foreach (float d in diemTrungBinhList)
                {
                    // Logic làm tròn điểm của bạn
                    if (d >= diem - 0.5 && d <= diem + 0.5)
                    {
                        count++;
                    }
                }
                Diem.DataPoints.Add(diems[i], count);
            }
            // === KẾT THÚC TỐI ƯU HÓA ===


            // Trước khi add vào chart, nên xóa các dataset cũ đi để tránh bị chồng lấn nếu hàm này chạy nhiều lần
            chart.Datasets.Clear();
            chart.Datasets.Add(Diem);

            // An update was made to re-render the chart
            chart.Update();
        }

       

        private void cbbNamHoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbbNamHoc.SelectedIndex == 0)
            {
                cbbHocKy.DataSource = null;
                HocKyDTO hocKyHienTai = HocKyBLL.Instance.GetCurrentNamHoc();
                SetUpGunaChart(hocKyHienTai.MaHocKy);
                grThongKe.Text = "Học kì hiện tại";
                return;
            }
            // Cập nhật danh sách lớp theo năm học được chọn


            cbbHocKy.DataSource = null;
            string maNamHoc = cbbNamHoc.SelectedValue.ToString();
            List<HocKyDTO> hockys = HocKyBLL.Instance.GetHocKyByNamHoc(maNamHoc);
            hockys.Sort((x, y) => string.Compare(x.TenHocKy, y.TenHocKy)); // Sắp xếp tăng dần theo Tên Học Kỳ
            hockys.Insert(0, new HocKyDTO { MaHocKy = "", TenHocKy = "-Chọn học kỳ-" });
            cbbHocKy.DataSource = hockys;
            cbbHocKy.DisplayMember = "TenHocKy";
            cbbHocKy.ValueMember = "MaHocKy";

        }

        private void cbbHocKy_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void guna2ImageButton1_Click(object sender, EventArgs e)
        {
            if (cbbNamHoc.SelectedIndex == 0 || cbbHocKy.SelectedIndex == 0)
            {
                MessageBox.Show("Vui lòng chọn năm học và học kỳ để thống kê");
                return;
            }
            string maHocKy = cbbHocKy.SelectedValue.ToString();
            SetUpGunaChart(maHocKy);
        }

        private void btnLoc_Click(object sender, EventArgs e)
        {
            if (cbbNamHoc.SelectedIndex == 0 || cbbHocKy.SelectedIndex == 0)
            {
                MessageBox.Show("Vui lòng chọn năm học và học kỳ để thống kê");
                return;
            }
            string maHocKy = cbbHocKy.SelectedValue.ToString();
            string tenHocKy = cbbHocKy.Text;
            grThongKe.Text = tenHocKy;
            SetUpGunaChart(maHocKy);
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics,
        panel1.ClientRectangle,
        Color.White, 2, ButtonBorderStyle.Solid,
        Color.White, 0, ButtonBorderStyle.Solid,
        Color.White, 0, ButtonBorderStyle.Solid,
        Color.White, 0, ButtonBorderStyle.Solid);
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void danhSáchHọcSinhToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void tabControl1_Selected(object sender, TabControlEventArgs e)
        {
            
        }

        private void tabThongKe_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void tabThongKe_Click(object sender, EventArgs e)
        {

        }

        private void tabPage2_Click(object sender, EventArgs e)
        {
            
        }

        private void danhSáchMônHọcToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //frmBaoCaoMH frm = new frmBaoCaoMH();
            //frm.MdiParent = this.MdiParent;
            //frm.Show();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            
            Utilities.ShowForm("frmBaoCaoMH", pnBaoCao);
   

        }

        private void btnBaoCaoHS_Click(object sender, EventArgs e)
        {
           
            Utilities.ShowForm("frmReportMonHoc", pnBaoCao);
        }

        private void btnDSHS_Click(object sender, EventArgs e)
        {
            
            Utilities.ShowForm("frmBaoCaoDSHS", pnBaoCao);
        }

        private void btnDiemCaNam_Click(object sender, EventArgs e)
        {
            Utilities.ShowForm("frmKQHSCaNam", pnBaoCao);
        }

        private void btnBaoCaoHK_Click(object sender, EventArgs e)
        {
            Utilities.ShowForm("frmKQLHHocKy", pnBaoCao);
        }
    }
}