using DevExpress.Xpo.DB.Helpers;
using DevExpress.XtraCharts.Designer.Native;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DO_AN_1
{
    class ConnData
    {
        static SqlConnection conn;
        public static SqlConnection Moketnoi()
        {
            string connstr = @"Data Source=(local);Initial Catalog=quanlykinhdoanhmaytinh;Integrated Security=True;Encrypt=False";
            conn = new SqlConnection(connstr);
            conn.Open();
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

        public static string GetConnectionString()
        {
            return @"Data Source=(local);Initial Catalog=quanlykinhdoanhmaytinh;Integrated Security=True;Encrypt=False";
        }

        public DataTable getQueryPhieuNH()
        {
            string selectAllQuery = "select * from PhieuNhapHang";
            SqlCommand cmd = new SqlCommand(selectAllQuery, Moketnoi());
            SqlDataReader reader = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(reader);
            Dongketnoi();
            return dt;
        }
        public DataTable getQueryDSPhieuN()
        {
            string selectAllQuery = "select [nd].[MaNV] , [sp].[MaSP],  sp.TenNSX , sp.TenSP , ctpn.SoLuong , sp.DonViTinh, \r\nctpn.GiaNhap , sp.DonGia  , ctpn.GhiChu from PhieuNhapHang as [pnh]\r\n, ChiTietPhieuNhapHang as [ctpn],NguoiDung as [nd], SanPham as [sp] \r\nwhere pnh.MaPhieu = ctpn.MaPhieu and nd.MaNV = pnh.MaNV and sp.MaSP = ctpn.MaSP;";
            SqlCommand cmd = new SqlCommand(selectAllQuery, Moketnoi());
            SqlDataReader reader = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(reader);
            Dongketnoi();
            return dt;
        }

        public DataTable displaySearch(string query, DateTime ngayTuNgay, DateTime ngayDenNgay)
        {
            
            DataTable ThungChua = new DataTable();

            using (SqlConnection conn = Moketnoi())
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.Add(new SqlParameter("@NgayTuNgay", SqlDbType.Date) { Value = ngayTuNgay });
                    cmd.Parameters.Add(new SqlParameter("@NgayDenNgay", SqlDbType.Date) { Value = ngayDenNgay });

                    using (SqlDataAdapter MayBom = new SqlDataAdapter(cmd))
                    {
                        MayBom.Fill(ThungChua);
                    }
                }
            }

            return ThungChua;
        }
        public DataTable displayDSHD(string query, params SqlParameter[] parameters)
        {
            using (SqlConnection conn = Moketnoi())
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddRange(parameters);
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        return dt;
                    }
                }
            }
        }
        public DataTable laydulieuNguoiDung()
        {
            SqlCommand cmd = new SqlCommand();
            string query = "select * from nguoidung";
            cmd = new SqlCommand(query, Moketnoi());
            SqlDataReader reader = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(reader);
            Dongketnoi();
            return dt;
        }

        public DataTable laydulieuSanPham()
        {
            SqlCommand cmd = new SqlCommand();
            string query = "select * from SanPham";
            cmd = new SqlCommand(query, Moketnoi());
            SqlDataReader reader = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(reader);
            Dongketnoi();
            return dt;
        }

        public DataTable laydulieuMaSanPham(string maSP)
        {
            SqlCommand cmd = new SqlCommand();
            string query = "SELECT TenSP, TenNSX , DonViTinh FROM SanPham WHERE MaSP = @MaSP";
            cmd = new SqlCommand(query, Moketnoi());
            cmd.Parameters.AddWithValue("@MaSP", maSP);
            SqlDataReader reader = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(reader);
            Dongketnoi();
            return dt;
        }

        public DataTable displayDSHD1(string query, params SqlParameter[] parameters)
        {
            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(@"Data Source=(local);Initial Catalog=quanlykinhdoanhmaytinh;Integrated Security=True;Encrypt=False"))
            {
                con.Open();

                // Tạo và thực thi SqlCommand với câu truy vấn SQL và tham số
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddRange(parameters);
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(dt);
                }

                con.Close();
            }
            return dt;
        }

        public void HienthiLenDGPN(DataGridView dgHoaDon)
        {
            dgHoaDon.DataSource = getQueryPhieuNH();
        }
        public void HienthiLenDGDSP(DataGridView dgHoaDon)
        {
            dgHoaDon.DataSource = getQueryDSPhieuN();
        }
        public void Do_sql()
        {

        }
    }
}