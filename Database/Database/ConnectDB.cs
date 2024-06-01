using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Database
{
    class ConnectDB
    {
        SqlConnection conn;
        SqlCommand sqlCommand;
        public SqlConnection Moketnoi()
        {
            string ketnoi = @"Data Source=DESKTOP-TEOF11\SQLEXPRESS;Initial Catalog=QuanLyNhanVien;Integrated Security=True";
            conn = new SqlConnection(ketnoi);
            conn.Open();
            return conn;

        }
        public void Dongketnoi()
        {
            conn.Close();
        }
        public void ShowAllNhanVien(DataGridView dg)
        {
            string sqlQuery = "SELECT * FROM NhanVien";
            SqlDataAdapter sqlAdapter = new SqlDataAdapter(sqlQuery, Moketnoi());
            DataSet ds = new DataSet();
            sqlAdapter.Fill(ds);
            dg.DataSource = ds.Tables[0];
            Dongketnoi();

        }
        
        public void AddSinhVien(TextBox txtid, TextBox txtname, DateTimePicker date, String sex, TextBox txtaddress, TextBox txtphonenumber)
        {
            string insertQuery = @"INSERT INTO NhanVien(MaNV, TenNV, NgaySinh, GioiTinh, DiaChi, SDT) VALUES ('" + txtid.Text + "','" + txtname.Text + "','" + date.Text + "','" + sex + "','" + txtaddress.Text + "','" + txtphonenumber.Text + "')";
            
            sqlCommand = new SqlCommand(insertQuery, Moketnoi());
            sqlCommand.ExecuteNonQuery();
            Dongketnoi();
        }

        public void ModifierSinhVien(TextBox txtid, TextBox txtname, DateTimePicker date, string sex, TextBox txtaddress, TextBox txtphonenumber)
        {
            string updateQuery = @"UPDATE NhanVien SET TenNV = '" + txtname.Text + "', NgaySinh = '" + date.Text + "', GioiTinh = '" + sex + "', DiaChi = '" + txtaddress.Text + "', SDT = '" + txtphonenumber.Text + "' WHERE MaNV ='" + txtid.Text+ "'";
            sqlCommand = new SqlCommand(updateQuery, Moketnoi());
            sqlCommand.ExecuteNonQuery();
            Dongketnoi();

        }
        public void DeleteSinhVien(TextBox txtid)
        { 
            
            string deleteQuery = @"DELETE FROM NhanVien WHERE MaNV= '" + txtid.Text + "'";
            sqlCommand = new SqlCommand(deleteQuery, Moketnoi());
            sqlCommand.ExecuteNonQuery();
            Dongketnoi();
        }

        // Update (Save)
        
    }
}
