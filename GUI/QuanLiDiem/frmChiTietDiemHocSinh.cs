using BLL;
using DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;
namespace GUI.frmQLDiemHS
{
    public partial class frmChiTietDiemHocSinh : Form
    {
        private HocSinhDTO hocSinh;
        public List<DiemDTO> diems;
        public frmChiTietDiemHocSinh(HocSinhDTO hocSinh)
        {
            InitializeComponent();
            this.hocSinh = hocSinh;
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void frmChiTietDiemHocSinh_Load(object sender, EventArgs e)
        {
            txtHoTen.Text = hocSinh.HoTen;
            txtLop.Text = LopBLL.Instance.GetLopByMa(hocSinh.MaLop).TenLop;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            CapNhatDiem();
            CapNhatCBB();
            SetUpToolTip();
            
        }

        private void SetUpToolTip()
        {
            // Thiết lập một số tùy chọn (không bắt buộc)
            toolTip1.AutoPopDelay = 4000;   // hiện trong 5 giây
            toolTip1.InitialDelay = 1000;   // sau 1 giây mới hiện
            toolTip1.ReshowDelay = 500;     // thời gian giữa các lần hover
            toolTip1.ShowAlways = true;     // hiển thị ngay cả khi buttn bị disable


        }

        private void CapNhatCBB()
        {
            //NAMHOC
           
            //nhap thong tin
            List<NamHocDTO> nams = NamHocBLL.Instance.GetAllNamHoc();
            nams.Sort((x, y) => y.NgayKetThuc.CompareTo(x.NgayBatDau)); // Sắp xếp giảm dần theo Năm Bắt Đầu
            nams.Insert(0, new NamHocDTO
            {
                MaNamHoc = "",
                TenNamHoc = "-- Chọn năm học --"
            });
            cbbNamHoc.DataSource = nams;
            cbbNamHoc.DisplayMember = "TenNamHoc";  // Cái hiện ra
            cbbNamHoc.ValueMember = "MaNamHoc";      // Giá trị thật
            //tim kiem
            cbbtNamHoc.DataSource = nams;
            cbbtNamHoc.DisplayMember = "TenNamHoc";  // Cái hiện ra
            cbbtNamHoc.ValueMember = "MaNamHoc";      // Giá trị thật
            
            
            // MON HOC
            List<MonHocDTO> mons = MonHocBLL.Instance.GetAllMonHoc();
            mons.Sort((x, y) => string.Compare(x.TenMonHoc, y.TenMonHoc));
            mons.Insert(0, new MonHocDTO
            {
                MaMonHoc = "",
                TenMonHoc = "-- Chọn môn học --"
            });
            cbbMonHoc.DataSource = mons;
            cbbMonHoc.DisplayMember = "TenMonHoc";  // Cái hiện ra
            cbbMonHoc.ValueMember = "MaMonHoc";      // Giá trị thật
          
        }

        private void CapNhatDiem()
        {
            dgvDiem.Rows.Clear();
            diems = DiemBLL.Instance.GetDiemByHocSinh(hocSinh.MaHocSinh);
            foreach (DiemDTO d in diems)
            {

                dgvDiem.Rows.Add(d.DiemTrenLop, d.DiemGiuaKy, d.DiemThi, d.DiemTongKet,
                    MonHocBLL.Instance.GetMonHocByMa(d.MaMonHoc).TenMonHoc, // lay tên môn học
                    HocKyBLL.Instance.GetHocKyById(d.MaHocKy).TenHocKy, // lay tên học kỳ
                    NamHocBLL.Instance.GetNamHocByMa(HocKyBLL.Instance.GetHocKyById(d.MaHocKy).MaNamHoc).TenNamHoc, // lay tên năm học
                    d.MaDiem
                    );
            }

        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            CapNhatDiem();
            CapNhatCBB();
            LamMoiTxt();
        }

        private void LamMoiTxt()
        {
            txtDiemCuoiKy.Text = "";
            txtDiemGiuaKy.Text = "";
            txtDiemTrenLop.Text = "";
            cbbHocKy.Text = "";
            cbbMonHoc.Text = "";
        }
        int index = -1;
        private void dgvDiem_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                index = e.RowIndex;
                txtDiemTrenLop.Text = dgvDiem.Rows[index].Cells[0].Value.ToString();
                txtDiemGiuaKy.Text = dgvDiem.Rows[index].Cells[1].Value.ToString();
                txtDiemCuoiKy.Text = dgvDiem.Rows[index].Cells[2].Value.ToString();

                string tenMon = dgvDiem.Rows[index].Cells[4].Value.ToString();
                cbbMonHoc.SelectedIndex = cbbMonHoc.FindStringExact(tenMon);

                string tenHocKy = dgvDiem.Rows[index].Cells[5].Value.ToString();
                cbbHocKy.SelectedIndex = cbbHocKy.FindStringExact(tenHocKy);

                string maNamHoc = dgvDiem.Rows[index].Cells[6].Value.ToString();
                cbbNamHoc.SelectedIndex = cbbNamHoc.FindStringExact(maNamHoc);

                cbbNamHoc.Enabled = false;
                btnSua.Enabled = true;
                btnXoa.Enabled = true;
                btnThem.Enabled = false;
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {

            try
            {
                string maMonHoc = cbbMonHoc.SelectedValue.ToString();
                string maHocKy = cbbHocKy.SelectedValue.ToString();
                DiemDTO diemDTO = new DiemDTO();
                diemDTO.MaMonHoc = maMonHoc;
                diemDTO.MaHocKy = maHocKy;
                diemDTO.MaHocSinh = hocSinh.MaHocSinh;
                diemDTO.DiemGiuaKy = float.Parse(txtDiemGiuaKy.Text.ToString());
                diemDTO.DiemTrenLop = float.Parse(txtDiemTrenLop.Text.ToString());
                diemDTO.DiemThi = float.Parse(txtDiemCuoiKy.Text.ToString());
                diemDTO.TinhDiemTongKet();
                bool r = DiemBLL.Instance.InsertDiem(diemDTO);
                if (r)
                {
                    MessageBox.Show(this, "Thêm điểm thành công!");
                    CapNhatDiem();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(this, "Thêm điểm thất bại!");
                Console.WriteLine(ex.Message);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (index != -1)
            {
                try
                {
                    DataGridViewRow row = dgvDiem.Rows[index];
                    string maHocKy = cbbHocKy.SelectedValue.ToString();
                    string maMonHoc = cbbMonHoc.SelectedValue.ToString();
                    DiemDTO diem = new DiemDTO
                    {
                        MaDiem = row.Cells[7].Value.ToString(),
                        MaHocSinh = hocSinh.MaHocSinh,
                        MaHocKy = maHocKy,
                        MaMonHoc = maMonHoc,
                        DiemTrenLop = float.Parse(txtDiemTrenLop.Text),
                        DiemGiuaKy = float.Parse(txtDiemGiuaKy.Text),
                        DiemThi = float.Parse(txtDiemCuoiKy.Text),

                    };
                    diem.TinhDiemTongKet();
                    bool result = DiemBLL.Instance.UpdateDiem(diem);
                    if (result)
                    {
                        MessageBox.Show(this, "Cập nhật điểm thành công!");
                        CapNhatDiem();
                    }
                    else
                    {
                        MessageBox.Show(this, "Cập nhật điểm thất bại!");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(this, "Lỗi: " + ex.Message);
                }
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (index != -1)
            {

                try
                {
                    if (DialogResult.Yes == MessageBox.Show("Bạn có chắc muốn xóa không ?", "Xóa điểm ?", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                    {
                        string maHocKy = cbbHocKy.SelectedValue.ToString();
                        string maMonHoc = cbbMonHoc.SelectedValue.ToString();
                        if (DiemBLL.Instance.DeleteDiem(diems.FirstOrDefault(d => d.MaMonHoc == maMonHoc && d.MaHocKy == maHocKy).MaDiem))
                        {
                            MessageBox.Show(this, "Đã xóa thành công", "Thông báo !", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }

                        CapNhatDiem();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(this, "Lỗi: " + ex.Message);
                }
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes == MessageBox.Show(this, "Bạn có muốn thoát không ?", "Thoát", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
            {
                this.Close();
            }
        }

        private void dgvDiem_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            CapNhatDiem();
            CapNhatCBB();
            LamMoiTxt();
            cbbNamHoc.Enabled = true;
            btnThem.Enabled = true;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            if (dgvDiem.Rows.Count > 0)
            {
                // Khởi tạo ứng dụng Excel
                Excel.Application exApp = new Excel.Application();
                Excel.Workbook exBook = exApp.Workbooks.Add(Excel.XlWBATemplate.xlWBATWorksheet);
                Excel.Worksheet exSheet = (Excel.Worksheet)exBook.Worksheets[1];
                try
                {

                    // Đặt tên cho sheet
                    Excel.Range tenCuaHang = (Excel.Range)exSheet.Cells[1, 1];
                    tenCuaHang.Font.Size = 12;
                    tenCuaHang.Font.Bold = true;
                    tenCuaHang.Font.Color = Color.Blue;
                    tenCuaHang.Value = "Trường THPT Mường Bi";

                    Excel.Range tenhs = (Excel.Range)exSheet.Cells[2, 1];
                    tenhs.Font.Size = 12;
                    tenhs.Font.Bold = true;
                    tenhs.Font.Color = Color.Blue;
                    tenhs.Value = " Họ và tên :" + hocSinh.HoTen;
                    // Địa chỉ
                    Excel.Range header = (Excel.Range)exSheet.Cells[5, 2];
                    exSheet.get_Range("B5:G5").Merge(true);
                    header.Font.Size = 13;
                    header.Font.Bold = true;
                    header.Font.Color = Color.Red;
                    header.Value = "BẢNG ĐIỂM";
                    // setup cột tiêu đề
                    exSheet.get_Range("A7:G7").Font.Bold = true;
                    exSheet.get_Range("A7:G7").HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                    exSheet.get_Range("A7").Value = "STT";
                    exSheet.get_Range("B7").Value = "Mã môn học";
                    exSheet.get_Range("C7").Value = "Tên Môn học";
                    exSheet.get_Range("C7").ColumnWidth = 20;
                    exSheet.get_Range("D7").Value = "Điểm trên lớp";
                    exSheet.get_Range("E7").Value = "Điểm giữa kỳ";
                    exSheet.get_Range("F7").Value = "Điểm thi";
                    exSheet.get_Range("G7").Value = "Điểm tổng kết";
                    for (int i = 0; i < dgvDiem.Rows.Count; i++)
                    {
                        exSheet.get_Range("A" + (i + 8).ToString()).Value = (i + 1).ToString();
                        exSheet.get_Range("B" + (i + 8).ToString()).Value = diems[i].MaMonHoc;
                        exSheet.get_Range("C" + (i + 8).ToString()).Value = MonHocBLL.Instance.GetMonHocByMa(diems[i].MaMonHoc).TenMonHoc;
                        exSheet.get_Range("D" + (i + 8).ToString()).Value = diems[i].DiemTrenLop;
                        exSheet.get_Range("E" + (i + 8).ToString()).Value = diems[i].DiemGiuaKy;
                        exSheet.get_Range("F" + (i + 8).ToString()).Value = diems[i].DiemThi;
                        exSheet.get_Range("G" + (i + 8).ToString()).Value = diems[i].DiemTongKet;
                    }
                    exSheet.Name = "Hang";
                    exBook.Activate();
                    using (SaveFileDialog dlgSave = new SaveFileDialog())
                    {
                        dlgSave.Filter = "Excel Workbook (*.xlsx)|*.xlsx|Excel 97-2003 (*.xls)|*.xls|All files (*.*)|*.*";
                        dlgSave.FilterIndex = 1;
                        dlgSave.AddExtension = true;
                        dlgSave.DefaultExt = ".xlsx";

                        if (dlgSave.ShowDialog() == DialogResult.OK)
                        {
                            string filename = dlgSave.FileName;
                            // nếu chọn .xlsx -> lưu theo định dạng openxml
                            if (System.IO.Path.GetExtension(filename).ToLower() == ".xlsx")
                            {
                                exBook.SaveAs(filename, Excel.XlFileFormat.xlOpenXMLWorkbook);
                            }
                            else
                            {
                                exBook.SaveAs(filename, Excel.XlFileFormat.xlWorkbookNormal);
                            }
                            MessageBox.Show("Lưu file thành công: " + filename);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(this, "Lỗi: " + ex.Message);
                }
                finally
                {
                    // Đóng & release COM objects
                    try { if (exBook != null) { exBook.Close(false); Marshal.ReleaseComObject(exBook); exBook = null; } } catch { }
                    try { if (exApp != null) { exApp.Quit(); Marshal.ReleaseComObject(exApp); exApp = null; } } catch { }
                    if (exSheet != null) { Marshal.ReleaseComObject(exSheet); exSheet = null; }

                    GC.Collect();
                    GC.WaitForPendingFinalizers();
                }
            }
            else
            {
                MessageBox.Show(this, "Không có dữ liệu để in!");
            }
        }

        private void btnLoc_Click(object sender, EventArgs e)
        {
            if (cbbtHocKy.SelectedIndex == 0 && cbbtNamHoc.SelectedIndex > 0)
            {
                string maNamHoc = cbbtNamHoc.SelectedValue.ToString();
                dgvDiem.Rows.Clear();
                List<DiemDTO> diemhks = DiemBLL.Instance.GetDiemByHocSinhNamHoc(hocSinh.MaHocSinh, maNamHoc);
                foreach (DiemDTO d in diemhks)
                {

                    dgvDiem.Rows.Add(d.DiemTrenLop, d.DiemGiuaKy, d.DiemThi, d.DiemTongKet,
                        MonHocBLL.Instance.GetMonHocByMa(d.MaMonHoc).TenMonHoc, // lay tên môn học
                        HocKyBLL.Instance.GetHocKyById(d.MaHocKy).TenHocKy, // lay tên học kỳ
                        NamHocBLL.Instance.GetNamHocByMa(HocKyBLL.Instance.GetHocKyById(d.MaHocKy).MaNamHoc).TenNamHoc, // lay tên năm học
                        d.MaDiem
                        );
                }

            }
            else if(cbbtHocKy.SelectedIndex > 0  )
            {
                string maHocKy = cbbtHocKy.SelectedValue.ToString();
                dgvDiem.Rows.Clear();
                List<DiemDTO> diemhks = DiemBLL.Instance.GetDiemByHocSinhHocKy(hocSinh.MaHocSinh, maHocKy);
                foreach (DiemDTO d in diemhks)
                {

                    dgvDiem.Rows.Add(d.DiemTrenLop, d.DiemGiuaKy, d.DiemThi, d.DiemTongKet,
                        MonHocBLL.Instance.GetMonHocByMa(d.MaMonHoc).TenMonHoc, // lay tên môn học
                        HocKyBLL.Instance.GetHocKyById(d.MaHocKy).TenHocKy, // lay tên học kỳ
                        NamHocBLL.Instance.GetNamHocByMa(HocKyBLL.Instance.GetHocKyById(d.MaHocKy).MaNamHoc).TenNamHoc, // lay tên năm học
                        d.MaDiem
                        );
                }
            }
            else  
            {
                MessageBox.Show(this, "Vui lòng chọn học kỳ để lọc!");
            }
            
        }

        private void cbbNamHoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            //fix loi khi load form gan datasoure vao cbb thi no se tu dong kich hoat su kien nay
            if (cbbtNamHoc.SelectedValue == null) return;
            if (cbbtNamHoc.SelectedItem != null)
            {
                cbbtHocKy.DataSource = null;
                string maNamHoc = cbbtNamHoc.SelectedValue.ToString();
                List<HocKyDTO> hocKys = HocKyBLL.Instance.GetHocKyByNamHoc(maNamHoc);
                hocKys.Sort((x, y) => string.Compare(x.TenHocKy, y.TenHocKy));
                hocKys.Insert(0, new HocKyDTO
                {
                    MaHocKy = "",
                    TenHocKy = "-- Chọn học kỳ --"
                });
                cbbtHocKy.DataSource = hocKys;
                cbbtHocKy.DisplayMember = "TenHocKy";
                cbbtHocKy.ValueMember = "MaHocKy";
                cbbHocKy.SelectedIndex = 0;
            }
            else
            {
                MessageBox.Show(this, "Vui lòng chọn năm học để lọc!");
            }
        }

        private void toolTip1_Popup(object sender, PopupEventArgs e)
        {

        }

        private void cbbNamHoc_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (cbbNamHoc.SelectedValue == null) return;
            if (cbbNamHoc.SelectedItem != null)
            {
                cbbHocKy.DataSource = null;
                string maNamHoc = cbbNamHoc.SelectedValue.ToString();
                List<HocKyDTO> hocKys = HocKyBLL.Instance.GetHocKyByNamHoc(maNamHoc);
                hocKys.Sort((x, y) => string.Compare(x.TenHocKy, y.TenHocKy));
                hocKys.Insert(0, new HocKyDTO
                {
                    MaHocKy = "",
                    TenHocKy = "-- Chọn Học Kỳ --"
                });
                cbbHocKy.DataSource = hocKys;
                cbbHocKy.DisplayMember = "TenHocKy";
                cbbHocKy.ValueMember = "MaHocKy";
                cbbHocKy.SelectedIndex = 0;
            }
            return;
        }
    }
}
