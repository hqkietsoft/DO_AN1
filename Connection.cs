using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
namespace DO_AN_1
{
    class Connection
    {
        SqlConnection conn;
        public SqlConnection Moketnoi()
        {
            string sql = @"Data Source=DESKTOP-EC4KK8E\SQLEXPRESS;Initial Catalog=QLKinhDoanh;Integrated Security=True";
            conn = new SqlConnection(sql);
            conn.Open();
            return conn;
        }

        public void Dongketnoi()
        {
            conn.Close();
        }

        /*-----------------------Code cho TabControl "CẬP NHẬT SẢN PHẨM"----------------*/

        public DataTable getDSSanPham()
        {
            string sql = "select sp.MaSP, sp.TenSP, sp.DonViTinh, lh.MaLoai, sp.TenNSX, sp.DonGia from SanPham as sp,LoaiHang as lh where lh.MaLoai = sp.MaLoai";
            SqlCommand cmd = new SqlCommand(sql, Moketnoi());
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable bangsp = new DataTable();
            bangsp.Load(dr);
            Dongketnoi();
            return bangsp;
        }

        //Hàm lấy dữ liệu hiển thị lên DataGridview
        public void layDLhienthilenCombobox(ComboBox cbo1,string query, string displaymemb)
        {
            string selectAllQuery = "select MaLoai from LoaiHang";
            SqlCommand cmd = new SqlCommand(query, Moketnoi());
            SqlDataReader reader = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(reader);
            Dongketnoi();
            cbo1.DisplayMember = displaymemb; // Tên cột mã khách hàng
            cbo1.DataSource = dt;
        }

        //Code ngày 17/5/2024

        //Hàm kiểm tra sản phẩm tồn tại sản phẩm
        public bool tontaiSP(string ma)
        {
            bool kt = false;
            Moketnoi();
            //kiểm tra theo mã 'tabcontrol cập nhật sản phẩm'
            string sql = "select *from SanPham where MaSP=@masp";
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("masp", ma);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows) kt = true;
            Dongketnoi();
            return kt;
        }

        //Hàm thêm sản phẩm
        public void themSanPham(string ma, string ten,string dvt,string maloai,string tennsx,string dongia)
        {
            Moketnoi();
            String sql = "insert into SanPham values (@masp,@tensp,@donvitinh,@maloai,@tennsx,@dongia)";
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("masp", ma);
            cmd.Parameters.AddWithValue("tensp", ten);
            cmd.Parameters.AddWithValue("donvitinh", dvt);
            cmd.Parameters.AddWithValue("maloai", maloai);
            cmd.Parameters.AddWithValue("tennsx", tennsx);
            cmd.Parameters.AddWithValue("dongia", dongia);
            cmd.ExecuteNonQuery();
            Dongketnoi();
        }

        // Hàm xoá sản phẩm.
        public bool xoaSP(string ma)
        {
            Moketnoi();
            bool kt = false;
            string sql = "delete SanPham where MaSP =@masp";
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("masp", ma);
            try
            {
                cmd.ExecuteNonQuery();
                kt = true;
            }catch(Exception e)
            {

            }
            Dongketnoi();
            return kt;
        }

        //Hàm cập nhật sản phẩm (Sửa)
        public void capnhatSanPham(string ma, string ten,string dvt, string maloai, string tennsx, string dongia)
        {
            Moketnoi();
            string sql = "update SanPham set TenSP=@tensp,DonViTinh=@donvitinh,MaLoai=@maloai,TenNSX=@tennsx,DonGia=@dongia where MaSP=@masp";
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("masp", ma);
            cmd.Parameters.AddWithValue("tensp", ten);
            cmd.Parameters.AddWithValue("donvitinh", dvt);
            cmd.Parameters.AddWithValue("maloai", maloai);
            cmd.Parameters.AddWithValue("tennsx", tennsx);
            cmd.Parameters.AddWithValue("dongia", dongia);
            cmd.ExecuteNonQuery();
            Dongketnoi();
        }



        /*--------------Code cho Tabcontrol "CẬP NHẬT LOẠI HÀNG"--------*/
        public DataTable getDSLoaiHang()
        {
            String sql = "select * from LoaiHang";
            SqlCommand cmd = new SqlCommand(sql, Moketnoi());
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable banglh = new DataTable();
            banglh.Load(dr);
            Dongketnoi();
            return banglh;
        }

        //Hàm kiểm tra tồn tại loại hàng
        public bool tontaiLH(string maloai)
        {
            bool kt = false;
            Moketnoi();
            //kiểm tra theo mã 'tabcontrol cập nhật loại hàng'
            string sql1 = "select * from LoaiHang where MaLoai=@maloai";
            SqlCommand cmd = new SqlCommand(sql1, conn);
            cmd.Parameters.AddWithValue("maloai", maloai);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows) kt = true;
            Dongketnoi();
            return kt;
        }

        //Hàm thêm loại hàng
        public void themLoaiHang(string maloai, string tenhang, string tinhtrang, string giaban, string soluong, string mota)
        {
            Moketnoi();
            String sql = "insert into LoaiHang values (@maloai,@tenhang,@tinhtrang,@giaban,@soluong,@mota)";
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("maloai", maloai);
            cmd.Parameters.AddWithValue("tenhang", tenhang);
            cmd.Parameters.AddWithValue("tinhtrang", tinhtrang);
            cmd.Parameters.AddWithValue("giaban", giaban);
            cmd.Parameters.AddWithValue("soluong", soluong);
            cmd.Parameters.AddWithValue("mota", mota);
            cmd.ExecuteNonQuery();
            Dongketnoi();
        }

        //Hàm cập nhạt loại hàng (Sửa)
        public void capnhatLoaiHang(string maloai, string tenhang, string tinhtrang, string giaban, string soluong, string mota)
        {
            Moketnoi();
            string sql = "update LoaiHang set TenHang=@tenhang,TinhTrang=@tinhtrang,GiaBan=@GiaBan,SoLuong=@soluong,MoTa=@mota where MaLoai=@maloai";
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("maloai", maloai);
            cmd.Parameters.AddWithValue("tenhang", tenhang);
            cmd.Parameters.AddWithValue("tinhtrang", tinhtrang);
            cmd.Parameters.AddWithValue("giaban", giaban);
            cmd.Parameters.AddWithValue("soluong", soluong);
            cmd.Parameters.AddWithValue("mota", mota);
            cmd.ExecuteNonQuery();
            Dongketnoi();
        }

        // Hàm xoá loại hàng.
        public bool xoaLoaiHang(string maloai)
        {
            Moketnoi();
            bool kt = false;
            string sql = "delete LoaiHang where MaLoai =@maloai";
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("maloai", maloai);
            try
            {
                cmd.ExecuteNonQuery();
                kt = true;
            }
            catch (Exception e)
            {

            }
            Dongketnoi();
            return kt;
        }
    }
}
