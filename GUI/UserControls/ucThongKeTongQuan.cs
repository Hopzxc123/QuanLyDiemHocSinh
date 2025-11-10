using BLL;
using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
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

        private void label_Click(object sender, EventArgs e)
        {

        }

        private void ExportToCSV(DataGridView dgv)
        {
            if (dgv.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu để xuất!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            SaveFileDialog saveDialog = new SaveFileDialog();
            saveDialog.Filter = "CSV file (*.csv)|*.csv";
            saveDialog.FileName = "HocSinhGioi.csv";

            if (saveDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    using (StreamWriter sw = new StreamWriter(saveDialog.FileName, false, Encoding.UTF8))
                    {
                        // Ghi dòng tiêu đề (header)
                        for (int i = 0; i < dgv.Columns.Count; i++)
                        {
                            sw.Write(dgv.Columns[i].HeaderText);
                            if (i < dgv.Columns.Count - 1)
                                sw.Write(",");
                        }
                        sw.WriteLine();

                        // Ghi dữ liệu từng hàng
                        foreach (DataGridViewRow row in dgv.Rows)
                        {
                            // Bỏ qua dòng trống (nếu có)
                            if (row.IsNewRow) continue;

                            for (int i = 0; i < dgv.Columns.Count; i++)
                            {
                                var value = row.Cells[i].Value?.ToString();
                                // Nếu có dấu phẩy hoặc xuống dòng, bọc trong dấu ngoặc kép
                                if (value != null && (value.Contains(",") || value.Contains("\n")))
                                    value = $"\"{value}\"";

                                sw.Write(value);
                                if (i < dgv.Columns.Count - 1)
                                    sw.Write(",");
                            }
                            sw.WriteLine();
                        }
                    }

                    MessageBox.Show("Xuất file CSV thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi xuất CSV: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnXuatExcel_Click(object sender, EventArgs e)
        {
            ExportToCSV(dgvHocSinhGioi);
        }
    }
}