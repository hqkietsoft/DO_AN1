using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

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
            string sql = "select sp.MaSP, sp.TenSP, sp.DonViTinh, lh.MaLoai, sp.TenNSX, sp.DonGia, pn.SoLuongNhap, pn.GiaNhap, pb.SoLuongBan, pb.GiaBan, lh.TinhTrang, lh.MoTa from SanPham as sp, ChiTietPhieuNhap as pn, ChiTietHoaDon as pb, LoaiHang as lh where sp.MaSP = pb.MaSP and lh.MaLoai = sp.MaLoai";
            SqlCommand cmd = new SqlCommand(sql, Moketnoi());
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable bang = new DataTable();
            bang.Load(dr);
            Dongketnoi();
            return bang;
        }
    }
}
