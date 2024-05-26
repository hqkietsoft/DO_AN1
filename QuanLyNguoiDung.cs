using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;


namespace DO_AN_1
{
    public partial class QuanLyNguoiDung : DevExpress.XtraEditors.XtraForm
    {

        SqlCommand cmd;
        SqlConnection con;

        public SqlConnection MoKetNoi()
        {
            string str = "Data Source=DESKTOP-EC4KK8E\\SQLEXPRESS;Initial Catalog=quanlynhanvien;Integrated Security=True";
            con = new SqlConnection(str);
            con.Open();
            return con;
        }

        public void DongKetNoi()
        {
            con.Close();
        }

        public DataTable ShowAll()
        {
            string getAllQuery = "select * from NhanVien";
            cmd = new SqlCommand(getAllQuery, MoKetNoi());
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable table = new DataTable();
            table.Load(dr);
            return table;
        }
        public void do_sql(string Query)
        {
            cmd = new SqlCommand(Query, MoKetNoi());
            cmd.ExecuteNonQuery();
            DongKetNoi();
        }
        public void Hienthi_dgv()
        {
            dgv.DataSource = ShowAll();
        }
        public QuanLyNguoiDung()
        {
            InitializeComponent();
            Hienthi_dgv();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void QuanLyNguoiDung_Load(object sender, EventArgs e)
        {

        }
    }
}