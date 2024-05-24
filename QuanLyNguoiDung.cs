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
            string str = "Data Source=DESKTOP-H2UCOT4\\SQLEXPRESS;Initial Catalog=QLKinhDoanhMayTinh;Integrated Security=True";
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
            try
            {
                DialogResult tlXoa;
                tlXoa = MessageBox.Show("Bạn có muốn xóa không?", "Xóa dữ liệu", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (tlXoa == DialogResult.OK)
                {
                    string Query = "DELETE FROM KhachHang WHERE MaKH = '" + txt_Hoten.Text + "'";
                    do_sql(Query);
                    Hienthi_dgv1();
                    MessageBox.Show("Đã xóa thành công!", "Xóa dữ liệu");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Bạn chưa xóa thành công dữ liệu!!!");
                MessageBox.Show("Hệ thống báo lỗi." + ex.Message);
            }

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
            string Query = "INSERT INTO NguoiDung ( MaNV, HoTen, NgaySinh, GioiTinh, ChucVu, DiaChi)" +
                "VALUES ('" + txt_MaNV.Text + "', N'" + txt_Hoten.Text +
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
            txtMaNV.Text = dgv_nguoidung.CurrentRow.Cells[2].Value.ToString();
            txt_Hoten.Text = dgv_nguoidung.CurrentRow.Cells[3].Value.ToString();
            datetime.Text = dgv_nguoidung.CurrentRow.Cells[4].Value.ToString();
            if (dgv_nguoidung.CurrentRow.Cells[5].Value.ToString() == "Nam")
            {
                rbnam.Checked = true;
            }
            else
            {
                rbnu.Checked = true;
            }
            txt_Chucvu.Text = dgv_nguoidung.CurrentRow.Cells[6].Value.ToString();
            txt_Diachi.Text = dgv_nguoidung.CurrentRow.Cells[7].Value.ToString();
        }

        private void btnThoat_Click_1(object sender, EventArgs e)
        {

            if (MessageBox.Show("Có chắc chắn thoát không?", "Thông báo", MessageBoxButtons.YesNo) == DialogResult.Yes)
                this.Dispose();
        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void btnThem_Click_1(object sender, EventArgs e)
        {
            string Query = "INSERT INTO NguoiDung ( MaNV, HoTen, NgaySinh, GioiTinh, ChucVu, DiaChi)" +
                "VALUES ('" + txt_MaNV.Text + "', N'" + txt_Hoten.Text +
                "','" + datetime.Text + "',N'" + gioitinh() + "',N'" + txt_Chucvu.Text + "', N'" + txt_Diachi.Text + "')";
            do_sql(Query);
            Hienthi_dgv1();
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }
        
        private void btnXoa_Click_1(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            cmd.Parameters.AddWithValue("@Taikhoan", txt_taikhoan.Text);
            cmd.Parameters.AddWithValue("@Matkhau", txt_Matkhau.Text);
            cmd.Parameters.AddWithValue("@MaNV", txt_MaNV.Text);
            cmd.Parameters.AddWithValue("@HoTen", txt_Hoten.Text);
            cmd.Parameters.AddWithValue("@NgaySinh", datetime.Text);
            cmd.Parameters.AddWithValue("@GioiTinh", gioitinh());
            cmd.Parameters.AddWithValue("@ChucVu", txt_Chucvu.Text);
            cmd.Parameters.AddWithValue("@Diachi", txt_Diachi.Text);
            if (MessageBox.Show("Bạn có muốn lưu không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                txt_taikhoan.Text = "";
                txt_Matkhau.Text = "";
                txt_MaNV.Text = "";
                txt_Hoten.Text = "";
                datetime.Text = "";
                gioitinh();
                txt_Chucvu.Text = "";
                txt_Diachi.Text = "";
            }
            btnLuu.Enabled = false;
            btnBoqua.Enabled = false;
            btnThem.Enabled = true;
            btnXoa.Enabled = true;
            btnSua.Enabled = true;
            btn_Timkiem.Enabled = true;
        }

        private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void btnBoqua_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn bỏ qua không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                btnLuu.Enabled = false;
                btnBoqua.Enabled = false;
                btnThem.Enabled = true;
                btnXoa.Enabled = true;
                btnSua.Enabled = true;
                btn_Timkiem.Enabled = true;
            }
        }

        private void datetime_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void txt_MaNV_TextChanged(object sender, EventArgs e)
        {

        }
    }
}