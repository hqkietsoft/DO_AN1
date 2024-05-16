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

        public DataTable getDSSanPham()
        {
            string sql = "select sp.MaSP, sp.TenSP, sp.DonViTinh, lh.MaLoai, sp.TenNSX, sp.DonGia, pn.SoLuongNhap, pn.GiaNhap, pb.SoLuongBan, pb.GiaBan from SanPham as sp, ChiTietPhieuNhap as pn, ChiTietHoaDon as pb, LoaiHang as lh where sp.MaSP = pb.MaSP and lh.MaLoai = sp.MaLoai";
            SqlCommand cmd = new SqlCommand(sql, Moketnoi());
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable bang = new DataTable();
            bang.Load(dr);
            Dongketnoi();
            return bang;
        }
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
    }
}
