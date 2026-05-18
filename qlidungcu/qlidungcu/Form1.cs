using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace qlidungcu
{
    public partial class Form1 : Form
    {
        List<DungCu> danhSachDungCu = new List<DungCu>();

        void hienThiLenGrid()
        {
            dgvDungCu.DataSource = null;
            dgvDungCu.DataSource = danhSachDungCu;
        }

        public Form1()
        {
            InitializeComponent();
            danhSachDungCu.Add(new DungCu { maDungCu = "DC01", tenDungCu = "Micro Karaoke", soLuong = 5, trangThai = "Tốt" });
            hienThiLenGrid();
        }
        private void btnThem_Click(object sender, EventArgs e) { themDC(); }
        private void btnThem_Click_1(object sender, EventArgs e) { themDC(); }
        private void button1_Click(object sender, EventArgs e) { themDC(); }

        void themDC()
        {
            try
            {
                if (string.IsNullOrEmpty(txtMa.Text)) { MessageBox.Show("Chưa nhập mã!"); return; }
                var moi = new DungCu
                {
                    maDungCu = txtMa.Text,
                    tenDungCu = txtTen.Text,
                    soLuong = int.Parse(txtSoLuong.Text),
                    trangThai = cboTrangThai.Text
                };
                danhSachDungCu.Add(moi);
                hienThiLenGrid();
            }
            catch { MessageBox.Show("Nhập sai! Ô Số lượng bắt buộc phải gõ bằng số.", "Báo lỗi"); }
        }
        private void btnSua_Click(object sender, EventArgs e) { suaDC(); }
        private void btnSua_Click_1(object sender, EventArgs e) { suaDC(); }
        private void button2_Click(object sender, EventArgs e) { suaDC(); }

        void suaDC()
        {
            try
            {
                var dc = danhSachDungCu.FirstOrDefault(x => x.maDungCu == txtMa.Text);
                if (dc != null)
                {
                    dc.tenDungCu = txtTen.Text;
                    dc.soLuong = int.Parse(txtSoLuong.Text);
                    dc.trangThai = cboTrangThai.Text;
                    hienThiLenGrid();
                }
                else { MessageBox.Show("Không tìm thấy mã dụng cụ này để sửa!"); }
            }
            catch { MessageBox.Show("Nhập sai! Ô Số lượng bắt buộc phải gõ bằng số.", "Báo lỗi"); }
        }
        private void btnXoa_Click(object sender, EventArgs e) { xoaDC(); }
        private void btnXoa_Click_1(object sender, EventArgs e) { xoaDC(); }
        private void button3_Click(object sender, EventArgs e) { xoaDC(); }

        void xoaDC()
        {
            var dc = danhSachDungCu.FirstOrDefault(x => x.maDungCu == txtMa.Text);
            if (dc != null)
            {
                danhSachDungCu.Remove(dc);
                hienThiLenGrid();
            }
            else { MessageBox.Show("Không tìm thấy mã dụng cụ này để xóa!"); }
        }

        private void btnThem_Click_2(object sender, EventArgs e)
        {
            themDC();
        }

        private void btnSua_Click_2(object sender, EventArgs e)
        {
            suaDC();
        }

        private void Xóa_Click(object sender, EventArgs e)
        {
            xoaDC();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
    public class DungCu
    {
        public string maDungCu { get; set; }
        public string tenDungCu { get; set; }
        public int soLuong { get; set; }
        public string trangThai { get; set; }
    }
}