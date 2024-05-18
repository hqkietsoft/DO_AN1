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
        public QLNH_CNSuaDH(List<DonHang> danhSachDonHang)
        {
            InitializeComponent();
            ccbMaNhanVien.DropDown += new EventHandler(ccbMaNhanVien_DropDown);
            ccbMaNhanVien.DropDownClosed += new EventHandler(ccbMaNhanVien_DropDownClosed);
            HienThiDonHang(danhSachDonHang);
        }


        private void HienThiDonHang(List<DonHang> danhSachDonHang)
        {
            // Xóa dữ liệu hiện có trong dgvSuaHD
            dgvSuaMH.Rows.Clear();

            // Thêm thông tin từ danh sách đơn hàng vào dgvSuaHD
            foreach (DonHang donHang in danhSachDonHang)
            {
                dgvSuaMH.Rows.Add(
                    donHang.MaPhieu,
                    donHang.MaNhanVien,
                    donHang.MaSanPham,
                    donHang.TenNCC,
                    donHang.TenNSX,
                    donHang.TenSanPham,
                    donHang.NgayLap,
                    donHang.SoLuongNhap,
                    donHang.DonViTinh,
                    donHang.GiaNhap,
                    donHang.DonGia,
                    donHang.TongTien,
                    donHang.GhiChu
                );
            }
        }

        public QLNH_CNSuaDH(DataTable dtHoaDon)
        {
            InitializeComponent();
            dgvSuaMH.DataSource = dtHoaDon;
            
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

            cbbTenSanPham.Properties.ReadOnly = true;
            cbbTenNCC.Properties.ReadOnly = true;
            txtMaSanPham.Properties.ReadOnly = true;
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
            using (SqlConnection con = new SqlConnection(@"Data Source=DAFF;Initial Catalog=quanLyKDLaptop;Integrated Security=True;Encrypt=False"))
            {
                con.Open();
                SqlTransaction transaction = con.BeginTransaction();

                try
                {
                    foreach (DataGridViewRow row in dgvSuaMH.Rows)
                    {
                        if (row.IsNewRow || row.Cells["MaPhieu"].Value == null) continue;

                        string maPhieu = row.Cells["MaPhieu"].Value?.ToString();
                        string maNV = row.Cells["MaNV"].Value?.ToString();
                        string maSP = row.Cells["MaSP"].Value?.ToString();
                        string tenNCC = row.Cells["TenNCC"].Value?.ToString();
                        DateTime ngayLap = row.Cells["NgayLap"].Value == null ? DateTime.MinValue : Convert.ToDateTime(row.Cells["NgayLap"].Value);
                        decimal tongTien = row.Cells["TongTien"].Value == null ? 0 : Convert.ToDecimal(row.Cells["TongTien"].Value);
                        string tenSP = row.Cells["TenSP"].Value?.ToString();
                        int soLuongNhap = row.Cells["SoLuongNhap"].Value == null ? 0 : Convert.ToInt32(row.Cells["SoLuongNhap"].Value);
                        decimal giaNhap = row.Cells["GiaNhap"].Value == null ? 0 : Convert.ToDecimal(row.Cells["GiaNhap"].Value);
                        string ghiChu = row.Cells["GhiChu"].Value?.ToString();
                        string donViTinh = row.Cells["DonViTinh"].Value?.ToString();
                        string tenNSX = row.Cells["TenNSX"].Value?.ToString();
                        decimal donGia = row.Cells["DonGia"].Value == null ? 0 : Convert.ToDecimal(row.Cells["DonGia"].Value);

                        

                        
                        // Update bảng PhieuNhapHang
                        string queryUpdatePNH = @"UPDATE PhieuNhapHang 
                              SET MaNV = @MaNV, 
                                  TenNCC = @TenNCC, 
                                  NgayLap = @NgayLap, 
                                  TongTien = @TongTien
                              WHERE MaPhieu = @MaPhieu";
                        SqlCommand cmdUpdatePNH = new SqlCommand(queryUpdatePNH, con, transaction);
                        cmdUpdatePNH.Parameters.AddWithValue("@MaPhieu", maPhieu);
                        cmdUpdatePNH.Parameters.AddWithValue("@MaNV", maNV);
                        cmdUpdatePNH.Parameters.AddWithValue("@TenNCC", tenNCC);
                        cmdUpdatePNH.Parameters.AddWithValue("@NgayLap", ngayLap);
                        cmdUpdatePNH.Parameters.AddWithValue("@TongTien", tongTien);
                        int rowsAffectedPNH = cmdUpdatePNH.ExecuteNonQuery();


                        // Update bảng ChiTietPhieuNhap
                        string queryUpdateCTPN = @"UPDATE ChiTietPhieuNhap 
                           SET SoLuongNhap = @SoLuongNhap, 
                               GiaNhap = @GiaNhap, 
                               GhiChu = @GhiChu
                           WHERE MaPhieu = @MaPhieu";
                        SqlCommand cmdUpdateCTPN = new SqlCommand(queryUpdateCTPN, con, transaction);
                        cmdUpdateCTPN.Parameters.AddWithValue("@MaPhieu", maPhieu);
                        cmdUpdateCTPN.Parameters.AddWithValue("@MaSP", maSP);
                        cmdUpdateCTPN.Parameters.AddWithValue("@SoLuongNhap", soLuongNhap);
                        cmdUpdateCTPN.Parameters.AddWithValue("@GiaNhap", giaNhap);
                        cmdUpdateCTPN.Parameters.AddWithValue("@GhiChu", ghiChu);
                        int rowsAffectedCTPN = cmdUpdateCTPN.ExecuteNonQuery();

                        // Update bảng SanPham
                        string queryUpdateSP = @"UPDATE SanPham 
                             SET TenSP = @TenSP,
                                 DonViTinh = @DonViTinh, 
                                 TenNSX = @TenNSX, 
                                 DonGia = @DonGia 
                             WHERE MaSP = @MaSP";
                        SqlCommand cmdUpdateSP = new SqlCommand(queryUpdateSP, con, transaction);
                        cmdUpdateSP.Parameters.AddWithValue("@MaSP", maSP);
                        cmdUpdateSP.Parameters.AddWithValue("@TenSP", tenSP);
                        cmdUpdateSP.Parameters.AddWithValue("@DonViTinh", donViTinh);
                        cmdUpdateSP.Parameters.AddWithValue("@TenNSX", tenNSX);
                        cmdUpdateSP.Parameters.AddWithValue("@DonGia", donGia);
                        int rowsAffectedSP = cmdUpdateSP.ExecuteNonQuery();
                    }
                    transaction.Commit();
                    MessageBox.Show("Đã lưu thông tin thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            cbbTenSanPham.Properties.ReadOnly = true;
        }

        private void cbbTenNCC_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbbTenSanPham.Properties.Items.Clear();
            string selectedSupplier = cbbTenNCC.SelectedItem.ToString();
            List<string> products = GetProductsForSupplier(selectedSupplier);
            cbbTenSanPham.Properties.Items.AddRange(products);

            txtTenNSX.Text = cbbTenNCC.Text;
            
        }

        private List<string> GetProductsForSupplier(string selectedSupplier)
        {

            List<string> products = new List<string>();


            if (selectedSupplier == "Asus")
            {
                products.Add("Asus ROG Strix G15 G614");
                products.Add("Asus ROG Strix G16 G614");
                products.Add("Asus ROG Zephyrus M16 GU603");
                products.Add("Asus ROG Flow X13 GV305");
                products.Add("Asus TUF Gaming F15 FX507");
                products.Add("Asus TUF Gaming F17 FX707");
                products.Add("Asus TUF Gaming A15 FA507");
                products.Add("Asus TUF Gaming A17 FA707");
                products.Add("Asus TUF Gaming Dash F15 FX517");
                products.Add("Asus TUF Gaming Dash F17 FX717");
                products.Add("Asus Vivobook Pro 16X OLED M6600");
                products.Add("Asus Vivobook Pro 14 OLED M3401");
                products.Add("Asus Chromebook Flip CX570");
                products.Add("Asus Chromebook Vibe CX550");
            }

            else if (selectedSupplier == "Acer")
            {
                products.Add("Acer Nitro 5 AN515-57-5669");
                products.Add("Acer Nitro 5 AN515-58-57VH");
                products.Add("Acer Nitro 5 AN515-59-593UH");
                products.Add("Acer Nitro 16 AN16-51-57U1");
                products.Add("Acer Nitro 17 AN17-51-57UX");
                products.Add("Acer Predator Helios 300 PH315-55-77U9");
                products.Add("Acer Predator Helios 300 PH315-56-77VH");
                products.Add("Acer Predator Helios 300 PH315-57-79UH");
                products.Add("Acer Aspire 7 A715-56-57VQ");
            }

            else if (selectedSupplier == "Apple Macbook")
            {
                products.Add("MacBook Pro 16 inch (2023)");
                products.Add("MacBook Pro 14 inch (2023)");
                products.Add("MacBook Air M2 (2022)");
                products.Add("MacBook Pro 13 inch (2022)");
                products.Add("MacBook Pro 16 inch (2023)");
            }

            else if (selectedSupplier == "HP")
            {
                products.Add("HP Victus 15 FHD1626TU");
                products.Add("HP Victus 15 FHD1627TU");
                products.Add("HP Victus 15 FHD1628TU");
                products.Add("HP Omen 15-dh1053TX");
                products.Add("HP Omen 15-dh1054TX");
                products.Add("HP Omen 15-dh1055TX");
                products.Add("HP Pavilion Gaming 15-ec2001TU");
                products.Add("HP Pavilion Gaming 15-ec2003TU");
                products.Add("HP Spectre x360 14-ea0053TU");
                products.Add("HP Spectre x360 14-ea0055TU");

            }

            else if (selectedSupplier == "Razer")
            {
                products.Add("Razer Blade 14 (2023)");
                products.Add("Razer Blade 15 (2023)");
                products.Add("Razer Blade 17 (2023)");
                products.Add("Razer Blade 18 (2023)");
                products.Add("Razer Stealth 13 (2023)");
                products.Add("Razer Stealth 14 (2023)");
                products.Add("Razer Book 13 (2023)");
                products.Add("Razer Book 14 (2023)");
            }

            else if (selectedSupplier == "MSI")
            {
                products.Add("MSI GE66 Raider 12UGS-093VN");
                products.Add("MSI GE66 Raider 12UGS-209VN");
                products.Add("MSI Stealth 15M HS13VS-040VN");
                products.Add("MSI Stealth 17M HS13VS-041V");
                products.Add("MSI Katana GF66 12UGS-044VN");
                products.Add("MSI Katana GF76 12UGS-045VN");
                products.Add("MSI Sword 15 CB13VS-008VN");
            }

            else if (selectedSupplier == "Dell")
            {
                products.Add("Dell G15 5525 R7H165W11GR3060");
                products.Add("Dell G15 5528 R7H165W11GR3070");
                products.Add("Dell Inspiron 3511 70270650");
                products.Add("Dell Inspiron 3520 70270658");
                products.Add("Dell Vostro 3510 7T2YC2");
                products.Add("Dell Vostro 3520 P112F002BBL");
                products.Add("Dell Latitude 3520");
                products.Add("Dell XPS 13 9310");
            }

            else if (selectedSupplier == "Lenovo")
            {
                products.Add("Lenovo Legion 5 15ACH6H-83RD0002VN");
                products.Add("Lenovo Legion 5 15ACH6H-83RD0003VN");
                products.Add("Lenovo Legion 5 Pro 16ACH6H-83RB0001VN:");
                products.Add("Lenovo ThinkPad P1 Gen 5");
                products.Add("Lenovo IdeaPad Slim 3 15ITL6-82K20003VN");
                products.Add("Lenovo IdeaPad Slim 5 15ITL6-83K20003VN");
                products.Add("Lenovo Chromebook Flex 5 13CTL6-83K20003VN");
                products.Add("Lenovo Chromebook Flex 5 13CTL6-83K20004VN");
            }

            else if (selectedSupplier == "Gigabyte")
            {
                products.Add("Gigabyte AORUS 15 BKF 73VN754SH");
                products.Add("Gigabyte AORUS 15 BMF 52US383SH");
                products.Add("Gigabyte AERO 15 XE5-99US754SH");
                products.Add("Gigabyte AERO 16 XE5-99US154SH");
                products.Add("Gigabyte Creator 5 17CF1-99US754SH");
                products.Add("Gigabyte Creator 5 15CF1-99US754SH");
                products.Add("Gigabyte Aero 15 XE5-99US554SH");
                products.Add("Gigabyte AERO 16 XE5-99US354SH");
                products.Add("Gigabyte AERO 15 XE5-57US354SH");
            }

            else if (selectedSupplier == "Samsung")
            {
                products.Add("Samsung Galaxy Book Pro 360 15 NP950YCM-K01US");
                products.Add("Samsung Galaxy Book Ion 15 NP950XCJ-K01US");
                products.Add("Samsung Notebook 9 Pro 15 NP940YCM-K01US");
                products.Add("Samsung Chromebook 4+ 15 XE500YCM-K01US");
                products.Add("Samsung Galaxy Book2 Pro 15 NP950YCM-K01US");
            }

            else if (selectedSupplier == "Microsoft")
            {
                products.Add("Microsoft Surface Laptop Studio 14-4155");
                products.Add("Microsoft Surface Laptop 5 15-4153");
                products.Add("Microsoft Surface Laptop 4 15-4081");
                products.Add("Microsoft Surface Laptop Studio 16-4170");
                products.Add("Microsoft Surface Laptop 5 13-4158");
                products.Add("Microsoft Surface Pro 8 13-4171");
            }

            else if (selectedSupplier == "Huwei")
            {
                products.Add("Huawei MateBook X Pro 14 2023");
                products.Add("Huawei MateBook X 14 2023");
                products.Add("Huawei MateBook 14 2023");
                products.Add("Huawei IdeaPad Slim 5 14 2023");
                products.Add("Huawei MateBook E 2023");
                products.Add("Huawei MatePad 11 2023");
            }

            return products;
        }

        private void dgvSuaMH_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Ensure that the user clicks on a valid row
            {
                DataGridViewRow row = dgvSuaMH.Rows[e.RowIndex];

                // Populate the textboxes and comboboxes
                txtMaPhieu.Text = row.Cells["MaPhieu"].Value.ToString();
                ccbMaNhanVien.Text = row.Cells["MaNV"].Value.ToString();
                txtMaSanPham.Text = row.Cells["MaSP"].Value.ToString();
                cbbTenNCC.Text = row.Cells["TenNCC"].Value.ToString();
                txtTenNSX.Text = row.Cells["TenNSX"].Value.ToString();
                cbbTenSanPham.Text = row.Cells["TenSP"].Value.ToString();
                dteNgayLap.Text = Convert.ToDateTime(row.Cells["NgayLap"].Value).ToString("dd/MM/yyyy");
                txtSoLuong.Text = row.Cells["SoLuongNhap"].Value.ToString();
                cbbDonViTinh.Text = row.Cells["DonViTinh"].Value.ToString();
                txtGiaNhap.Text = row.Cells["GiaNhap"].Value.ToString();
                txtDonGia.Text = row.Cells["DonGia"].Value.ToString();
                txtTongTien.Text = row.Cells["TongTien"].Value.ToString();
                txtGhiChuSP.Text = row.Cells["GhiChu"].Value.ToString();
            }
        }
        private void FormatColumns()
        {
            dgvSuaMH.Columns["NgayLap"].DefaultCellStyle.Format = "dd-MM-yyyy";
        }

        private void txtMaPhieu_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (dgvSuaMH.SelectedRows.Count > 0)
            {
                // Lấy dòng được chọn
                DataGridViewRow selectedRow = dgvSuaMH.SelectedRows[0];

                // Lấy dữ liệu từ dòng được chọn
                string maPhieu = selectedRow.Cells["MaPhieu"].Value.ToString();

                // Xác nhận việc xóa dòng
                DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xoá dòng này không?", "Xác nhận xoá", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    dgvSuaMH.Rows.Remove(selectedRow);
                    txtMaPhieu.Clear();
                    ccbMaNhanVien.Text = "";
                    dteNgayLap.Text = "";
                    txtMaSanPham.Clear();
                    cbbTenNCC.Text = "";
                    txtTenNSX.Clear();
                    cbbTenSanPham.Text = "";
                    txtSoLuong.Clear();
                    cbbDonViTinh.Text = "";
                    txtGiaNhap.Clear();
                    txtDonGia.Clear();
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
            txtMaSanPham.Clear();
            cbbTenNCC.Text = "";
            txtTenNSX.Clear();
            cbbTenSanPham.Text = "";
            txtSoLuong.Clear();
            cbbDonViTinh.Text = "";
            txtGiaNhap.Clear();
            txtDonGia.Clear();
            txtTongTien.Clear();
            txtGhiChuSP.Clear();
        }

        private void btnSua_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (dgvSuaMH.SelectedCells.Count > 0)
            {
                int selectedRowIndex = dgvSuaMH.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = dgvSuaMH.Rows[selectedRowIndex];

                selectedRow.Cells["MaPhieu"].Value = txtMaPhieu.Text;
                selectedRow.Cells["MaNV"].Value = ccbMaNhanVien.Text;
                selectedRow.Cells["MaSP"].Value = txtMaSanPham.Text;
                selectedRow.Cells["TenNCC"].Value = cbbTenNCC.Text;
                selectedRow.Cells["TenNSX"].Value = txtTenNSX.Text;
                selectedRow.Cells["TenSP"].Value = cbbTenSanPham.Text;
                selectedRow.Cells["NgayLap"].Value = dteNgayLap.Text;
                selectedRow.Cells["SoLuongNhap"].Value = txtSoLuong.Text;
                selectedRow.Cells["DonViTinh"].Value = cbbDonViTinh.Text;
                selectedRow.Cells["GiaNhap"].Value = txtGiaNhap.Text;
                selectedRow.Cells["DonGia"].Value = txtDonGia.Text;
                selectedRow.Cells["TongTien"].Value = txtTongTien.Text;
                selectedRow.Cells["GhiChu"].Value = txtGhiChuSP.Text;

                // Cập nhật lại DataGridView
                dgvSuaMH.Refresh();
            }
        }

        private void txtMaSanPham_EditValueChanged(object sender, EventArgs e)
        {
            
        }
    }
}