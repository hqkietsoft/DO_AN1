using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DO_AN_1
{
    internal class TruyXuatCSDL
    {
        private static string DuongDan = @"Data Source=DAFF;Initial Catalog=quanLyKDLaptop;Integrated Security=True;Encrypt=False";

        // tạo ra một kết nối
        private static SqlConnection TaoKetNoi()
        {
            return new SqlConnection(DuongDan);
        }

        // lấy ra từ csdl một giá trị
        public static string LayMotGiaTriChuoi(string sql)
        {
            SqlConnection kn = TaoKetNoi();
            kn.Open();
            SqlCommand Lenh = new SqlCommand(sql, kn);
            object rs = Lenh.ExecuteScalar();
            kn.Close();
            Lenh.Dispose();
            if (rs != null)
                return rs.ToString();
            else
                return "";
        }

        public static int LayMotGiaTriNguyen(string sql)
        {
            SqlConnection kn = TaoKetNoi();
            kn.Open();
            SqlCommand Lenh = new SqlCommand(sql, kn);
            int rs = (int)Lenh.ExecuteScalar();
            kn.Close();
            Lenh.Dispose();
            if (rs != 0)
                return rs;
            else
                return 0;
        }

        public static double LayMotGiaTriDouble(string sql)
        {
            SqlConnection kn = TaoKetNoi();
            kn.Open();
            SqlCommand Lenh = new SqlCommand(sql, kn);
            double rs = (double)Lenh.ExecuteScalar();
            kn.Close();
            Lenh.Dispose();
            if (rs != 0)
                return rs;
            else
                return 0;
        }

        // lấy ra một bảng
        public static DataTable LayBang(string LayGi)
        {
            SqlConnection ODAU = TaoKetNoi();
            ODAU.Open();
            DataTable ThungChua = new DataTable();
            SqlDataAdapter MayBom = new SqlDataAdapter(LayGi, ODAU);
            MayBom.Fill(ThungChua);
            ODAU.Close();
            MayBom.Dispose();
            return ThungChua;
        }

    }
}
