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
            string str = "Data Source=DESKTOP-H2UCOT4\\SQLEXPRESS;Initial Catalog=QuanLyKinhDoanhMayTinh;Integrated Security=True";
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
            dgv1.DataSource = ShowAll();
        }
        private void dgv1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMaNV.Text = dgv1.CurrentRow.Cells[2].Value.ToString();

        }

        private void QuanLyNguoiDung_Load(object sender, EventArgs e)
        {

        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string Query = "DELETE FROM NguoiDung WHERE MaNV = '" + txtMaNV.Text + "' ";
            do_sql(Query);
            Hienthi_dgv1();
        }

        private void txtXoa_TextChanged(object sender, EventArgs e)
        {

        }
    }
}