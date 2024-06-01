using DevExpress.XtraEditors;
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
    public partial class QuanLyNhapHang : DevExpress.XtraEditors.XtraForm
    {
        ConnData connData = new ConnData();
        public QuanLyNhapHang()
        {
            InitializeComponent();
            dgHoaDon.CellClick += new DataGridViewCellEventHandler(dgHoaDon_CellClick);
            dgHoaDon.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 11, FontStyle.Bold);
            dgDSHoaDon.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 11, FontStyle.Bold);
        }


        private void btnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            QLNH_CNThemDH qLNH_CNThem = new QLNH_CNThemDH(this);
            qLNH_CNThem.Show();
        }

        private void btnSua_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (dgHoaDon.SelectedRows.Count > 0 && dgDSHoaDon.SelectedRows.Count > 0)
            {
                // Lấy hàng được chọn từ mỗi DataGridView
                DataGridViewRow selectedRowHoaDon = dgHoaDon.SelectedRows[0];
                DataGridViewRow selectedRowDSHoaDon = dgDSHoaDon.SelectedRows[0];

                // Tạo một danh sách các giá trị để truyền
                List<object> combinedData = new List<object>();

                // Lấy 5 giá trị từ dgHoaDon
                for (int i = 0; i < 5; i++)
                {
                    combinedData.Add(selectedRowHoaDon.Cells[i].Value);
                }

                // Lấy 7 giá trị từ dgDSHoaDon
                for (int i = 0; i < 7; i++)
                {
                    combinedData.Add(selectedRowDSHoaDon.Cells[i].Value);
                }

                // Truyền dữ liệu sang form QLNH_CNSuaDH
                QLNH_CNSuaDH suaDHForm = new QLNH_CNSuaDH();
                suaDHForm.AddCombinedData(combinedData);
                suaDHForm.Show();
            }
            else
            {
                MessageBox.Show("Vui lòng chọn hàng trong cả hai bảng DANH SÁCH PHIẾU NHẬP và CHI TIẾT PHIẾU NHẬP.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void QuanLyNhapHang_Load(object sender, EventArgs e)
        {
            this.MdiParent = frm_qlkd.ActiveForm;
            connData.HienthiLenDGPN(dgHoaDon);
            FormatColumns();
            dgHoaDon.DataSource = connData.getQueryPhieuNH();
        }

        private void dgHoaDon_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void dgDSHoaDon_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            DateTime ngayTuNgay = dteNhapTuNgay.DateTime;
            DateTime ngayDenNgay = dteNhapDenNgay.DateTime;

            if (ngayTuNgay > ngayDenNgay)
            {
                MessageBox.Show("Ngày từ phải nhỏ hơn hoặc bằng ngày đến.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string query = "SELECT * FROM PhieuNhapHang WHERE NgayLap >= @NgayTuNgay AND NgayLap <= @NgayDenNgay";
            DataTable dt = connData.displaySearch(query, ngayTuNgay, ngayDenNgay);
            dgHoaDon.DataSource = dt;
        }

        private void FormatColumns()
        {
            dgHoaDon.Columns["NgayLap"].DefaultCellStyle.Format = "dd-MM-yyyy";
        }

        private void groupControl1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnThoat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }

        private void btnIn_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (dgHoaDon.SelectedRows.Count > 0)
            {
                List<string> maHoaDons = new List<string>();

                foreach (DataGridViewRow row in dgHoaDon.SelectedRows)
                {
                    string maHoaDon = row.Cells[0].Value.ToString();
                    maHoaDons.Add(maHoaDon);
                }

                // Tạo chuỗi chứa các tham số cho câu lệnh SQL
                string maHoaDonList = string.Join(",", maHoaDons.Select((m, i) => $"@MaPhieu{i}"));

                using (SqlConnection con = new SqlConnection(@"Data Source=(local);Initial Catalog=quanlykinhdoanhmaytinh;Integrated Security=True;Encrypt=False"))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand($"SELECT * FROM InPNH WHERE MaPhieu IN ({maHoaDonList})", con);

                    // Thêm các giá trị cho tham số vào SqlCommand
                    for (int i = 0; i < maHoaDons.Count; i++)
                    {
                        cmd.Parameters.AddWithValue($"@MaPhieu{i}", maHoaDons[i]);
                    }

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    InHDN report = new InHDN();
                    report.DataSource = dt;
                    report.ShowPreviewDialog();
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn ít nhất một hóa đơn.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void btnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DateTime ngayTuNgay = dteNhapTuNgay.DateTime;
            DateTime ngayDenNgay = dteNhapDenNgay.DateTime;
            if (dgHoaDon.SelectedRows.Count > 0)
            {
                DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa các hóa đơn đã chọn?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    List<string> maHoaDons = new List<string>();

                    foreach (DataGridViewRow row in dgHoaDon.SelectedRows)
                    {
                        string maHoaDon = row.Cells["MaPhieu"].Value.ToString();
                        maHoaDons.Add(maHoaDon);
                    }

                    string maHoaDonList = string.Join(",", maHoaDons.Select(m => $"'{m}'"));

                    using (SqlConnection con = new SqlConnection(@"Data Source=(local);Initial Catalog=quanlykinhdoanhmaytinh;Integrated Security=True;Encrypt=False"))
                    {
                        con.Open();
                        using (SqlCommand cmdCTPN = new SqlCommand($"DELETE FROM ChiTietPhieuNhapHang WHERE MaPhieu IN ({maHoaDonList})", con))
                        {
                            cmdCTPN.ExecuteNonQuery();
                        }

                        using (SqlCommand cmdPNH = new SqlCommand($"DELETE FROM PhieuNhapHang WHERE MaPhieu IN ({maHoaDonList})", con))
                        {
                            cmdPNH.ExecuteNonQuery();
                        }
                        con.Close();
                    }

                    string query = "SELECT * FROM PhieuNhapHang WHERE NgayLap >= @NgayTuNgay AND NgayLap <= @NgayDenNgay";
                    DataTable dt = connData.displaySearch(query, ngayTuNgay, ngayDenNgay);
                    dgHoaDon.DataSource = dt;

                    string query1 = @"SELECT sp.MaSP, sp.TenNSX, sp.TenSP, ctpn.SoLuong, sp.DonViTinh, 
                            ctpn.GiaNhap, ctpn.GhiChu 
                     FROM PhieuNhapHang AS pnh
                     INNER JOIN ChiTietPhieuNhapHang AS ctpn ON pnh.MaPhieu = ctpn.MaPhieu
                     INNER JOIN SanPham AS sp ON sp.MaSP = ctpn.MaSP
                     WHERE pnh.MaPhieu IN (" + maHoaDonList + ")";
                    DataTable dt1 = connData.displayDSHD1(query1);
                    dgDSHoaDon.DataSource = dt1;

                    MessageBox.Show("Đã xóa các hóa đơn được chọn.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn ít nhất một hóa đơn để xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            connData.HienthiLenDGPN(dgHoaDon);
           
        }
        public void RefreshData()
        {
            btnRefresh_Click(this, EventArgs.Empty);
        }

        private void dgHoaDon_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
            {
                return;
            }
            DataGridViewRow row = dgHoaDon.Rows[e.RowIndex];
            string maPhieu = row.Cells["MaPhieu"].Value.ToString();

            string query = @"SELECT sp.MaSP, sp.TenNSX, sp.TenSP, ctpn.SoLuong, sp.DonViTinh, 
                        ctpn.GiaNhap, ctpn.GhiChu 
                 FROM PhieuNhapHang AS pnh
                 INNER JOIN ChiTietPhieuNhapHang AS ctpn ON pnh.MaPhieu = ctpn.MaPhieu
                 INNER JOIN SanPham AS sp ON sp.MaSP = ctpn.MaSP
                 WHERE pnh.MaPhieu = @MaPhieu";

            DataTable dt = connData.displayDSHD(query, new SqlParameter("@MaPhieu", maPhieu));
            dgDSHoaDon.DataSource = dt;
        }

        private void dgHoaDon_ColumnHeadersDefaultCellStyleChanged(object sender, EventArgs e)
        {
            dgHoaDon.EnableHeadersVisualStyles = false;
        }
    }
}