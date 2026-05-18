using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace qlikho
{
    public partial class Form1 : Form
    {
        List<DoAnThucUong> danhSachKho = new List<DoAnThucUong>();

        void hienThiLenGrid()
        {
            dgvKho.DataSource = null;
            dgvKho.DataSource = danhSachKho;
        }

        public Form1()
        {
            InitializeComponent();
            danhSachKho.Add(new DoAnThucUong { maDoAn = "DA01", tenDoAn = "Bim bim", loaiDoAn = "Đồ ăn vặt", giaTien = 15000, soLuongTon = 50 });
            hienThiLenGrid();
        }

        private void textBox1_TextChanged(object sender, EventArgs e) { }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e) { }
        private void label1_Click(object sender, EventArgs e) { }

        // --- XỬ LÝ NÚT THÊM ---
        private void btnThem_Click(object sender, EventArgs e) { themMon(); }
        private void btnThem_Click_1(object sender, EventArgs e) { themMon(); }

        void themMon()
        {
            try
            {
                var monMoi = new DoAnThucUong
                {
                    maDoAn = txtMa.Text,
                    tenDoAn = txtTen.Text,
                    loaiDoAn = cboLoai.Text,
                    giaTien = decimal.Parse(txtGia.Text),
                    soLuongTon = int.Parse(txtSoLuong.Text)
                };
                danhSachKho.Add(monMoi);
                hienThiLenGrid();
            }
            catch
            {
                MessageBox.Show("Nhập sai! Giá và Số lượng bắt buộc phải là số hợp lệ.", "Báo lỗi");
            }
        }
        private void btnSua_Click(object sender, EventArgs e) { suaMon(); }
        private void btnSua_Click_1(object sender, EventArgs e) { suaMon(); }

        void suaMon()
        {
            try
            {
                var monCanSua = danhSachKho.FirstOrDefault(x => x.maDoAn == txtMa.Text);
                if (monCanSua != null)
                {
                    monCanSua.tenDoAn = txtTen.Text;
                    monCanSua.loaiDoAn = cboLoai.Text;
                    monCanSua.giaTien = decimal.Parse(txtGia.Text);
                    monCanSua.soLuongTon = int.Parse(txtSoLuong.Text);
                    hienThiLenGrid();
                }
                else
                {
                    MessageBox.Show("Không tìm thấy mã đồ ăn này để sửa!");
                }
            }
            catch
            {
                MessageBox.Show("Nhập sai! Giá và Số lượng bắt buộc phải là số hợp lệ.", "Báo lỗi");
            }
        }

        private void btnXoa_Click(object sender, EventArgs e) { xoaMon(); }
        private void btnXoa_Click_1(object sender, EventArgs e) { xoaMon(); }

        void xoaMon()
        {
            var monCanXoa = danhSachKho.FirstOrDefault(x => x.maDoAn == txtMa.Text);
            if (monCanXoa != null)
            {
                danhSachKho.Remove(monCanXoa);
                hienThiLenGrid();
            }
            else
            {
                MessageBox.Show("Không tìm thấy mã đồ ăn này để xóa!");
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void txtGia_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}