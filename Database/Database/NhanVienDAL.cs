using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.ComponentModel;

namespace Database
{
    // DAL Stands for : Data Access Layer
    
    class NhanVienDAL
    {
        SqlDataAdapter da;
        DataConnection dc;
        SqlCommand cmd;
       public NhanVienDAL()
        {
            dc = new DataConnection();
        }
        public DataSet getAllNV()
        {
            string sql = "select * from NhanVien";
            SqlConnection caunoi = dc.getconnect();
            da = new SqlDataAdapter(sql, caunoi);
            caunoi.Open();
            DataSet dt = new DataSet();
            da.Fill(dt);
            caunoi.Close();
            return dt;
        }
        public bool ThemNV(tblNhanvien nv)
        {
            string sql = "INSERT INTO NhanVien(MaNV, TenNV, NgaySinh, GioiTinh, DiaChi, SDT) VALUES (@MaNV, @TenNV, @NgaySinh, @GioiTinh, @DiaChi, @SDT)";
            SqlConnection caunoi = dc.getconnect();
            try
            {
                cmd = new SqlCommand(sql, caunoi);
                caunoi.Open();
                cmd.Parameters.Add("@MaNV", SqlDbType.NVarChar).Value = nv.MaNV;
                cmd.Parameters.Add("@TenNV", SqlDbType.NVarChar).Value = nv.TenNV;
                cmd.Parameters.Add("@NgaySinh", SqlDbType.DateTime).Value = nv.NgaySinh;
                cmd.Parameters.Add("@GioiTinh", SqlDbType.NVarChar).Value = nv.GioiTinh;
                cmd.Parameters.Add("@DiaChi", SqlDbType.NVarChar).Value = nv.Diachi;
                cmd.Parameters.Add("@SDT", SqlDbType.Int).Value = nv.SDT;
                cmd.ExecuteNonQuery();
                caunoi.Close();
            }
            catch (Exception e)
            {
                return false;
            }
            return true;
        }
        public bool SuaNV(tblNhanvien nv)
        {
            string sql = "UPDATE NhanVien SET MaNV = @MaNV, TenNV = @MaNV, NgaySinh = @NgaySinh, GioiTinh = @GioiTinh, DiaChi = @DiaChi, SDT = @SDT) VALUES (@MaNV, @TenNV, @NgaySinh, @GioiTinh, @DiaChi, @SDT)";
            SqlConnection caunoi = dc.getconnect();
            try
            {
                cmd = new SqlCommand(sql, caunoi);
                caunoi.Open();
                cmd.Parameters.Add("@MaNV", SqlDbType.NVarChar).Value = nv.MaNV;
                cmd.Parameters.Add("@TenNV", SqlDbType.NVarChar).Value = nv.TenNV;
                cmd.Parameters.Add("@NgaySinh", SqlDbType.DateTime).Value = nv.NgaySinh;
                cmd.Parameters.Add("@GioiTinh", SqlDbType.NVarChar).Value = nv.GioiTinh;
                cmd.Parameters.Add("@DiaChi", SqlDbType.NVarChar).Value = nv.Diachi;
                cmd.Parameters.Add("@SDT", SqlDbType.Int).Value = nv.SDT;
                cmd.ExecuteNonQuery();
                caunoi.Close();
            }
            catch (Exception e)
            {
                return false;
            }
            return true;
        }
        public bool XoaNV(tblNhanvien nv) {
            string sql = "DELETE NhanVien WHERE MaNV = @MaNV";
            SqlConnection caunoi = dc.getconnect();

            try
            {
                cmd = new SqlCommand(sql, caunoi);
                caunoi.Open();
                cmd.Parameters.Add("@MaNV", SqlDbType.NVarChar).Value = nv.MaNV;
                cmd.ExecuteNonQuery();
                caunoi.Close();
            }
            catch (Exception e)
            {
                return false;
            }
            return true;
        }

    }
   
}
