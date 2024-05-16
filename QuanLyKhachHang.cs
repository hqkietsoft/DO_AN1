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
using DevExpress.XtraLayout.Customization;
using DevExpress.Pdf.Native.BouncyCastle.Utilities.Collections;

namespace DO_AN_1
{
    public partial class QuanLyKhachHang : DevExpress.XtraEditors.XtraForm
    {
        SqlConnection con;
        SqlCommand cmd;
        public QuanLyKhachHang()
        {
            InitializeComponent();
            Hienthi_dgv1();
        }
        public SqlConnection moketnoi()
        {
            string str = "Data Source=DESKTOP-H2UCOT4\\SQLEXPRESS;Initial Catalog=QLKinhDoanhMayTinh;Integrated Security=True";
            con = new SqlConnection(str);
            con.Open();
            return con;
        }
        public void dongketnoi()
        {
            con.Close();
        }
        public DataTable ShowAll()
        {
            string getAllQuery = "SELECT * FROM KhachHang";
            cmd = new SqlCommand(getAllQuery, moketnoi());
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable bang= new DataTable();
            bang.Load(dr);
            return bang;
        }
        public void do_sql(string Query)
        {
            cmd = new SqlCommand(Query, moketnoi());
            cmd.ExecuteNonQuery();
            dongketnoi();
        }
        public void Hienthi_dgv1()
        {
            dgv1.DataSource = ShowAll();
        }
        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

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
            try
            {
                DialogResult tlXoa;
                tlXoa = MessageBox.Show("Bạn có muốn xóa không?", "Xóa dữ liệu", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (tlXoa == DialogResult.OK)
                {
                    string Query = "DELETE FROM KhachHang WHERE MaKH = '" + txtMa.Text + "'";
                    do_sql(Query);
                    Hienthi_dgv1();
                    MessageBox.Show("Đã xóa thành công ", "Xóa dữ liệu");
                }    
            }
            catch (Exception ex)
            {
                MessageBox.Show("Bạn chưa xóa thành công dữ liệu!!!");
                MessageBox.Show("Hệ thống báo lỗi." +ex.Message);
            }
        }
        bool kiemtraRong()
        {
            if (txtMa.Text.Trim() == "") return false;
            if (txtTenKH.Text.Trim() == "") return false;
            if (datetime.Text.Trim() == "") return false;
            if (txtDiachi.Text.Trim() =="") return false;
            if (txtSDT.Text.Trim() == "") return false;
            return true;
        }
        public bool tontaiKH(string ma)
        {
            bool kt = false;
            moketnoi();
            string sql = "select * from KhachHang where MaKH = @MaKH";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("MaKH", ma);
            SqlDataReader dr = cmd.ExecuteReader();
            if(dr.HasRows) kt= true;
            dongketnoi();
            return kt;
        }
        
        private void btnThem_Click(object sender, EventArgs e)
        {
            if (!kiemtraRong())
            {
                MessageBox.Show("Chưa nhập đủ thông tin!");
                return;
            }
            string ma = txtMa.Text.Trim();
            string ten = txtTenKH.Text;
            DateTime ngay = DateTime.Parse(datetime.Text);
            
            string dc = txtDiachi.Text;
            string sdt = txtSDT.Text;
            if (tontaiKH(ma))
            {
                string Query = "INSERT INTO KhachHang VALUES('"+ma+"','"+ten+"', '"+ngay+"', '"+gioitinh()+"', '"+dc+"', '"+sdt+"')";
                do_sql(Query);
                Hienthi_dgv1();
                MessageBox.Show("Mã khách hàng đã tồn tại!");
                return;
            }

        }

        private void QuanLyKhachHang_Load(object sender, EventArgs e)
        {

        }
    }
}