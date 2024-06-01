using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DO_AN_1
{
    public partial class QuanLyBanHang : DevExpress.XtraEditors.XtraForm
    {
        KetnoiCSDL conndb;
        DataTable table;
        int index;
        public QuanLyBanHang()
        {
            InitializeComponent();
            conndb = new KetnoiCSDL();
            cbo_manv.DropDown += new EventHandler(cbo_manv_DropDown);
            cbo_manv.DropDownClosed += new EventHandler(cbo_manv_DropDownClosed);
            table = new DataTable();

        }
        public class Employee
        {
            public string MaNV { get; set; }
            public string TenNV { get; set; }

            public Employee(string maNV, string tenNV)
            {
                MaNV = maNV;
                TenNV = tenNV;
            }
            // hiển thị mã + tên
            public override string ToString()
            {
                return $"{MaNV} - {TenNV}";
            }
        }
        private void QuanLyBanHang_Load(object sender, EventArgs e)
        {

            cbo_manv.Text = "---Chọn mã NV---";
            foreach (DataRow item in conndb.laydulieuNguoiDung().Rows)
            {
                var employee = new Employee(item["MaNV"].ToString(), item["HoTen"].ToString());
                cbo_manv.Items.Add(employee);

            }
            cbo_makh.Text = "---Chọn mã KH---";
            foreach (DataRow item in conndb.laydulieuKhachHang().Rows)
            {

                cbo_makh.Items.Add(item[0]);
            }
            cbo_masp.Text = "---Chọn mã SP---";
            foreach (DataRow item in conndb.laydulieuSanPham().Rows)
            {

                cbo_masp.Items.Add(item[0]);
            }
            conndb.HienthiLenDGV(dgv_ttdonhang);

            cbo_manv_cn.Text = "---Chọn mã NV---";
            foreach (DataRow item in conndb.laydulieuNguoiDung().Rows)
            {
                cbo_manv_cn.Items.Add(item[2]);

            }
            cbo_makh_cn.Text = "---Chọn mã KH---";
            foreach (DataRow item in conndb.laydulieuKhachHang().Rows)
            {

                cbo_makh_cn.Items.Add(item[0]);
            }
            cbo_masp_cn.Text = "---Chọn mã SP---";
            foreach (DataRow item in conndb.laydulieuSanPham().Rows)
            {

                cbo_masp_cn.Items.Add(item[0]);
            }
            conndb.HienthiLenDGV(dgv_ttdonhang);

            btnthemhd.Enabled = false;
            txt_mahd.Enabled = false;
            cbo_manv.Enabled = false;
            dtp_ngaylap.Enabled = false;
            cbo_makh.Enabled = false;
            txt_tenkh.Enabled = false;
            txt_diachi.Enabled = false;
            txt_sdt.Enabled = false;
            cbo_masp.Enabled = false;
            txt_tensp.Enabled = false;
            txt_nsx.Enabled = false;
            txt_sl.Enabled = false;
            txt_dvtinh.Enabled = false;
            txt_dongia.Enabled = false;
            txt_tongtien.Enabled = false;
            txt_ghichu.Enabled = false;

            // 
            table.Columns.Add("Mã sản phẩm", typeof(string));
            table.Columns.Add("Tên sản phẩm", typeof(string));
            table.Columns.Add("Nhà sản xuất", typeof(string));
            table.Columns.Add("Số lượng", typeof(int));
            table.Columns.Add("Đơn vị tính", typeof(string));
            table.Columns.Add("Đơn giá", typeof(decimal));
            dgv_sanpham.DataSource = table;




            //
            txt_mahd_cn.Enabled = false;
            cbo_manv_cn.Enabled = false;
            cbo_makh_cn.Enabled = false;
            dtp_ngayban.Enabled = false;
            txt_dvtinh_cn.Enabled = false;
            txt_thanhtien.Enabled = false;
            txt_dg_cn.Enabled = false;
            cbo_masp_cn.Enabled = false;
            txt_sl_cn.Enabled = false;
            txt_ghichu_cn.Enabled = false;
            btnthemsp.Enabled = false;
            btnxoasp.Enabled = false;
            btnsuasp.Enabled = false;
            btnluusp.Enabled = false;
            txt_tongtien.ReadOnly = true;
        }

        public void ClearText()
        {
            txt_mahd.Text = "";
            cbo_manv.Text = "---Chọn mã NV---";
            dtp_ngaylap.Text = "";
            cbo_makh.Text = "---Chọn mã KH---";
            txt_tenkh.Text = "";
            txt_diachi.Text = "";
            txt_sdt.Text = "";
            cbo_masp.Text = "---Chọn mã SP---";
            txt_tensp.Text = "";
            txt_nsx.Text = "";
            txt_sl.Text = "";
            txt_dvtinh.Text = "";
            txt_dongia.Text = "";
            txt_tongtien.Text = "";
            txt_ghichu.Text = "";
        }

        bool Kiemtrarong()
        {
            if (txt_mahd.Text.Trim() == "") return false;
            if (cbo_manv.Text.Trim() == "") return false;
            if (dtp_ngaylap.Text.Trim() == "") return false;
            if (cbo_makh.Text.Trim() == "") return false;
            if (txt_tenkh.Text.Trim() == "") return false;
            if (txt_diachi.Text.Trim() == "") return false;
            if (txt_sdt.Text.Trim() == "") return false;
            
            
            return true;

        }


        private void btn_taohd_Click(object sender, EventArgs e)
        {
            ClearText();
            txt_mahd.ReadOnly = false;
            txt_mahd.Enabled = true;
            txt_mahd.Focus();
            cbo_manv.Enabled = true;
            dtp_ngaylap.Enabled = true;
            cbo_makh.Enabled = true;
            txt_tenkh.Enabled = true;
            txt_diachi.Enabled = true;
            txt_sdt.Enabled = true;
            cbo_masp.Enabled = true;
            txt_tensp.Enabled = true;
            txt_nsx.Enabled = true;
            txt_sl.Enabled = true;
            txt_dvtinh.Enabled = true;
            txt_dongia.Enabled = true;
            txt_tongtien.Enabled = true;
            txt_ghichu.Enabled = true;
            btnthemsp.Enabled = true;
            btnxoasp.Enabled = true;
            btnsuasp.Enabled = true;
            btnluusp.Enabled = true;
            txt_tensp.ReadOnly = true;
            txt_nsx.ReadOnly = true;
            txt_dvtinh.ReadOnly = true;
            txt_dongia.ReadOnly = true;
            txt_tenkh.ReadOnly = true;
            txt_diachi.ReadOnly = true;
            txt_sdt.ReadOnly = true;


        }



        private void btn_timkiemhd_Click(object sender, EventArgs e)
        {
            
            conndb.timkiemhoadon(dgv_thongtintkhd, dtp_ngaybatdautk, dtp_ngayketthuctk);
        }



        private void cbo_makh_SelectedIndexChanged(object sender, EventArgs e)
        {
            conndb.hienthithongtinKH(txt_tenkh, txt_diachi, txt_sdt, cbo_makh);
        }

        private void txt_mahd_TextChanged(object sender, EventArgs e)
        {
            if (txt_mahd.Text != "")
            {
                btnthemhd.Enabled = true;
            }

        }

        private void cbo_manv_DropDownClosed(object sender, EventArgs e)
        {
            cbo_manv.DisplayMember = "MaNV";
        }

        private void cbo_manv_DropDown(object sender, EventArgs e)
        {
            cbo_manv.DisplayMember = "ToString";
        }

        private void cbo_masp_SelectedIndexChanged(object sender, EventArgs e)
        {
            conndb.hienthithongtinSP(txt_tensp, txt_nsx, txt_dvtinh, txt_dongia, cbo_masp);
            txt_sl.Text = "1";
        }

        private void cbo_manv_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txt_sl_TextChanged(object sender, EventArgs e)
        {
            try
            {
                int sl = Convert.ToInt16(txt_sl.Text);
                if (txt_sl.Text != "" && sl >= 1)
                {
                    txt_dongia.Text = conndb.laydulieudongia(cbo_masp.Text).ToString();
                }
                else
                {
                    txt_dongia.Text = "0";
                }
            }
            catch (Exception ex)
            {

            }


        }


        private void txt_dongia_TextChanged(object sender, EventArgs e)
        {
            

        }


        public void clearText_sp()
        {
            cbo_masp.Text = "---Chọn mã sản phẩm mới---";
            txt_tensp.Text = "";
            txt_nsx.Text = "";
            txt_sl.Text = "";
            txt_dvtinh.Text = "";
            txt_dongia.Text = "";

        }
        public void tinhthanhtien()
        {
            decimal total = 0;
            foreach (DataGridViewRow row in dgv_sanpham.Rows)
            {

                if (!row.IsNewRow)
                {

                    decimal unitPrice = Convert.ToDecimal(row.Cells["Đơn giá"].Value);
                    int quantity = Convert.ToInt16(row.Cells["Số lượng"].Value);
                    total += unitPrice * quantity;
                }
            }
            txt_tongtien.Text = total.ToString();
        }
        public void tinhthanhtien2()
        {
            decimal total = 0;
            foreach (DataGridViewRow row in dgv_sp.Rows)
            {

                if (!row.IsNewRow)
                {

                    decimal unitPrice = Convert.ToDecimal(row.Cells["Đơn giá"].Value);
                    int quantity = Convert.ToInt16(row.Cells["Số lượng"].Value);
                    total += unitPrice * quantity;
                }
            }
            txt_thanhtien.Text = total.ToString();
        }
        private void btnthemsp_Click(object sender, EventArgs e)
        {
            
            if(cbo_masp.Text.Trim() == "")
            {
                MessageBox.Show("Bạn chưa chọn mã sản phẩm", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                int rowIndex = -1;
                foreach (DataGridViewRow row in dgv_sanpham.Rows)
                {
                    if (row.Cells["Mã sản phẩm"].Value != null && row.Cells["Mã sản phẩm"].Value.ToString().Equals(cbo_masp.Text))
                    {
                        rowIndex = row.Index;
                        break;
                    }
                }

                if (rowIndex >= 0)
                {
                    dgv_sanpham.Rows[rowIndex].Cells["Số lượng"].Value =
                        Convert.ToInt32(dgv_sanpham.Rows[rowIndex].Cells["Số lượng"].Value) + int.Parse(txt_sl.Text);
                }
                else
                {
                    table.Rows.Add(cbo_masp.Text, txt_tensp.Text, txt_nsx.Text, txt_sl.Text, txt_dvtinh.Text, txt_dongia.Text);
                }

                dgv_sanpham.Refresh();
                tinhthanhtien();
                clearText_sp();
            }
        }



        private void btnxoasp_Click(object sender, EventArgs e)
        {
            index = dgv_sanpham.CurrentCell.RowIndex;
            dgv_sanpham.Rows.RemoveAt(index);
            tinhthanhtien();

        }

        private void dgv_sanpham_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            DataGridViewRow row = new DataGridViewRow();
            row = dgv_sanpham.Rows[index];
            cbo_masp.Text = row.Cells[0].Value.ToString();
            txt_tensp.Text = row.Cells[1].Value.ToString();
            txt_nsx.Text = row.Cells[2].Value.ToString();
            txt_sl.Text = row.Cells[3].Value.ToString();
            txt_dvtinh.Text = row.Cells[4].Value.ToString();
            txt_dongia.Text = row.Cells[5].Value.ToString();
            cbo_masp.Enabled = false;
            txt_tensp.ReadOnly = true;
            txt_nsx.ReadOnly = true;
            txt_sl.ReadOnly = true;
            txt_dvtinh.ReadOnly = true;
            txt_dongia.ReadOnly = true;



        }

        private void btnsuasp_Click(object sender, EventArgs e)
        {
            
            txt_sl.ReadOnly = false;
            
            
        }

        private void btnluusp_Click(object sender, EventArgs e)
        {
            DataGridViewRow newdata = dgv_sanpham.Rows[index];
            newdata.Cells[1].Value = txt_tensp.Text;
            newdata.Cells[2].Value = txt_nsx.Text;
            newdata.Cells[3].Value = txt_sl.Text;
            newdata.Cells[4].Value = txt_dvtinh.Text;
            newdata.Cells[5].Value = txt_dongia.Text;
            tinhthanhtien();
        }

        // Sửa nút thêm khi thêm xong à cập nhật lại thông tin đơn hàng bên cập nhật đơn hàng
        private void btnthemhd_Click_1(object sender, EventArgs e)
        {
            if (!Kiemtrarong())
            {
                MessageBox.Show("Chưa nhập đủ thông tin !", "Thêm", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                if (conndb.kiemtratontaiID(txt_mahd.Text))
                {
                    MessageBox.Show("Mã hoá đơn này đã tồn tại!", "Tạo hoá đơn", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                conndb.ThemHoaDon(txt_mahd.Text, cbo_manv.Text, cbo_makh.Text, dtp_ngaylap.Text, txt_tongtien.Text);
                foreach (DataGridViewRow row in dgv_sanpham.Rows)
                {

                    if (!row.IsNewRow)
                    {

                        string masp = row.Cells["Mã sản phẩm"].Value.ToString();
                        conndb.themchitiethd(txt_mahd.Text, masp, txt_sl.Text, txt_dongia.Text, txt_ghichu.Text);
                    }
                }
                //conndb.HienthiLenDGV(dgv_sanpham);
                MessageBox.Show("Đã tạo hoá đơn thành công", "Tạo hoá đơn");

                conndb.HienthiLenDGV(dgv_ttdonhang);
                ClearText();
            }
        }



        private void dgv_ttdonhang_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                string mahoadon = dgv_ttdonhang.Rows[e.RowIndex].Cells[0].Value.ToString();
                txt_mahd_cn.Text = dgv_ttdonhang.Rows[e.RowIndex].Cells[0].Value.ToString();
                cbo_manv_cn.Text = dgv_ttdonhang.Rows[e.RowIndex].Cells[1].Value.ToString();
                cbo_makh_cn.Text = dgv_ttdonhang.Rows[e.RowIndex].Cells[2].Value.ToString();
                dtp_ngayban.Text = dgv_ttdonhang.Rows[e.RowIndex].Cells[3].Value.ToString();
                txt_thanhtien.Text = dgv_ttdonhang.Rows[e.RowIndex].Cells[4].Value.ToString();
                // Hiển thị các mã sản phẩm tương ứng
                conndb.LaydulieuSP(mahoadon, dgv_sp);
            }


        }

        private void dgv_sp_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                cbo_masp_cn.Text = dgv_sp.Rows[e.RowIndex].Cells[0].Value.ToString();
                txt_sl_cn.Text = dgv_sp.Rows[e.RowIndex].Cells[1].Value.ToString();
                txt_dvtinh_cn.Text = dgv_sp.Rows[e.RowIndex].Cells[2].Value.ToString();
                txt_dg_cn.Text = dgv_sp.Rows[e.RowIndex].Cells[3].Value.ToString();
                txt_ghichu_cn.Text = dgv_sp.Rows[e.RowIndex].Cells[4].Value.ToString();

            }
        }
        private void btnxoahd_Click_1(object sender, EventArgs e)
        {
            DialogResult ans = MessageBox.Show("Bạn có muốn xóa đơn hàng "+ txt_mahd_cn.Text + " không?", "Xóa đơn hàng", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if(ans == DialogResult.Yes)
            {
                conndb.xoahoadon(txt_mahd_cn.Text);
                conndb.HienthiLenDGV(dgv_ttdonhang);
                dgv_sp.Refresh();
            }
        }
        private void btnsuahd_Click_2(object sender, EventArgs e)
        {
            txt_mahd_cn.Enabled = true;
            cbo_manv_cn.Enabled = true;
            cbo_makh_cn.Enabled = true;
            dtp_ngayban.Enabled = true;
            txt_dvtinh_cn.Enabled = true;
            txt_thanhtien.Enabled = true;
            txt_dg_cn.Enabled = true;
            txt_sl_cn.Enabled = true;
            txt_ghichu_cn.Enabled = true;
            txt_mahd_cn.ReadOnly = true;
            txt_dvtinh_cn.ReadOnly = true;
            txt_thanhtien.ReadOnly = true;
            txt_dg_cn.ReadOnly = true;
            txt_sl_cn.ReadOnly = true;
            cbo_masp_cn.Enabled = false;


        }
        private void btnluuhd_Click(object sender, EventArgs e)
        {
            conndb.SuaHoaDon(txt_mahd_cn.Text, cbo_manv_cn.Text, cbo_makh_cn.Text, dtp_ngayban.Text, txt_thanhtien.Text, cbo_masp_cn.Text, txt_sl_cn.Text, txt_dg_cn.Text, txt_ghichu_cn.Text);
            conndb.HienthiLenDGV(dgv_ttdonhang);
            dgv_sp.Refresh(); 
            conndb.LaydulieuSP(txt_mahd_cn.Text, dgv_sanpham);
            
        }

        private void cbo_masp_cn_SelectedIndexChanged(object sender, EventArgs e)
        {
            conndb.hienthithongtinSP2(txt_dvtinh_cn, txt_dg_cn, cbo_masp_cn);
            txt_sl_cn.Text = "1";
        }

        private void txt_sl_cn_TextChanged(object sender, EventArgs e)
        {
            try
            {
                int sl = Convert.ToInt16(txt_sl_cn.Text);
                if (txt_sl_cn.Text != "" && sl >= 1)
                {
                    txt_dg_cn.Text = conndb.laydulieudongia(cbo_masp_cn.Text).ToString();
                    tinhthanhtien2();
                }
                else
                {
                    txt_dg_cn.Text = "0";
                    tinhthanhtien2();
                }
                
            }
            catch (Exception ex)
            {

            }
            
        }

        
    }
}