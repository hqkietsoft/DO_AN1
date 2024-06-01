using DevExpress.XtraEditors;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace DO_AN_1
{
    public partial class QLNH_CNThemDH : DevExpress.XtraEditors.XtraForm
    {
        ConnData connData = new ConnData();
        private QuanLyNhapHang parentForm;
        public QLNH_CNThemDH(QuanLyNhapHang parent)
        {
            InitializeComponent();
            ccbMaNhanVien.DropDown += new EventHandler(ccbMaNhanVien_DropDown);
            ccbMaNhanVien.DropDownClosed += new EventHandler(ccbMaNhanVien_DropDownClosed);
            parentForm = parent;
        }


        private void btnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (dgvThemDH.SelectedCells.Count > 0)
            {
                int selectedRowIndex = dgvThemDH.SelectedCells[0].RowIndex;
                dgvThemDH.Rows.RemoveAt(selectedRowIndex);
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            List<string> fieldsNotEntered = new List<string>();

            // Kiểm tra từng ô để đảm bảo rằng chúng đã được nhập đầy đủ
            if (string.IsNullOrEmpty(txtMaPhieu.Text))
            {
                fieldsNotEntered.Add("Mã phiếu");
                txtMaPhieu.Focus();
            }

            if (string.IsNullOrEmpty(ccbMaNhanVien.Text))
            {
                fieldsNotEntered.Add("Mã nhân viên");
                ccbMaNhanVien.Focus();
            }
            if (string.IsNullOrEmpty(cbbMaSanPham.Text))
            {
                fieldsNotEntered.Add("Mã sản phẩm");
                txtMaPhieu.Focus();
            }
            if (string.IsNullOrEmpty(cbbTenNCC.Text))
            {
                fieldsNotEntered.Add("Tên nhà cung cấp");
                ccbMaNhanVien.Focus();
            }
            if (string.IsNullOrEmpty(txtTenNSX.Text))
            {
                fieldsNotEntered.Add("Tên nhà sản xuất");
                txtMaPhieu.Focus();
            }

            if (string.IsNullOrEmpty(txtTenSanPham.Text))
            {
                fieldsNotEntered.Add("Tên sản phẩm");
                ccbMaNhanVien.Focus();
            }
            if (string.IsNullOrEmpty(dteNgayLap.Text))
            {
                fieldsNotEntered.Add("Ngày lập");
                txtMaPhieu.Focus();
            }

            if (string.IsNullOrEmpty(txtSoLuong.Text))
            {
                fieldsNotEntered.Add("Số lượng");
                ccbMaNhanVien.Focus();
            }
            if (string.IsNullOrEmpty(txtDonViTinh.Text))
            {
                fieldsNotEntered.Add("Đơn vị tính");
                ccbMaNhanVien.Focus();
            }
            if (string.IsNullOrEmpty(txtGiaNhap.Text))
            {
                fieldsNotEntered.Add("Giá nhập");
                txtMaPhieu.Focus();
            }

            if (string.IsNullOrEmpty(txtTongTien.Text))
            {
                fieldsNotEntered.Add("Tổng tiền");
                txtMaPhieu.Focus();
            }

            if (string.IsNullOrEmpty(txtGhiChuSP.Text))
            {
                fieldsNotEntered.Add("Ghi chú");
                ccbMaNhanVien.Focus();
            }

            if (fieldsNotEntered.Count > 0)
            {
                string message = "Vui lòng nhập các thông tin sau:\n" + string.Join("\n", fieldsNotEntered);
                MessageBox.Show(message, "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string maPhieu = txtMaPhieu.Text;
            string maSanPham = cbbMaSanPham.Text;
            int soLuongNhap;
            if (!int.TryParse(txtSoLuong.Text, out soLuongNhap))
            {
                MessageBox.Show("Số lượng nhập không hợp lệ. Vui lòng nhập lại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSoLuong.Focus();
                return;
            }

            bool isUpdated = false;
            foreach (DataGridViewRow row in dgvThemDH.Rows)
            {
                if (row.Cells["MaPhieu"].Value != null && row.Cells["MaSP"].Value != null)
                {
                    if (row.Cells["MaPhieu"].Value.ToString() == maPhieu && row.Cells["MaSP"].Value.ToString() == maSanPham)
                    {
                        int currentSoLuong;
                        if (int.TryParse(row.Cells["SoLuongNhap"].Value.ToString(), out currentSoLuong))
                        {
                            row.Cells["SoLuongNhap"].Value = currentSoLuong + soLuongNhap;
                            isUpdated = true;
                            break;
                        }
                        else
                        {
                            MessageBox.Show("Số lượng hiện tại không hợp lệ. Vui lòng kiểm tra lại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }
                }
            }

            if (!isUpdated)
            {
                object[] values = {
            maPhieu,
            ccbMaNhanVien.Text,
            maSanPham,
            cbbTenNCC.Text,
            txtTenNSX.Text,
            txtTenSanPham.Text,
            dteNgayLap.Text,
            soLuongNhap.ToString(),
            txtDonViTinh.Text,
            txtGiaNhap.Text,
            txtTongTien.Text,
            txtGhiChuSP.Text
        };

                dgvThemDH.Rows.Add(values);
            }

            txtMaPhieu.Clear();
            ccbMaNhanVien.Text = "";
            dteNgayLap.Text = "";
            cbbMaSanPham.Text = "";
            cbbTenNCC.Text = "";
            txtTenNSX.Clear();
            txtTenSanPham.Text = "";
            txtSoLuong.Clear();
            txtDonViTinh.Text = "";
            txtGiaNhap.Clear();
            txtTongTien.Clear();
            txtGhiChuSP.Clear();
        }

        private bool KiemTraTonTaiMaPhieu(string maPhieu)
        {
            using (SqlConnection con = new SqlConnection(@"Data Source=(local);Initial Catalog=quanlykinhdoanhmaytinh;Integrated Security=True;Encrypt=False"))
            {
                con.Open();
                string query = "SELECT COUNT(*) FROM PhieuNhapHang WHERE MaPhieu = @MaPhieu";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@MaPhieu", maPhieu);
                int count = (int)cmd.ExecuteScalar();
                return count > 0;
            }
        }

        public class Employee
        {
            public string MaNV { get; set; }
            public string TenNV { get; set; }

            public Employee(string maNV, string tenNV)
            {
                MaNV = maNV;
                TenNV = tenNV;
            }
            // hiển thị mã + tên
            public override string ToString()
            {
                return $"{MaNV} - {TenNV}";
            }
        }

        private void QLNH_CNThemDH_Load(object sender, EventArgs e)
        {
            this.MdiParent = QuanLyNhapHang.ActiveForm;
            ccbMaNhanVien.Text = "---Chọn mã NV---";

            foreach (DataRow item in connData.laydulieuNguoiDung().Rows)
            {
                var employee = new Employee(item["MaNV"].ToString(), item["HoTen"].ToString());
                ccbMaNhanVien.Items.Add(employee);
            }

            cbbMaSanPham.Text = "---Chọn mã SP---";

            foreach (DataRow item in connData.laydulieuSanPham().Rows)
            {
                var employee1 = item["MaSP"].ToString() ;
                cbbMaSanPham.Items.Add(employee1);
            }
            FormatColumns();
        }

        private void ccbMaNhanVien_DropDown(object sender, EventArgs e)
        {
            ccbMaNhanVien.DisplayMember = "ToString";
        }

        private void ccbMaNhanVien_DropDownClosed(object sender, EventArgs e)
        {
            ccbMaNhanVien.DisplayMember = "MaNV";
        }

        private bool isDataSaved = false;

        private void btnThoat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (isDataSaved)
            {
                Close();
            }
            else
            {
                DialogResult result = MessageBox.Show("Bạn chưa lưu dữ liệu. Bạn có muốn tiếp tục thoát?", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    Close();
                }
            }
        }

        private void btnLuu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            using (SqlConnection con = new SqlConnection(@"Data Source=(local);Initial Catalog=quanlykinhdoanhmaytinh;Integrated Security=True;Encrypt=False"))
            {
                con.Open();
                SqlTransaction transaction = con.BeginTransaction();

                try
                {
                    foreach (DataGridViewRow row in dgvThemDH.Rows)
                    {
                        if (row.IsNewRow) continue;

                        // Lấy các giá trị từ DataGridView
                        string maPhieu = row.Cells["MaPhieu"].Value.ToString();
                        string maNV = row.Cells["MaNV"].Value.ToString();
                        string maSP = row.Cells["MaSP"].Value.ToString();
                        string tenNCC = row.Cells["TenNCC"].Value.ToString();
                        string tenNSX = row.Cells["TenNSX"].Value.ToString();
                        string tenSP = row.Cells["TenSP"].Value.ToString();
                        DateTime ngayLap = Convert.ToDateTime(row.Cells["NgayLap"].Value);
                        int soLuongNhap = Convert.ToInt32(row.Cells["SoLuongNhap"].Value);
                        string donViTinh = row.Cells["DonViTinh"].Value.ToString();
                        decimal giaNhap = Convert.ToDecimal(row.Cells["GiaNhap"].Value);
                        decimal tongTien = Convert.ToDecimal(row.Cells["TongTien"].Value);
                        string ghiChu = row.Cells["GhiChu"].Value.ToString();

                        // Insert vào bảng PhieuNhapHang
                        string queryPNH = @"INSERT INTO PhieuNhapHang (MaPhieu, MaNV, TenNCC, NgayLap, TongTien) 
                        VALUES (@MaPhieu, @MaNV, @TenNCC, @NgayLap, @TongTien)";
                        SqlCommand cmdPNH = new SqlCommand(queryPNH, con, transaction);
                        cmdPNH.Parameters.AddWithValue("@MaPhieu", maPhieu);
                        cmdPNH.Parameters.AddWithValue("@MaNV", maNV);
                        cmdPNH.Parameters.AddWithValue("@TenNCC", tenNCC);
                        cmdPNH.Parameters.AddWithValue("@NgayLap", ngayLap);
                        cmdPNH.Parameters.AddWithValue("@TongTien", tongTien);
                        cmdPNH.ExecuteNonQuery();

                        // Insert vào bảng ChiTietPhieuNhapHang
                        string queryCTPN = @"INSERT INTO ChiTietPhieuNhapHang (MaPhieu, MaSP, SoLuong, GiaNhap, GhiChu) 
                        VALUES (@MaPhieu, @MaSP, @SoLuong, @GiaNhap, @GhiChu)";
                        SqlCommand cmdCTPN = new SqlCommand(queryCTPN, con, transaction);
                        cmdCTPN.Parameters.AddWithValue("@MaPhieu", maPhieu);
                        cmdCTPN.Parameters.AddWithValue("@MaSP", maSP);
                        cmdCTPN.Parameters.AddWithValue("@SoLuong", soLuongNhap);
                        cmdCTPN.Parameters.AddWithValue("@GiaNhap", giaNhap);
                        cmdCTPN.Parameters.AddWithValue("@GhiChu", ghiChu);
                        cmdCTPN.ExecuteNonQuery();
                    }

                    transaction.Commit();
                    MessageBox.Show("Đã lưu thông tin thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    if (parentForm != null)
                    {
                        parentForm.RefreshData();
                    }
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    MessageBox.Show("Đã xảy ra lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    con.Close();
                }
            }

            isDataSaved = true;
        }

        private void dgvThemDH_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvThemDH.Rows[e.RowIndex];

                txtMaPhieu.Text = row.Cells["MaPhieu"].Value.ToString();
                ccbMaNhanVien.Text = row.Cells["MaNV"].Value.ToString();
                cbbMaSanPham.Text = row.Cells["MaSP"].Value.ToString();
                cbbTenNCC.Text = row.Cells["TenNCC"].Value.ToString();
                txtTenNSX.Text = row.Cells["TenNSX"].Value.ToString();
                txtTenSanPham.Text = row.Cells["TenSP"].Value.ToString();
                dteNgayLap.Text = row.Cells["NgayLap"].Value.ToString();
                txtSoLuong.Text = row.Cells["SoLuongNhap"].Value.ToString();
                txtDonViTinh.Text = row.Cells["DonViTinh"].Value.ToString();
                txtGiaNhap.Text = row.Cells["GiaNhap"].Value.ToString();
                txtTongTien.Text = row.Cells["TongTien"].Value.ToString();
                txtGhiChuSP.Text = row.Cells["GhiChu"].Value.ToString();
            }
        }

        private void FormatColumns()
        {
            dgvThemDH.Columns["NgayLap"].DefaultCellStyle.Format = "dd-MM-yyyy";
        }

        private void txtMaPhieu_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void btnSua_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (dgvThemDH.SelectedCells.Count > 0)
            {
                int selectedRowIndex = dgvThemDH.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = dgvThemDH.Rows[selectedRowIndex];

                selectedRow.Cells["MaPhieu"].Value = txtMaPhieu.Text;
                selectedRow.Cells["MaNV"].Value = ccbMaNhanVien.Text;
                selectedRow.Cells["MaSP"].Value = cbbMaSanPham.Text;
                selectedRow.Cells["TenNCC"].Value = cbbTenNCC.Text;
                selectedRow.Cells["TenNSX"].Value = txtTenNSX.Text;
                selectedRow.Cells["TenSP"].Value = txtTenSanPham.Text;
                selectedRow.Cells["NgayLap"].Value = dteNgayLap.Text;
                selectedRow.Cells["SoLuongNhap"].Value = txtSoLuong.Text;
                selectedRow.Cells["DonViTinh"].Value = txtDonViTinh.Text;
                selectedRow.Cells["GiaNhap"].Value = txtGiaNhap.Text;
                selectedRow.Cells["TongTien"].Value = txtTongTien.Text;
                selectedRow.Cells["GhiChu"].Value = txtGhiChuSP.Text;

                dgvThemDH.Refresh();
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtMaPhieu.Clear();
            ccbMaNhanVien.Text = "";
            dteNgayLap.Text = "";
            cbbMaSanPham.Text = "";
            cbbTenNCC.Text = "";
            txtTenNSX.Clear();
            txtTenSanPham.Text = "";
            txtSoLuong.Clear();
            txtDonViTinh.Text = "";
            txtGiaNhap.Clear();
            txtTongTien.Clear();
            txtGhiChuSP.Clear();
        }

        private void cbbMaSanPham_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedMaSP = cbbMaSanPham.SelectedItem.ToString();

            DataTable dtSanPham = connData.laydulieuMaSanPham(selectedMaSP);

            if (dtSanPham.Rows.Count > 0)
            {
                DataRow row = dtSanPham.Rows[0];

                txtTenSanPham.Text = row["TenSP"].ToString();
                txtTenNSX.Text = row["TenNSX"].ToString();
                txtDonViTinh.Text = row["DonViTinh"].ToString();
            }
            else
            {
                txtTenSanPham.Text = string.Empty;
                txtTenNSX.Text = string.Empty;
                txtDonViTinh.Text = string.Empty;
            }
        }

        private void ThanhTien()
        {
            if (decimal.TryParse(txtSoLuong.Text, out decimal soLuong) && decimal.TryParse(txtGiaNhap.Text, out decimal giaNhap))
            {
                txtTongTien.Text = (soLuong * giaNhap).ToString();
            }
            else
            {
                txtTongTien.Text = string.Empty;
            }
        }

        private void txtGiaNhap_EditValueChanged(object sender, EventArgs e)
        {
            ThanhTien();
        }

        private void txtTongTien_EditValueChanged_1(object sender, EventArgs e)
        {
            
        }

        private void txtSoLuong_EditValueChanged(object sender, EventArgs e)
        {
            ThanhTien();
        }

        private void pAnh_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void txtMaNV_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void labelControl13_Click(object sender, EventArgs e)
        {

        }

        private void txtTongTien_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void labelControl20_Click(object sender, EventArgs e)
        {

        }

        private void ccbMaNhanVien_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void txtMaPhieu_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void cbbTenSanPham_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void ccbMaNhanVien_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cbbTenNCC_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void labelControl3_Click(object sender, EventArgs e)
        {

        }

        private void labelControl21_Click(object sender, EventArgs e)
        {

        }
    }
}