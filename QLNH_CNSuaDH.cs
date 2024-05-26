using DevExpress.Office.Drawing;
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
using static DO_AN_1.QuanLyNhapHang;

namespace DO_AN_1
{
    public partial class QLNH_CNSuaDH : DevExpress.XtraEditors.XtraForm
    {
        ConnData connData = new ConnData();
        private DataTable dtDSHoaDon;
        public QLNH_CNSuaDH()
        {
            InitializeComponent();
            ccbMaNhanVien.DropDown += new EventHandler(ccbMaNhanVien_DropDown);
            ccbMaNhanVien.DropDownClosed += new EventHandler(ccbMaNhanVien_DropDownClosed);
            
        }

        public void AddCombinedData(List<object> combinedData)
        {
            DataTable dtSuaMHCurrent = null;
            if (dgvSuaDH.DataSource == null)
            {
                dtSuaMHCurrent = new DataTable();
                dtSuaMHCurrent.Columns.Add("MaPhieu");
                dtSuaMHCurrent.Columns.Add("MaNV");
                dtSuaMHCurrent.Columns.Add("TenNCC");
                dtSuaMHCurrent.Columns.Add("NgayLap", typeof(DateTime));
                dtSuaMHCurrent.Columns.Add("TongTien", typeof(decimal));
                dtSuaMHCurrent.Columns.Add("MaSP");
                dtSuaMHCurrent.Columns.Add("TenNSX");
                dtSuaMHCurrent.Columns.Add("TenSP");
                dtSuaMHCurrent.Columns.Add("SoLuongNhap", typeof(int));
                dtSuaMHCurrent.Columns.Add("DonViTinh");
                dtSuaMHCurrent.Columns.Add("GiaNhap", typeof(decimal));
                dtSuaMHCurrent.Columns.Add("GhiChu");
                dgvSuaDH.DataSource = dtSuaMHCurrent;
            }
            else
            {
                dtSuaMHCurrent = (DataTable)dgvSuaDH.DataSource;
            }

            DataRow newRow = dtSuaMHCurrent.NewRow();

            for (int i = 0; i < combinedData.Count; i++)
            {
                switch (i)
                {
                    case 0:
                        newRow["MaPhieu"] = combinedData[i];
                        break;
                    case 1:
                        newRow["MaNV"] = combinedData[i];
                        break;
                    case 2:
                        newRow["TenNCC"] = combinedData[i];
                        break;
                    case 3:
                        newRow["NgayLap"] = combinedData[i];
                        break;
                    case 4:
                        newRow["TongTien"] = combinedData[i];
                        break;
                    case 5:
                        newRow["MaSP"] = combinedData[i];
                        break;
                    case 6:
                        newRow["TenNSX"] = combinedData[i];
                        break;
                    case 7:
                        newRow["TenSP"] = combinedData[i];
                        break;
                    case 8:
                        newRow["SoLuongNhap"] = combinedData[i];
                        break;
                    case 9:
                        newRow["DonViTinh"] = combinedData[i];
                        break;
                    case 10:
                        newRow["GiaNhap"] = combinedData[i];
                        break;
                    case 11:
                        newRow["GhiChu"] = combinedData[i];
                        break;
                    default:
                        // Xử lý trường hợp có nhiều hơn 12 giá trị trong combinedData
                        break;
                }
            }

            dtSuaMHCurrent.Rows.Add(newRow);
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

        private void QLNH_CNSuaDH_Load(object sender, EventArgs e)
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
                var employee1 = item["MaSP"].ToString();
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

        private void btnLuu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            using (SqlConnection con = new SqlConnection(@"Data Source=DAFF;Initial Catalog=quanlykinhdoanhmaytinh;Integrated Security=True;Encrypt=False"))
            {
                con.Open();
                SqlTransaction transaction = con.BeginTransaction();

                try
                {
                    foreach (DataGridViewRow row in dgvSuaDH.Rows)
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

                        // Cập nhật thông tin trong bảng PhieuNhapHang
                        string queryUpdatePNH = @"UPDATE PhieuNhapHang 
                                      SET MaNV = @MaNV, TenNCC = @TenNCC, NgayLap = @NgayLap, TongTien = @TongTien
                                      WHERE MaPhieu = @MaPhieu";
                        SqlCommand cmdUpdatePNH = new SqlCommand(queryUpdatePNH, con, transaction);
                        cmdUpdatePNH.Parameters.AddWithValue("@MaPhieu", maPhieu);
                        cmdUpdatePNH.Parameters.AddWithValue("@MaNV", maNV);
                        cmdUpdatePNH.Parameters.AddWithValue("@TenNCC", tenNCC);
                        cmdUpdatePNH.Parameters.AddWithValue("@NgayLap", ngayLap);
                        cmdUpdatePNH.Parameters.AddWithValue("@TongTien", tongTien);
                        cmdUpdatePNH.ExecuteNonQuery();

                        // Cập nhật thông tin trong bảng ChiTietPhieuNhapHang
                        string queryUpdateCTPN = @"UPDATE ChiTietPhieuNhapHang 
                                       SET SoLuong = @SoLuong, GiaNhap = @GiaNhap, GhiChu = @GhiChu
                                       WHERE MaPhieu = @MaPhieu AND MaSP = @MaSP";
                        SqlCommand cmdUpdateCTPN = new SqlCommand(queryUpdateCTPN, con, transaction);
                        cmdUpdateCTPN.Parameters.AddWithValue("@MaPhieu", maPhieu);
                        cmdUpdateCTPN.Parameters.AddWithValue("@MaSP", maSP);
                        cmdUpdateCTPN.Parameters.AddWithValue("@SoLuong", soLuongNhap);
                        cmdUpdateCTPN.Parameters.AddWithValue("@GiaNhap", giaNhap);
                        cmdUpdateCTPN.Parameters.AddWithValue("@GhiChu", ghiChu);
                        cmdUpdateCTPN.ExecuteNonQuery();
                    }

                    transaction.Commit();
                    MessageBox.Show("Đã cập nhật thông tin thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
        
        private void btnDong_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
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
       

        private void cbbTenSanPham_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void cbbTenNCC_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        

        private void dgvSuaMH_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow selectedRow = dgvSuaDH.Rows[e.RowIndex];

                txtMaPhieu.Text = selectedRow.Cells["MaPhieu"].Value.ToString();
                ccbMaNhanVien.Text = selectedRow.Cells["MaNV"].Value.ToString();
                cbbMaSanPham.Text = selectedRow.Cells["MaSP"].Value.ToString();
                cbbTenNCC.Text = selectedRow.Cells["TenNCC"].Value.ToString();
                txtTenNSX.Text = selectedRow.Cells["TenNSX"].Value.ToString();
                txtTenSanPham.Text = selectedRow.Cells["TenSP"].Value.ToString();
                dteNgayLap.Text = selectedRow.Cells["NgayLap"].Value.ToString();
                txtSoLuong.Text = selectedRow.Cells["SoLuongNhap"].Value.ToString();
                txtDonViTinh.Text = selectedRow.Cells["DonViTinh"].Value.ToString();
                txtGiaNhap.Text = selectedRow.Cells["GiaNhap"].Value.ToString();
                txtTongTien.Text = selectedRow.Cells["TongTien"].Value.ToString();
                txtGhiChuSP.Text = selectedRow.Cells["GhiChu"].Value.ToString();
            }
        }
        private void FormatColumns()
        {
            if (dgvSuaDH.Columns["NgayLap"] != null)
            {
                dgvSuaDH.Columns["NgayLap"].DefaultCellStyle.Format = "dd-MM-yyyy";
            }
        }

        private void txtMaPhieu_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (dgvSuaDH.SelectedRows.Count > 0)
            {
                // Lấy dòng được chọn
                DataGridViewRow selectedRow = dgvSuaDH.SelectedRows[0];

                // Lấy dữ liệu từ dòng được chọn
                string maPhieu = selectedRow.Cells["MaPhieu"].Value.ToString();

                // Xác nhận việc xóa dòng
                DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xoá dòng này không?", "Xác nhận xoá", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    dgvSuaDH.Rows.Remove(selectedRow);
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
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một dòng để xoá.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtMaPhieu.Clear();
            ccbMaNhanVien.Text = "";
            dteNgayLap.Text = "";
            cbbMaSanPham.Text = ""; ;
            cbbTenNCC.Text = "";
            txtTenNSX.Clear();
            txtTenSanPham.Text = "";
            txtSoLuong.Clear();
            txtDonViTinh.Text = "";
            txtGiaNhap.Clear();
            txtTongTien.Clear();
            txtGhiChuSP.Clear();
        }

        private void btnSua_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (dgvSuaDH.SelectedCells.Count > 0)
            {
                int selectedRowIndex = dgvSuaDH.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = dgvSuaDH.Rows[selectedRowIndex];

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

                dgvSuaDH.Refresh();
            }
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

        private void txtSoLuong_EditValueChanged(object sender, EventArgs e)
        {
            ThanhTien();
        }

        private void txtGiaNhap_EditValueChanged(object sender, EventArgs e)
        {
            ThanhTien();
        }
    }
}