using BLL;
using DTO;
using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class frmQuanLyMonHoc : Form
    {
        public frmQuanLyMonHoc()
        {
            InitializeComponent();
        }

        private void StyleGunaButton(Guna2Button btn)
        {
            Color mainColor = Color.FromArgb(138, 101, 241);

            btn.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            btn.ForeColor = mainColor;
            btn.FillColor = Color.White;
            btn.BorderRadius = 10;
            btn.Size = new Size(130, 40);
            btn.BorderColor = mainColor;
            btn.BorderThickness = 1;
            btn.Cursor = Cursors.Hand;

            btn.HoverState.FillColor = mainColor;    
            btn.HoverState.ForeColor = Color.White;   
        }

        private void LoadData()
        {
            dgvMonHoc.DataSource = MonHocBLL.Instance.GetAllMonHoc();
        }

        private void enableText()
        {
            txtMaMon.Enabled = true;
            txtGhiChu.Enabled = true;
            txtTenMon.Enabled = true;
            txtHeSo.Enabled = true;
        }

        private void unenableText()
        {
            txtMaMon.Enabled = false;
            txtGhiChu.Enabled = false;
            txtTenMon.Enabled = false;
            txtHeSo.Enabled = false;
        }

        private void enableButton()
        {
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
        }

        private void unenableButton()
        {
            btnSua.Enabled = false;
            btnXoa.Enabled = false;  
        }

        private void clear()
        {
            txtMaMon.Text = "";
            txtTenMon.Text = "";
            txtHeSo.Text = "";
            txtGhiChu.Text = "";
        }

        public string GenerateMaMonHoc()
        {
            List<MonHocDTO> list = MonHocBLL.Instance.GetAllMonHoc();
            int next = list.Count + 1;
            string str = "";
            for (int i = 0;i < 6 - next.ToString().Length;i++)
            {
                str += '0';
            }    
            return "MH"+ str + next;
        }

        private void fQuanLyMonHoc_Load(object sender, EventArgs e)
        {
            LoadData();
        
            unenableText();
            unenableButton();
            btnThemMoi.Enabled = false;
            StyleGunaButton(btnThem);
            StyleGunaButton(btnThemMoi);
            StyleGunaButton(btnSua);
            StyleGunaButton(btnXoa);
        }

        private void dgvMonHoc_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex >= 0)
            {
                DataGridViewRow dt = dgvMonHoc.Rows[e.RowIndex];
                txtMaMon.Text = dt.Cells[0].Value.ToString();
                txtTenMon.Text = dt.Cells[1].Value.ToString();
                txtHeSo.Text = dt.Cells[2].Value.ToString();
                txtGhiChu.Text = dt.Cells[3].Value.ToString();
            }
            enableText();
            enableButton();
            btnThemMoi.Enabled=false;
        }

        private void btnThemMoi_Click(object sender, EventArgs e)
        {
            MonHocDTO newmh = new MonHocDTO(txtMaMon.Text, txtTenMon.Text, int.Parse(txtHeSo.Text), txtGhiChu.Text);
            MonHocBLL.Instance.InsertMonHoc(newmh);
            clear();
            unenableText();
            LoadData();
            btnThemMoi.Enabled = false;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            enableText();
            clear();
            txtMaMon.Text = GenerateMaMonHoc();
            unenableButton();
            btnThemMoi.Enabled = true;
            dgvMonHoc.ClearSelection();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (txtGhiChu.Text == null) txtGhiChu.Text = "";
            MonHocDTO newmh = new MonHocDTO(txtMaMon.Text, txtTenMon.Text, int.Parse(txtHeSo.Text), txtGhiChu.Text);
            DialogResult result = MessageBox.Show("Bạn chắc chắn muốn sửa ?", "Xác nhận", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (result == DialogResult.OK)
            {
                MonHocBLL.Instance.UpdateMonHoc(newmh);
                clear();
                LoadData();
                unenableText();
                unenableButton();
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn chắc chắn muốn xóa ?", "Xác nhận", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (result == DialogResult.OK)
            {
                try
                {
                    MonHocBLL.Instance.DeleteMonHoc(txtMaMon.Text);
                    clear();
                    LoadData();
                    unenableText();
                    unenableButton();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Không thể xóa môn học này!\nLý do: " + "Môn học đang được giảng dạy", "Lỗi", 
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }    
        }

        private void dgvMonHoc_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dgvMonHoc.ClearSelection();
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
    }
}
