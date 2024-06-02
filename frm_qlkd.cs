using DevExpress.LookAndFeel;
using DevExpress.XtraBars;
using DevExpress.XtraReports.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DO_AN_1
{
    public partial class frm_qlkd : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public frm_qlkd()
        {
            InitializeComponent();
        }

        private void newChidForm(Form frm, string titleName)
        {
            bool IsOpen = false;
            foreach (Form f in Application.OpenForms)
            {
                if (f.Text == titleName)
                {
                    IsOpen = true;
                    f.Focus();
                    break;
                }
            }

            if (IsOpen == false)
            {
                frm.MdiParent = frm_qlkd.ActiveForm;
                frm.Text = titleName;
                frm.Show();
            }
        }

        private void dockPanel1_Click(object sender, EventArgs e)
        {

        }

        private void acc_ele_tacvu_Click(object sender, EventArgs e)
        {

        }



        private void btn_qlnd_ItemClick(object sender, ItemClickEventArgs e)
        {
            newChidForm(new QuanLyNguoiDung(), "Quản lý người dùng");
        }

        private void btn_qlsp_ItemClick(object sender, ItemClickEventArgs e)
        {
            newChidForm(new QLSP(), "Quản lý sản phẩm");
        }

        private void btn_qlnh_ItemClick(object sender, ItemClickEventArgs e)
        {
            newChidForm(new QuanLyNhapHang(), "Quản lý nhập hàng");
        }

        private void btn_qlbh_ItemClick(object sender, ItemClickEventArgs e)
        {
            newChidForm(new QuanLyBanHang(), "Quản lý bán hàng");
        }

        private void btn_qlkh_ItemClick(object sender, ItemClickEventArgs e)
        {
            newChidForm(new QuanLyKhachHang(), "Quản lý khách hàng");
        }

        private void byn_bctk_ItemClick(object sender, ItemClickEventArgs e)
        {
            using (SqlConnection con = new SqlConnection(@"Data Source=(local);Initial Catalog=quanlykinhdoanhmaytinh;Integrated Security=True;Encrypt=False"))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM BCTK", con);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                BaoCaoThongKe report = new BaoCaoThongKe();
                report.DataSource = dt;
                report.ShowPreviewDialog();
            }
        }

        private void btn_tc_ItemClick(object sender, ItemClickEventArgs e)
        {
           
        }

        private void acc_qlnd_Click(object sender, EventArgs e)
        {
            newChidForm(new QuanLyNguoiDung(), "Quản lý người dùng");
        }

        private void acc_qlsp_Click(object sender, EventArgs e)
        {
            newChidForm(new QLSP(), "Quản lý sản phẩm");
        }

        private void acc_qlnh_Click(object sender, EventArgs e)
        {
            newChidForm(new QuanLyNhapHang(), "Quản lý nhập hàng"); newChidForm(new QuanLyNhapHang(), "Quản lý nhập hàng");
        }

        private void acc_qlbh_Click(object sender, EventArgs e)
        {
            newChidForm(new QuanLyBanHang(), "Quản lý bán hàng");
        }

        private void acc_qlkh_Click(object sender, EventArgs e)
        {
            newChidForm(new QuanLyKhachHang(), "Quản lý khách hàng");
        }

        private void acc_bctk_Click(object sender, EventArgs e)
        {
            
        }

        private void acc_tc_Click(object sender, EventArgs e)
        {
            
        }

        private void frm_qlkd_Load(object sender, EventArgs e)
        {
            newChidForm(new StartPage(), "Start Page");
        }

        private void barButtonItem1_ItemClick(object sender, ItemClickEventArgs e)
        {
            UserLookAndFeel.Default.SetSkinStyle("Seven Classic");
        }

        private void barButtonItem2_ItemClick(object sender, ItemClickEventArgs e)
        {
            UserLookAndFeel.Default.SetSkinStyle("DevExpress Style");
        }

        private void barButtonItem6_ItemClick(object sender, ItemClickEventArgs e)
        {
            UserLookAndFeel.Default.SetSkinStyle("Office 2007 Green");
        }

        private void barButtonItem8_ItemClick(object sender, ItemClickEventArgs e)
        {
            UserLookAndFeel.Default.SetSkinStyle("Coffee");
        }

        private void bbiThoat_ItemClick(object sender, ItemClickEventArgs e)
        {
            Close();
        }

        private void accordionControlElement2_Click(object sender, EventArgs e)
        {

        }

        private void accordionControl1_Click(object sender, EventArgs e)
        {

        }
    }
}