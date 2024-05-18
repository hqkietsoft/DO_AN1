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
        }


        private void SetAnchor()
        {
            dgHoaDon.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgDSHoaDon.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            // Các điều khiển khác...
        }

        private void btnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            QLNH_CNThemDH qLNH_CNThem = new QLNH_CNThemDH();
            qLNH_CNThem.Show();
        }

        public class DonHang
        {
            public string MaPhieu { get; set; }
            public string MaNhanVien { get; set; }
            public string MaSanPham { get; set; }
            public string TenNCC { get; set; }
            public string TenNSX { get; set; }
            public string TenSanPham { get; set; }
            public DateTime NgayLap { get; set; }
            public int SoLuongNhap { get; set; }
            public string DonViTinh { get; set; }
            public decimal GiaNhap { get; set; }
            public decimal DonGia { get; set; }
            public decimal TongTien { get; set; }
            public string GhiChu { get; set; }
        }

        private void btnSua_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            List<DonHang> danhSachDonHang = new List<DonHang>();

            // Đoạn mã lấy dữ liệu từ bảng và thêm vào danh sách danhSachDonHang
            DataTable dtHoaDon = (DataTable)dgDSHoaDon.DataSource;
            if (dtHoaDon == null || dtHoaDon.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu để sửa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            foreach (DataRow row in dtHoaDon.Rows)
            {
                DonHang donHang = new DonHang();
                donHang.MaPhieu = row["MaPhieu"].ToString();
                donHang.MaNhanVien = row["MaNV"].ToString();
                donHang.MaSanPham = row["MaSP"].ToString();
                donHang.TenNCC = row["TenNCC"].ToString();
                donHang.TenNSX = row["TenNSX"].ToString();
                donHang.TenSanPham = row["TenSP"].ToString();
                donHang.NgayLap = Convert.ToDateTime(row["NgayLap"]);
                donHang.SoLuongNhap = Convert.ToInt32(row["SoLuongNhap"]);
                donHang.DonViTinh = row["DonViTinh"].ToString();
                donHang.GiaNhap = Convert.ToDecimal(row["GiaNhap"]);
                donHang.DonGia = Convert.ToDecimal(row["DonGia"]);
                donHang.TongTien = Convert.ToDecimal(row["TongTien"]);
                donHang.GhiChu = row["GhiChu"].ToString();

                danhSachDonHang.Add(donHang);
            }

            // Tạo đối tượng mới của lớp QLNH_CNSuaDH và truyền danh sách danhSachDonHang vào constructor
            QLNH_CNSuaDH suaDHForm = new QLNH_CNSuaDH(danhSachDonHang);
            suaDHForm.Show();

        }

        private void QuanLyNhapHang_Load(object sender, EventArgs e)
        {
            this.MdiParent = frm_qlkd.ActiveForm;
            SetAnchor();
            connData.HienthiLenDGPN(dgHoaDon);
            connData.HienthiLenDGDSP(dgDSHoaDon);
            FormatColumns();
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

            string query1 = @"SELECT pnh.MaPhieu, nd.MaNV, sp.MaSP, pnh.TenNCC, sp.TenNSX, ctpn.TenSP, pnh.NgayLap, ctpn.SoLuongNhap, sp.DonViTinh, 
                    ctpn.GiaNhap, sp.DonGia, pnh.TongTien, ctpn.GhiChu 
                    FROM PhieuNhapHang AS pnh
                    INNER JOIN ChiTietPhieuNhap AS ctpn ON pnh.MaPhieu = ctpn.MaPhieu
                    INNER JOIN NguoiDung AS nd ON nd.MaNV = pnh.MaNV
                    INNER JOIN SanPham AS sp ON sp.MaSP = ctpn.MaSP
                    WHERE pnh.NgayLap BETWEEN @NgayTuNgay AND @NgayDenNgay";
            DataTable dt1 = connData.displaySearch(query1, ngayTuNgay, ngayDenNgay);
            dgDSHoaDon.DataSource = dt1;
        }

        private void FormatColumns()
        {
            dgHoaDon.Columns["NgayLap"].DefaultCellStyle.Format = "dd-MM-yyyy";
            dgDSHoaDon.Columns["Column7"].DefaultCellStyle.Format = "dd-MM-yyyy";
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

                string maHoaDonList = string.Join(",", maHoaDons.Select(m => $"'{m}'"));

                using (SqlConnection con = new SqlConnection(@"Data Source=DAFF;Initial Catalog=quanLyKDLaptop;Integrated Security=True;Encrypt=False"))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand($"select * from InPNH where MaPhieu IN ({maHoaDonList})", con);

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
                MessageBox.Show("Vui lòng chọn ít nhất một hóa đơn để in.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

                    using (SqlConnection con = new SqlConnection(@"Data Source=DAFF;Initial Catalog=quanLyKDLaptop;Integrated Security=True;Encrypt=False"))
                    {
                        con.Open();
                        SqlCommand cmdCTPN = new SqlCommand($"DELETE FROM ChiTietPhieuNhap WHERE MaPhieu IN ({maHoaDonList})", con);
                        cmdCTPN.ExecuteNonQuery();

                        SqlCommand cmdPNH = new SqlCommand($"DELETE FROM PhieuNhapHang WHERE MaPhieu IN ({maHoaDonList})", con);
                        cmdPNH.ExecuteNonQuery();

                        con.Close();
                    }

                    string query = "SELECT * FROM PhieuNhapHang WHERE NgayLap >= @NgayTuNgay AND NgayLap <= @NgayDenNgay";
                    DataTable dt = connData.displaySearch(query, ngayTuNgay, ngayDenNgay);
                    dgHoaDon.DataSource = dt;

                    string query1 = @"SELECT pnh.MaPhieu, nd.MaNV, sp.MaSP, pnh.TenNCC, sp.TenNSX, ctpn.TenSP, pnh.NgayLap, ctpn.SoLuongNhap, sp.DonViTinh, 
                    ctpn.GiaNhap, sp.DonGia, pnh.TongTien, ctpn.GhiChu 
                    FROM PhieuNhapHang AS pnh
                    INNER JOIN ChiTietPhieuNhap AS ctpn ON pnh.MaPhieu = ctpn.MaPhieu
                    INNER JOIN NguoiDung AS nd ON nd.MaNV = pnh.MaNV
                    INNER JOIN SanPham AS sp ON sp.MaSP = ctpn.MaSP
                    WHERE pnh.NgayLap BETWEEN @NgayTuNgay AND @NgayDenNgay";
                    DataTable dt1 = connData.displaySearch(query1, ngayTuNgay, ngayDenNgay);
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
            connData.HienthiLenDGDSP(dgDSHoaDon);
        }
    }
}