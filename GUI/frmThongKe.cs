using BLL;
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
                lblLopHoc.Text = tongLop.ToString();
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

        private void label_Click(object sender, EventArgs e)
        {

        }

        private void ExportToCSV(DataGridView dgv)
        {
            if (dgv.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu để xuất!", "Thông báo");
                return;
            }

            Excel.Application app = new Excel.Application();
            app.Visible = false;

            Excel.Workbook wb = app.Workbooks.Add(Type.Missing);
            Excel.Worksheet ws = wb.ActiveSheet;
            ws.Name = "DanhSachHSG";

            int row = 1;

            // ===== TIÊU ĐỀ CHÍNH =====
            ws.Cells[row, 2] = "TRƯỜNG THPT";
            ws.Cells[row, 2].Font.Bold = true;
            ws.Cells[row, 2].Font.Size = 16;
            row += 2;

            ws.Cells[row, 2] = "DANH SÁCH HỌC SINH GIỎI";
            ws.Cells[row, 2].Font.Bold = true;
            ws.Cells[row, 2].Font.Size = 14;

            ws.Range["B" + row, "F" + row].Merge();
            ws.Range["B" + row, "F" + row].HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

            row += 2;

            // ===== HEADER BẢNG =====
            ws.Cells[row, 2] = "MÃ HS";
            ws.Cells[row, 3] = "Họ tên";
            ws.Cells[row, 4] = "Lớp";
            ws.Cells[row, 5] = "Điểm tổng kết";
            ws.Cells[row, 6] = "Xếp loại";

            Excel.Range header = ws.Range["B" + row, "F" + row];
            header.Font.Bold = true;
            header.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.LightGray);
            header.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
            header.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;

            row++;

            // ===== GHI DỮ LIỆU =====
            for (int i = 0; i < dgv.Rows.Count; i++)
            {
                if (dgv.Rows[i].IsNewRow) continue;

                ws.Cells[row + i, 2] = dgv.Rows[i].Cells["MaHocSinh"].Value?.ToString();
                ws.Cells[row + i, 3] = dgv.Rows[i].Cells["HoTen"].Value?.ToString();
                ws.Cells[row + i, 4] = dgv.Rows[i].Cells["MaLop"].Value?.ToString();
                ws.Cells[row + i, 5] = dgv.Rows[i].Cells["DiemTongKet"].Value?.ToString();
                ws.Cells[row + i, 6] = dgv.Rows[i].Cells["XepLoai"].Value?.ToString();

                Excel.Range rowRange = ws.Range["B" + (row + i), "F" + (row + i)];
                rowRange.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
            }

            // ===== AUTO FIT =====
            ws.Columns.AutoFit();

            // ===== LƯU FILE =====
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Excel File (*.xlsx)|*.xlsx";
            sfd.FileName = "DanhSachHocSinhGioi.xlsx";

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                wb.SaveAs(sfd.FileName);
                MessageBox.Show("Xuất file Excel thành công!");
            }

            wb.Close();
            app.Quit();
        }


    private void btnXuatExcel_Click(object sender, EventArgs e)
        {
            ExportToCSV(dgvHocSinhGioi);
        }
    }
}
