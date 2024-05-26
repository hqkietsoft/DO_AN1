using DevExpress.Pdf.Native;
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
using System.Data.SqlClient;


namespace DO_AN_1
{
    public partial class QuanLyKhachHang : DevExpress.XtraEditors.XtraForm
    {
        SqlConnection sqlcon;
        DataSet ds;
        SqlDataAdapter sqlda;
        public QuanLyKhachHang()
        {
            InitializeComponent();
            ShowAll();
        }
        public void connect()
        {
            string ketnoi;
            ketnoi = "Data Source=DESKTOP-H2UCOT4\\SQLEXPRESS;Initial Catalog=QLKDMayTinh;Integrated Security=True";
            sqlcon = new SqlConnection(ketnoi);
            sqlcon.Open();
        }
        public void dongketnoi()
        {
            sqlcon.Close();
            sqlcon.Dispose();
        }
        public void ShowAll()
        {
            connect();
            string sql;
            sql = "SELECT * FROM KhachHang";       
            sqlda = new SqlDataAdapter(sql, sqlcon);
            ds = new DataSet();
            sqlda.Fill(ds);
            dgv1.DataSource = ds.Tables[0];
        }
        
        
        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                connect();
                string sql;
                sql = "update KhachHang set HoTen =@hoten, NamSinh=@ngaysinh, GioiTinh=@gioitinh, DiaChi=@diachi, SĐT=@sdt where MaKH=@makh";
                SqlCommand sqlcom = new SqlCommand(sql, sqlcon);
                sqlcom.Parameters.AddWithValue("@makh", txtMa.Text);
                sqlcom.Parameters.AddWithValue("@hoten", txtTenKH.Text);
                sqlcom.Parameters.AddWithValue("@ngaysinh", datetime.Value);
                sqlcom.Parameters.AddWithValue("@gioitinh", gioitinh());
                sqlcom.Parameters.AddWithValue("@diachi", txtDiachi.Text);
                sqlcom.Parameters.AddWithValue("@sdt", txtSDT.Text);
                int kq = sqlcom.ExecuteNonQuery();
                if (kq > 0)
                {
                    ShowAll();

                    MessageBox.Show("Bạn đã sửa thành công khách hàng!", "Thêm dữ liệu");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hệ thống báo lỗi: " + ex.Message);
            }
        }
        private void button4_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("Có chắc chắn thoát không?", "Thông báo", MessageBoxButtons.YesNo) == DialogResult.Yes)
                this.Dispose();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        public string gioitinh()
        {
                string gtinh;
                if (rbNam.Checked == true)
                {
                    gtinh = "Nam";
                }
                else
                {
                    gtinh = "Nữ";
                }
                return gtinh;
        }
        private void dgv1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMa.Text = dgv1.CurrentRow.Cells[0].Value.ToString();
            txtTenKH.Text = dgv1.CurrentRow.Cells[1].Value.ToString();
            datetime.Text = dgv1.CurrentRow.Cells[2].Value.ToString();
            if (dgv1.CurrentRow.Cells[3].Value.ToString() == "Nam")
            {
                rbNam.Checked = true;
            }
            else
            {
                rbNu.Checked = true;
            }
            txtDiachi.Text = dgv1.CurrentRow.Cells[4].Value.ToString();
            txtSDT.Text = dgv1.CurrentRow.Cells[5].Value.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult tl;
            tl = MessageBox.Show("Bạn có đồng ý xóa không? ", "Xóa dữ liệu", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (tl == DialogResult.OK)
            {
                try
                {
                    connect();
                    string sql;
                    sql = "delete from KhachHang where MaKH = @makh";
                    SqlCommand sqlcom = new SqlCommand(sql, sqlcon);
                    sqlcom.Parameters.AddWithValue("@makh", txtMa.Text);
                    int kq = sqlcom.ExecuteNonQuery();
                    if (kq > 0)
                    {
                        ShowAll();
                        MessageBox.Show("Bạn đã xóa thành công khách hàng", "Xoá dữ liệu");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hệ thống báo lỗi:" + ex.Message);
                }
            
        }
    }        
        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                connect();
                string ma = txtMa.Text;
                DateTime dt = datetime.Value;
                string sql;
                sql = "insert into KhachHang (MaKH, HoTen, NamSinh, GioiTinh, DiaChi, SĐT) values (@makh, @hoten, @namsinh, @gioitinh, @diachi, @sdt)";
                SqlCommand sqlcom = new SqlCommand(sql, sqlcon);
                sqlcom.Parameters.AddWithValue("@makh", ma);
                sqlcom.Parameters.AddWithValue("@hoten", txtTenKH.Text);
                sqlcom.Parameters.AddWithValue("@namsinh", dt);
                sqlcom.Parameters.AddWithValue("@gioitinh", gioitinh());
                sqlcom.Parameters.AddWithValue("@diachi", txtDiachi.Text);
                sqlcom.Parameters.AddWithValue("@sdt", txtSDT.Text);
                int kq = sqlcom.ExecuteNonQuery();
                if (kq > 0)
                {
                    ShowAll();
                    MessageBox.Show("Bạn đã thêm thành công khách hàng!", "Thêm dữ liệu");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hệ thống báo lỗi: " + ex.Message);
                
            }
        }

        private void QuanLyKhachHang_Load(object sender, EventArgs e)
        {

        }
        private void btnTK_Click(object sender, EventArgs e)
        {
            connect();
            string sql;
            sql = "SELECT * FROM KhachHang WHERE MaKH = @makh";
            SqlCommand sqlcom = new SqlCommand(sql, sqlcon);
            sqlcom.Parameters.AddWithValue("@makh", txtTimKiem.Text);
            SqlDataReader reader = sqlcom.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(reader);
            dgv1.DataSource = dt;  
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {

        }
    }
}