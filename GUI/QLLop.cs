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
    public partial class QLLop : Form
    {
        private void MaNganh()
        {
            cbMaNganh.Items.Add("IT");
            cbMaNganh.Items.Add("EE");
            cbMaNganh.Items.Add("CE");
        }
        public QLLop()
        {
            InitializeComponent();
            MaNganh();
        }
        bool validate()
        {
            bool kq = true;
            if (txtMaLop.Text.Trim().Length == 0) kq = false;
            if (txtTenLop.Text.Trim().Length == 0) kq = false;
            if (cbMaNganh.Text.Trim().Length == 0) kq = false;
            return kq;
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            if (!validate())
            {
                MessageBox.Show("Chưa nhập đủ thông tin", "Thông báo", MessageBoxButtons.OK);
            }
            else
            {
                ListViewItem list = new ListViewItem();
                list.Text = txtMaLop.Text;
                list.SubItems.Add(txtTenLop.Text);
                list.SubItems.Add(cbMaNganh.Text);
                lstDanhSach.Items.Add(list);
            } 
            txtMaLop.Clear();
            txtTenLop.Clear();
            cbMaNganh.SelectedIndex = -1;
                
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if(lstDanhSach.SelectedItems.Count > 0)
            {
                int i = lstDanhSach.SelectedItems[0].Index;
                lstDanhSach.Items[i].SubItems[0].Text = txtMaLop.Text;
                lstDanhSach.Items[i].SubItems[1].Text = txtTenLop.Text;
                lstDanhSach.Items[i].SubItems[2].Text = cbMaNganh.Text;
            }
            txtMaLop.Clear();
            txtTenLop.Clear();
            cbMaNganh.SelectedIndex = -1;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (lstDanhSach.SelectedItems.Count > 0)
            {
                lstDanhSach.Items.Remove(lstDanhSach.SelectedItems[0]);
            }
            txtMaLop.Clear();
            txtTenLop.Clear();
            cbMaNganh.SelectedIndex = -1;
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lstDanhSach_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstDanhSach.SelectedItems.Count > 0) 
            {
                ListViewItem i = lstDanhSach.SelectedItems[0];
                txtMaLop.Text = i.Text;
                txtTenLop.Text= i.SubItems[1].Text;
                cbMaNganh.Text = i.SubItems[2].Text;
            }
        }
    }
}
