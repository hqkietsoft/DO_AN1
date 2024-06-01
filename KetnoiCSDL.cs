using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.Xpo.DB.Helpers;
using DevExpress.XtraEditors.Mask.Design;

namespace DO_AN_1
{
    internal class KetnoiCSDL
    {
        SqlConnection conn;
        SqlCommand cmd;
        public SqlConnection Moketnoi()
        {
            string connstr = "Data Source=(local);Initial Catalog=quanlykinhdoanhmaytinh;Integrated Security=True;Encrypt=False";
            conn = new SqlConnection(connstr);
            conn.Open();
            //if(conn.State == ConnectionState.Open)        
            //    MessageBox.Show("Kết nối thành công", "Kết nối", MessageBoxButtons.OK, MessageBoxIcon.Information);

            //else
            //    MessageBox.Show("Kết nối không thành công", "Kết nối", MessageBoxButtons.OK, MessageBoxIcon.Error);

            return conn;
        }
        public void Dongketnoi()
        {
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
                conn.Dispose();
                conn = null;

            }
        }

        // lay du lieu truy van tu sql
        public void LaydulieuSP(string mahoadon, DataGridView dgv1)
        {
            string selectAllQuery = "select ChiTietHoaDon.MaSP, SoLuong,GiaBan,SanPham.DonViTinh, GhiChu  from ChiTietHoaDon\r\ninner join SanPham on  SanPham.MaSP = ChiTietHoaDon.MaSP where MaHD = @mahd";
            cmd = new SqlCommand(selectAllQuery, Moketnoi());
            cmd.Parameters.AddWithValue("@mahd", mahoadon);
            SqlDataReader reader = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(reader);
            dgv1.DataSource = dt;
            
        }
        public DataTable ShowALL()
        {
            string selectAllQuery = "select * from HoaDon ";
            cmd = new SqlCommand(selectAllQuery, Moketnoi());
            SqlDataReader reader = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(reader);
            Dongketnoi();
            return dt;
        }

        public DataTable laydulieuNguoiDung()
        {
            string query = "select * from nguoidung";
            cmd = new SqlCommand(query, Moketnoi());
            SqlDataReader reader = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(reader);
            Dongketnoi();
            return dt;
        }
        public DataTable laydulieuKhachHang()
        {
            string query = "select * from KhachHang";
            cmd = new SqlCommand(query, Moketnoi());
            SqlDataReader reader = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(reader);
            Dongketnoi();
            return dt;
        }
        public DataTable laydulieuSanPham()
        {
            string query = "select * from SanPham";
            cmd = new SqlCommand(query, Moketnoi());
            SqlDataReader reader = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(reader);
            Dongketnoi();
            return dt;
        }
        public void HienthiLenDGV(DataGridView dgvmaytinh)
        {
            dgvmaytinh.DataSource = ShowALL();
        }
        public void ThemHoaDon(string mahd, string manv, string makh, string ngaylap, string tongtien)
        {
            string insertHDQuery = "insert into HoaDon values (@mahoadon,@manhanvien, @makhachhang, @ngayban, @thanhtien)";
            cmd = new SqlCommand(insertHDQuery, Moketnoi());
            cmd.Parameters.AddWithValue("@mahoadon", mahd);
            cmd.Parameters.AddWithValue("@manhanvien", manv);
            cmd.Parameters.AddWithValue("@makhachhang", makh);
            cmd.Parameters.AddWithValue("@ngayban", ngaylap);
            cmd.Parameters.AddWithValue("@thanhtien", tongtien);
            cmd.ExecuteNonQuery();
            Dongketnoi();
            
        }
        public void themchitiethd(string mahd, string masp, string sl, string dongia, string ghichu)
        {
            string insertCTHDQuery = "insert into ChiTietHoaDon values (@mahoadon, @masanpham, @soluong, @giaban, @ghichu)";

            SqlCommand cmd1 = new SqlCommand(insertCTHDQuery, Moketnoi());
            cmd1.Parameters.AddWithValue("@mahoadon", mahd);
            cmd1.Parameters.AddWithValue("@masanpham", masp);
            cmd1.Parameters.AddWithValue("@soluong", sl);
            cmd1.Parameters.AddWithValue("@giaban", dongia);
            cmd1.Parameters.AddWithValue("@ghichu", ghichu);
            cmd1.ExecuteNonQuery();
            Dongketnoi();
        }
        public void SuaHoaDon(string mahd, string manv, string makh, string ngaylap, string tongtien, string masp, string sl, string dongia, string ghichu)
        {
            string query = "update HoaDon set MaNV = @manv, MaKH = @makh, NgayLap = @ngaylap, TongTien = @TongTien where mahd = @mahd";
            string query2 = "update ChiTietHoaDon set MaSP = @masanpham, SoLuong = @soluong, GiaBan = @giaban, GhiChu = @ghichu where mahd = @mahd";
            SqlCommand cmd1 = new SqlCommand(query2, Moketnoi());
            cmd1.Parameters.AddWithValue("@mahd", mahd);
            cmd1.Parameters.AddWithValue("@masanpham", masp);
            cmd1.Parameters.AddWithValue("@soluong", sl);
            cmd1.Parameters.AddWithValue("@giaban", dongia);
            cmd1.Parameters.AddWithValue("@ghichu", ghichu);
            cmd1.ExecuteNonQuery();
            Dongketnoi();
            cmd = new SqlCommand(query, Moketnoi());
            cmd.Parameters.AddWithValue("@mahd", mahd);
            cmd.Parameters.AddWithValue("@manv", manv);
            cmd.Parameters.AddWithValue("@makh", makh);
            cmd.Parameters.AddWithValue("@ngaylap", ngaylap);
            cmd.Parameters.AddWithValue("@tongtien", tongtien);
            cmd.ExecuteNonQuery();
            Dongketnoi();
        }
        public void xoahoadon(string ma)
        {
            
            string queryCTHD = "delete from ChiTietHoaDon where MaHD = @ma";
            SqlCommand cmd2 = new SqlCommand(queryCTHD, Moketnoi());
            cmd2.Parameters.AddWithValue("@ma", ma);
            cmd2.ExecuteNonQuery();
            string queryHD = "delete from HoaDon where MaHD = @ma";
            cmd = new SqlCommand(queryHD, Moketnoi());
            cmd.Parameters.AddWithValue("@ma", ma);
            cmd.ExecuteNonQuery();

        }
        public bool kiemtratontaiID(string id)
        {
            bool ktraID = false;
            string IDquery = "select * from HoaDon where MaHD = '" + id + "'";
            cmd = new SqlCommand(IDquery, Moketnoi());
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
                ktraID = true;
            Dongketnoi();
            return ktraID;
        }



        // tim kiem hoa don
        public void timkiemhoadon(RadioButton rdomahd, RadioButton rdomanv, RadioButton rdomakh, TextBox tb1, DataGridView dgvtimkiemhd, DateTimePicker dtp1, DateTimePicker dtp2)
        {
            // tim kiem theo rdo duoc checked
            if (rdomahd.Checked == true)
            {
                string searchQuery = "select * from HoaDon where MaHD ='" + tb1.Text + "'" ;
                cmd = new SqlCommand(searchQuery, Moketnoi());
                SqlDataReader reader = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(reader);
                Dongketnoi();
                dgvtimkiemhd.DataSource = dt;
            }
            else if (rdomanv.Checked == true)
            {
                string searchQuery = "select * from HoaDon where MaNV ='" + tb1.Text + "'";
                cmd = new SqlCommand(searchQuery, Moketnoi());
                SqlDataReader reader = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(reader);
                Dongketnoi();
                dgvtimkiemhd.DataSource = dt;
            }
            else if (rdomakh.Checked == true)
            {
                string searchQuery = "select * from HoaDon where MaKH ='" + tb1.Text + "'";
                cmd = new SqlCommand(searchQuery, Moketnoi());
                SqlDataReader reader = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(reader);
                Dongketnoi();
                dgvtimkiemhd.DataSource = dt;
            }
            else
            {
                string searchQuery = "select * from HoaDon where NgayLap BETWEEN '" + dtp1.Text+ "' AND '"+ dtp2.Text+"'" ;
                cmd = new SqlCommand(searchQuery, Moketnoi());
                SqlDataReader reader = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(reader);
                Dongketnoi();
                dgvtimkiemhd.DataSource = dt;
            }
            


        }

        public void hienthithongtinSP2(TextBox tb3, TextBox tb4, ComboBox cbo1)
        {
            string ma = cbo1.SelectedItem.ToString();
            string query = "SELECT DonViTinh, DonGia FROM SanPham WHERE MaSP = @ma";
            cmd = new SqlCommand(query, Moketnoi());
            cmd.Parameters.AddWithValue("@ma", ma);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {

                tb3.Text = reader["DonViTinh"].ToString();
                tb4.Text = reader["DonGia"].ToString();

            }
            reader.Close();
        }
        public void hienthithongtinKH(TextBox tb1, TextBox tb2, TextBox tb3, ComboBox cbo1)
        {
            string makhachhang = cbo1.SelectedItem.ToString();
            string query = "SELECT HoTen, DiaChi,SĐT FROM KhachHang WHERE MaKH = @makhachhang";
            cmd = new SqlCommand(query, Moketnoi());
            cmd.Parameters.AddWithValue("@makhachhang", makhachhang);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                tb1.Text = reader["HoTen"].ToString();
                tb2.Text = reader["DiaChi"].ToString();
                tb3.Text = reader["SĐT"].ToString();
            }
            reader.Close();
        }
        public void hienthithongtinSP(TextBox tb1, TextBox tb2, TextBox tb3, TextBox tb4, ComboBox cbo1)
        {
            string ma = cbo1.SelectedItem.ToString();
            string query = "SELECT TenSP, TenNSX,DonViTinh, DonGia FROM SanPham WHERE MaSP = @ma";
            cmd = new SqlCommand(query, Moketnoi());
            cmd.Parameters.AddWithValue("@ma", ma);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                tb1.Text = reader["TenSP"].ToString();
                tb2.Text = reader["TenNSX"].ToString();
                tb3.Text = reader["DonViTinh"].ToString();
                tb4.Text = reader["DonGia"].ToString();

            }
            reader.Close();
        }
        public double laydulieudongia(string masanpham)
        {

            string sql = "SELECT DonGia FROM SanPham WHERE MaSP = @MaSP";
            cmd = new SqlCommand(sql, Moketnoi());
            cmd.Parameters.AddWithValue("@MaSP", masanpham);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                double dongia = reader.GetDouble(0);
                return dongia;
            }
            else
            {
                return -1;
            }     

        }
    }
}
   

