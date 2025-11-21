using BLL;
using DTO;
using FontAwesome.Sharp;
using GUI.frmQLDiemHS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;
namespace GUI
{
    public partial class FrmQLDiemHS : Form
    {
        public FrmQLDiemHS()
        {
            InitializeComponent();
            panel1.Resize += panel1_Resize;
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }
        private void CenterControlInPanel()
        {
            lblTieuDe.Left = (panel1.Width - lblTieuDe.Width) / 2;

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
        private void panel1_Resize(object sender, EventArgs e)
        {
            CenterControlInPanel();
        }
        private void frmQLDiemHS_Load(object sender, EventArgs e)
        {
            CapNhatThongTinDiemHS();
            CapNhatNamHoc();

        }

        private void CapNhatNamHoc()
        {
            List<NamHocDTO> nams = NamHocBLL.Instance.GetAllNamHoc();
            nams.Sort((x, y) => y.NgayKetThuc.CompareTo(x.NgayBatDau)); // Sắp xếp giảm dần theo Năm Bắt Đầu
            nams.Insert(0, new NamHocDTO { MaNamHoc = "", TenNamHoc = "-Tất cả-" });
            cbbNamHoc.DataSource = nams;
            cbbNamHoc.DisplayMember = "TenNamHoc";
            cbbNamHoc.ValueMember = "MaNamHoc";

        }

        private void CapNhatThongTinDiemHS()
        {
            dgvDanhSach.DataSource = HocSinhBLL.Instance.GetAllHocSinh();
            DatTieuDeCot();
        }

        private void DatTieuDeCot()
        {
            // Đặt lại tiêu đề cột (HeaderText)
            dgvDanhSach.Columns["MaHocSinh"].HeaderText = "Mã học sinh";
            dgvDanhSach.Columns["HoTen"].HeaderText = "Họ và tên";
            dgvDanhSach.Columns["NgaySinh"].HeaderText = "Ngày sinh";
            dgvDanhSach.Columns["GioiTinh"].HeaderText = "Giới tính";
            dgvDanhSach.Columns["DiaChi"].HeaderText = "Địa chỉ";
            dgvDanhSach.Columns["Email"].HeaderText = "Email";
            dgvDanhSach.Columns["MaLop"].HeaderText = "Lớp";
            dgvDanhSach.Columns["TrangThai"].HeaderText = "Trạng thái";
        }


        private void dgvDanhSach_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                string maHocSinh = dgvDanhSach.Rows[e.RowIndex].Cells["MaHocSinh"].Value.ToString();
                GUI.frmQLDiemHS.frmChiTietDiemHocSinh chiTietDiemForm = new GUI.frmQLDiemHS.frmChiTietDiemHocSinh(HocSinhBLL.Instance.GetHocSinhByMa(maHocSinh));
                chiTietDiemForm.ShowDialog();
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes == MessageBox.Show("Thoát", "Bạn có muốn thoát không ? ", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
            {
                this.Close();
            }
        }





        private void btnIn_Click(object sender, EventArgs e)
        {
            //if(dgvDanhSach.Rows.Count ==0)
            //{
            //    MessageBox.Show("Không có dữ liệu để in","Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Information);
            //    return;
            //}
            //InExcel();
        }

        private void lblTieuDe_Click(object sender, EventArgs e)
        {

        }

        private void btnLoc_Click_1(object sender, EventArgs e)
        {
            if (txttMaHS.Text != "")
            {
                HocSinhDTO hs = HocSinhBLL.Instance.GetHocSinhByMa((txttMaHS.Text.ToString().Trim()));
                if (hs != null)
                {
                    List<HocSinhDTO> hsList = new List<HocSinhDTO>();
                    hsList.Add(hs);
                    dgvDanhSach.DataSource = hsList;
                    return;
                }
                else
                {
                    MessageBox.Show(this, "Không tìm thấy học sinh với mã đã nhập ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CapNhatThongTinDiemHS();
                    return;
                }

            }

            else
            {
                MessageBox.Show(this, "Vui lòng nhập mã học sinh để tìm kiếm ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CapNhatThongTinDiemHS();
                return;
            }
        }

        private void cbbLop_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbbLop.SelectedIndex == 0)
            {
                dgvDanhSach.DataSource = null;
                return;
            }

            string maLop = cbbLop.SelectedValue.ToString();
            if (maLop != "")
            {
                dgvDanhSach.DataSource = HocSinhBLL.Instance.GetHocSinhByLop(maLop);
            }
            else
            {
                CapNhatThongTinDiemHS();
            }

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbbNamHoc.SelectedIndex == 0)
            {
                CapNhatThongTinDiemHS();
                //
                cbbLop.SelectedIndexChanged -= cbbLop_SelectedIndexChanged;
                // Xóa dữ liệu trong cbbLop
                cbbLop.DataSource = null;
                cbbLop.SelectedIndexChanged += cbbLop_SelectedIndexChanged;
                return;
            }
            // Cập nhật danh sách lớp theo năm học được chọn

            // ngat su kien SelectedIndexChanged de tranh goi de quy
            cbbLop.SelectedIndexChanged -= cbbLop_SelectedIndexChanged;
            cbbLop.DataSource = null;
            string maNamHoc = cbbNamHoc.SelectedValue.ToString();
            List<LopDTO> lops = LopBLL.Instance.GetLopByNamHoc(maNamHoc);
            lops.Sort((x, y) => string.Compare(x.TenLop, y.TenLop)); // Sắp xếp tăng dần theo Tên Lớp
            lops.Insert(0, new LopDTO { MaLop = "", TenLop = "-Chọn lớp-" });
            cbbLop.DataSource = lops;
            cbbLop.DisplayMember = "TenLop";
            cbbLop.ValueMember = "MaLop";
            // đăng ký lại sự kiện SelectedIndexChanged
            cbbLop.SelectedIndexChanged += cbbLop_SelectedIndexChanged;

            // Lọc danh sách học sinh theo năm học
            dgvDanhSach.DataSource = HocSinhBLL.Instance.GetHocSinhByNamHoc(maNamHoc);

        }

        private void btnReload_Click_1(object sender, EventArgs e)
        {
            cbbNamHoc.SelectedIndex = 0;
            cbbLop.DataSource = null;
            txttMaHS.Text = "";
            CapNhatThongTinDiemHS();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
