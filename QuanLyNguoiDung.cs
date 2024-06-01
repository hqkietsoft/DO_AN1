using System;
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
            string str = "Data Source=(local);Initial Catalog=quanlykinhdoanhmaytinh;Integrated Security=True;Encrypt=False";

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
            cmd = new SqlCommand(getAllQuery, Moketnoi());
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable table = new DataTable();
            table.Load(dr);
            return table;
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
        private void btnThoat_Click_3(object sender, EventArgs e)
        {
            if (MessageBox.Show("Có chắc chắn thoát không?", "Thông báo", MessageBoxButtons.YesNo) == DialogResult.Yes)
                this.Dispose();
        }

        private void btnThem_Click_2(object sender, EventArgs e)
        {
            string Query = "INSERT INTO NguoiDung (Taikhoan, Matkhau, MaNV, HoTen, NamSinh, GioiTinh, ChucVu, DiaChi)" +
                "VALUES ('" + txt_taikhoan.Text + "', '" + txt_Matkhau.Text + "','" + txtMaNV.Text + "', N'" + txt_Hoten.Text +
                "','" + datetime.Text + "',N'" + gioitinh() + "',N'" + txt_Chucvu.Text + "', N'" + txt_Diachi.Text + "')";
            do_sql(Query);
            Hienthi_dgv1();
        }

        private void btnSua_Click_2(object sender, EventArgs e)
        {
            string Query = "UPDATE NguoiDung SET Taikhoan = '" + txt_taikhoan.Text + "',Matkhau ='" + txt_Matkhau.Text + "',Hoten = '" + txt_Hoten.Text + "'," +
               "Namsinh='" + datetime.Text + "',GioiTinh= '" + gioitinh() + "',Chucvu = '" + txt_Chucvu.Text + "',Diachi='" + txt_Diachi.Text + "'" +
               "WHERE MaNV = '" + txtMaNV.Text + "' ";
            do_sql(Query);
            Hienthi_dgv1();
        }

        private void btnXoa_Click_2(object sender, EventArgs e)
        {
            try
            {
                DialogResult tlXoa;
                tlXoa = MessageBox.Show("Bạn có muốn xóa không?", "Xóa dữ liệu", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (tlXoa == DialogResult.OK)
                {
                    string Query = "DELETE FROM NguoiDung WHERE MaNV = '" + txtMaNV.Text + "'";
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

        private void btn_Timkiem_Click_2(object sender, EventArgs e)
        {

            TimKiem_ND a = new TimKiem_ND();
            a.Show();
        }

        private void btnBoqua_Click_2(object sender, EventArgs e)
        {
            txt_taikhoan.Text = "";
            txt_Matkhau.Text = "";
            txtMaNV.Clear();
            txt_Hoten.Text = "";
            txt_Chucvu.Text = "";
            txt_Diachi.Text = "";
        }

        private void dgv_nguoidung_CellContentClick_2(object sender, DataGridViewCellEventArgs e)
        {
            txt_taikhoan.Text = dgv_nguoidung.CurrentRow.Cells[0].Value.ToString();
            txt_Matkhau.Text = dgv_nguoidung.CurrentRow.Cells[1].Value.ToString();
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

        private void QuanLyNguoiDung_Load(object sender, EventArgs e)
        {

        }
    }
}