using BLL;
using DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI.QLThongTinHocSinh
{
    public partial class frmTimKiemHocSinh : Form
    {
        private frmQLThongTinHocSinh parentForm;
        public frmTimKiemHocSinh(frmQLThongTinHocSinh parent)
        {
            InitializeComponent();
            parentForm = parent;

        }

        private void frmTimKiemHocSinh_Load(object sender, EventArgs e)
        {
            An();
            LoadGioiTinh();
            LoadTrangThai();
        }

        

        private void cbMaHS_CheckedChanged(object sender, EventArgs e)
        {
            if (cbMaHS.Checked)
            {
                txtMaHS.Enabled = true;
            }
            else
            {
                txtMaHS.Enabled = false;
            }
        }

        private void cbHoTen_CheckedChanged(object sender, EventArgs e)
        {
            if (cbHoTen.Checked)
            {
                txtHoTen.Enabled = true;
            }
            else
            {
                txtHoTen.Enabled = false;
            }
        }

        private void cbNgaySinh_CheckedChanged(object sender, EventArgs e)
        {
            if (cbNgaySinh.Checked)
            {
                dtpNgaySinh.Enabled = true;
            }
            else
            {
                dtpNgaySinh.Enabled = false;
            }
        }

        private void cbGioiTinh_CheckedChanged(object sender, EventArgs e)
        {
            if (cbGioiTinh.Checked)
            {
                cbbGioiTinh.Enabled = true;
            }
            else
            {
                cbbGioiTinh.Enabled = false;
            }
        }

        private void cbDiaChi_CheckedChanged(object sender, EventArgs e)
        {
            if (cbDiaChi.Checked)
            {
                txtDiaChi.Enabled = true;
            }
            else
            {
                txtDiaChi.Enabled = false;
            }
        }

        

        private void cbTrangThai_CheckedChanged(object sender, EventArgs e)
        {
            if (cbTrangThai.Checked)
            {
                cbbTrangThai.Enabled = true;
            }
            else
            {
                cbbTrangThai.Enabled = false;
            }
        }

        private void An()
        {
            txtMaHS.Enabled = false;
            txtHoTen.Enabled = false;
            dtpNgaySinh.Enabled = false;
            cbbGioiTinh.Enabled = false;
            txtDiaChi.Enabled = false;
            cbbTrangThai.Enabled = false;
        }


        private void LoadGioiTinh()
        {
            cbbGioiTinh.Items.Clear();
            cbbGioiTinh.Items.AddRange(new object[] { "Nam", "Nữ" });
            cbbGioiTinh.SelectedIndex = 0;
        }

        private void LoadTrangThai()
        {
            cbbTrangThai.Items.Clear();
            cbbTrangThai.Items.AddRange(new object[] { "Đang học", "Đã nghỉ học" });
            cbbTrangThai.SelectedIndex = 0;
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            var listHS = HocSinhBLL.Instance.GetAllHocSinh(); // lấy toàn bộ học sinh
            IEnumerable<HocSinhDTO> ketQua = listHS;

            if (cbMaHS.Checked && !string.IsNullOrEmpty(txtMaHS.Text))
                ketQua = ketQua.Where(h => h.MaHocSinh.Contains(txtMaHS.Text.Trim()));

            if (cbHoTen.Checked && !string.IsNullOrEmpty(txtHoTen.Text))
                ketQua = ketQua.Where(h => h.HoTen.ToLower().Contains(txtHoTen.Text.Trim().ToLower()));

            if (cbNgaySinh.Checked)
                ketQua = ketQua.Where(h => h.NgaySinh.Date == dtpNgaySinh.Value.Date);

            if (cbGioiTinh.Checked)
                ketQua = ketQua.Where(h => h.GioiTinh == cbbGioiTinh.SelectedItem.ToString());

            if (cbDiaChi.Checked && !string.IsNullOrEmpty(txtDiaChi.Text))
                ketQua = ketQua.Where(h => h.DiaChi.ToLower().Contains(txtDiaChi.Text.Trim().ToLower()));

            if (cbTrangThai.Checked)
            {
                string trangThaiChon = cbbTrangThai.SelectedItem.ToString().Trim();
                ketQua = ketQua.Where(h =>
                {
                    string tt = (h.TrangThai ?? "").Trim().ToLower();

                    bool isDangHoc = (tt == "1" || tt == "true");
                    bool isDaNghi = (tt == "0" || tt == "false");

                    return (trangThaiChon == "Đang học" && isDangHoc) ||
                           (trangThaiChon == "Đã nghỉ học" && isDaNghi);
                });
            }

            // Chuyển kết quả sang DataTable để gán cho dgv ở form cha
            DataTable dt = new DataTable();
            dt.Columns.Add("MaHocSinh");
            dt.Columns.Add("HoTen");
            dt.Columns.Add("GioiTinh");
            dt.Columns.Add("NgaySinh");
            dt.Columns.Add("DiaChi");
            dt.Columns.Add("Email");
            dt.Columns.Add("MaLop");
            dt.Columns.Add("TrangThai");

            foreach (var hs in ketQua)
            {
                dt.Rows.Add(hs.MaHocSinh, hs.HoTen, hs.GioiTinh, hs.NgaySinh.ToShortDateString(),
                            hs.DiaChi, hs.Email, hs.MaLop, hs.TrangThai);
            }

            // Gán dữ liệu cho DataGridView của form cha
            parentForm.DgvHocSinh.DataSource = dt;

            this.Close();
        }

        private void cbLop_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void cbbGioiTinh_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
