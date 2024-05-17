using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace DO_AN_1
{
    public partial class QuanLyNguoiDung : DevExpress.XtraEditors.XtraForm
    {
        SqlConnection con;
        SqlCommand cmd;
        public SqlConnection Moketnoi()
        {
            string str = "Data Source=DESKTOP-TEOF11\\SQLEXPRESS;Initial Catalog=QuanLyKinhDoanhMayTinh;Integrated Security=True";
            con = new SqlConnection(str);
            con.Open();
            return con;
        }
        public void Dongketnoi()
        {
            con.Close();
        }

        public QuanLyNguoiDung()
        {
            InitializeComponent();
            Hienthi_dgv1();
        }
        public DataTable ShowAll()
        {
            string getAllQuery = "select * from NguoiDung";
            cmd = new SqlCommand(getAllQuery,Moketnoi());
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable table = new DataTable();
            table.Load(dr);
            return table ;
        }
        public void do_sql(string Query)
        {
            cmd = new SqlCommand(Query,Moketnoi());
            cmd.ExecuteNonQuery();
            Dongketnoi();
        }
        public void Hienthi_dgv1()
        {
            dgv_nguoidung.DataSource = ShowAll();
        }
       

        private void QuanLyNguoiDung_Load(object sender, EventArgs e)
        {

        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string Query = "DELETE FROM NguoiDung WHERE MaNV = '" + txt_MaNV.Text + "' ";
            do_sql(Query);
            Hienthi_dgv1();

        }

        private void txtXoa_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Có chắc chắn thoát không?", "Thông báo", MessageBoxButtons.YesNo) == DialogResult.Yes)
                this.Dispose();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            string Query = "INSERT INTO NguoiDung (Taikhoan, Matkhau, MaNV, HoTen, NgaySinh, GioiTinh, ChucVu, DiaChi)" +
                "VALUES ('" + txt_taikhoan.Text + "', '" + txt_Matkhau.Text + "','" + txt_MaNV.Text + "', N'" + txt_Hoten.Text +
                "','" + datetime.Text + "',N'" + gioitinh() + "',N'" + txt_Chucvu.Text + "', N'" + txt_Diachi.Text + "')";
              do_sql(Query);
              Hienthi_dgv1();
        }
        public string gioitinh()
        {
            string gtinh;
            if(rbnam.Checked == true)
            {
                gtinh = "Nam";
            }
            else
            {
                gtinh = "Nữ";
            }
            return gtinh;
        }
        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void btnTaikhoan_Click(object sender, EventArgs e)
        {

        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string Query = "UPDATE NguoiDung SET Taikhoan = '" + txt_taikhoan.Text + "',Matkhau ='"+txt_Matkhau.Text+"',Hoten = '"+txt_Hoten.Text+"',"+
                "Ngaysinh='"+datetime.Text+"',GioiTinh= '"+gioitinh()+"',Chucvu = '"+txt_Chucvu.Text+"',Diachi='"+txt_Diachi.Text+"'"+
                "WHERE MaNV = '" + txt_MaNV.Text + "' ";
            do_sql(Query);
            Hienthi_dgv1();
        }

        private void txt_taikhoan_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            TimKiem_ND TK = new TimKiem_ND();
            TK.Show();
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void btn_Timkiem_Click(object sender, EventArgs e)
        {

        }

        private void dgv_nguoidung_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //txt_taikhoan.Text = dgv_nguoidung.CurrentRow.Cells[0].Value.ToString();
            //txt_Matkhau.Text = dgv_nguoidung.CurrentRow.Cells[1].Value.ToString();
            txt_MaNV.Text = dgv_nguoidung.CurrentRow.Cells[0].Value.ToString();
            txt_Hoten.Text = dgv_nguoidung.CurrentRow.Cells[1].Value.ToString();
            datetime.Text = dgv_nguoidung.CurrentRow.Cells[2].Value.ToString();
            if (dgv_nguoidung.CurrentRow.Cells[3].Value.ToString() == "Nam")
            {
                rbnam.Checked = true;
            }
            else
            {
                rbnu.Checked = true;
            }
            txt_Chucvu.Text = dgv_nguoidung.CurrentRow.Cells[4].Value.ToString();
            txt_Diachi.Text = dgv_nguoidung.CurrentRow.Cells[5].Value.ToString();
        }
    }
}