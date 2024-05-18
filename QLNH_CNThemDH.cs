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
        string duongdan = "";
        public QLNH_CNThemDH()
        {
            InitializeComponent();
            ccbMaNhanVien.DropDown += new EventHandler(ccbMaNhanVien_DropDown);
            ccbMaNhanVien.DropDownClosed += new EventHandler(ccbMaNhanVien_DropDownClosed);
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

        private void btnChonAnh_Click(object sender, EventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            if (op.ShowDialog() == DialogResult.OK)
            {
                duongdan = op.FileName.ToString();
            }
            pAnh.Image = Image.FromFile(duongdan);
        }

        private void btnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (dgvThemDH.SelectedCells.Count > 0)
            {
                int selectedRowIndex = dgvThemDH.SelectedCells[0].RowIndex;
                dgvThemDH.Rows.RemoveAt(selectedRowIndex);
            }
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

        private void cbbTenNCC_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void labelControl3_Click(object sender, EventArgs e)
        {

        }


        private void cbbTenNCC_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            cbbTenSanPham.Properties.Items.Clear();
            string selectedSupplier = cbbTenNCC.SelectedItem.ToString();
            List<string> products = GetProductsForSupplier(selectedSupplier);
            cbbTenSanPham.Properties.Items.AddRange(products);

            txtTenNSX.Text = cbbTenNCC.Text;
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
            if (string.IsNullOrEmpty(txtMaSanPham.Text))
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

            if (string.IsNullOrEmpty(cbbTenSanPham.Text))
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
            if (string.IsNullOrEmpty(cbbDonViTinh.Text))
            {
                fieldsNotEntered.Add("Đơn vị tính");
                ccbMaNhanVien.Focus();
            }
            if (string.IsNullOrEmpty(txtGiaNhap.Text))
            {
                fieldsNotEntered.Add("Giá nhập");
                txtMaPhieu.Focus();
            }

            if (string.IsNullOrEmpty(txtDonGia.Text))
            {
                fieldsNotEntered.Add("Đơn giá");
                ccbMaNhanVien.Focus();
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


            if (KiemTraTonTaiMaPhieu(txtMaPhieu.Text))
            {
                MessageBox.Show("Mã phiếu đã tồn tại. Vui lòng nhập lại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaPhieu.Clear();
                txtMaPhieu.Focus();
                return;
            }

            object[] values = {
                txtMaPhieu.Text,
                ccbMaNhanVien.Text,
                txtMaSanPham.Text,
                cbbTenNCC.Text,
                txtTenNSX.Text,
                cbbTenSanPham.Text,
                dteNgayLap.Text,
                txtSoLuong.Text,
                cbbDonViTinh.Text,
                txtGiaNhap.Text,
                txtDonGia.Text,
                txtTongTien.Text,
                txtGhiChuSP.Text
            };

            dgvThemDH.Rows.Add(values);

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

        private bool KiemTraTonTaiMaPhieu(string maPhieu)
        {
            using (SqlConnection con = new SqlConnection(@"Data Source=DAFF;Initial Catalog=quanLyKDLaptop;Integrated Security=True;Encrypt=False"))
            {
                con.Open();
                string query = "SELECT COUNT(*) FROM PhieuNhapHang WHERE MaPhieu = @MaPhieu";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@MaPhieu", maPhieu);
                int count = (int)cmd.ExecuteScalar();
                return count > 0;
            }
        }

        private void cbbTenSanPham_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void ccbMaNhanVien_SelectedIndexChanged(object sender, EventArgs e)
        {
            
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

            ccbMaNhanVien.DisplayMember = "ToString";
            ccbMaNhanVien.ValueMember = "MaNV";
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
        private void ccbMaNhanVien_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            
        }

        private void txtMaPhieu_EditValueChanged(object sender, EventArgs e)
        {

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
            using (SqlConnection con = new SqlConnection(@"Data Source=DAFF;Initial Catalog=quanLyKDLaptop;Integrated Security=True;Encrypt=False"))
            {
                con.Open();
                SqlTransaction transaction = con.BeginTransaction();

                try
                {
                    foreach (DataGridViewRow row in dgvThemDH.Rows)
                    {
                        if (row.IsNewRow) continue; // Bỏ qua dòng mới chưa được nhập

                        // Lấy các giá trị từ DataGridView
                        string maPhieu = row.Cells["MaPhieu"].Value.ToString();
                        string maNV = row.Cells["MaNV"].Value.ToString();
                        string tenNCC = row.Cells["TenNCC"].Value.ToString();
                        DateTime ngayLap = Convert.ToDateTime(row.Cells["NgayLap"].Value);
                        decimal tongTien = Convert.ToDecimal(row.Cells["TongTien"].Value);
                        string tenSP = row.Cells["TenSP"].Value.ToString();
                        int soLuongNhap = Convert.ToInt32(row.Cells["SoLuongNhap"].Value);
                        decimal giaNhap = Convert.ToDecimal(row.Cells["GiaNhap"].Value);
                        string ghiChu = row.Cells["GhiChu"].Value.ToString();
                        string donViTinh = row.Cells["DonViTinh"].Value.ToString();
                        string tenNSX = row.Cells["TenNSX"].Value.ToString();
                        decimal donGia = Convert.ToDecimal(row.Cells["DonGia"].Value);

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


                        string maSPHoaDon = row.Cells["MaSP"].Value.ToString();

                        // Kiểm tra xem mã sản phẩm đã tồn tại trong bảng SanPham chưa
                        string queryCheckSP = "SELECT MaSP FROM SanPham WHERE TenSP = @TenSP";
                        SqlCommand cmdCheckSP = new SqlCommand(queryCheckSP, con, transaction);
                        cmdCheckSP.Parameters.AddWithValue("@TenSP", maSPHoaDon);
                        object maSPObject = cmdCheckSP.ExecuteScalar();

                        string maSPMoi = ""; // Khởi tạo biến lưu MaSP mới

                        if (maSPObject != null)
                        {
                            // Nếu sản phẩm đã tồn tại, lấy MaSP từ bảng SanPham
                            maSPMoi = maSPObject.ToString();
                        }
                        else
                        {
                            string maSPTimeBased = "";

                            if (int.TryParse(maSPHoaDon, out _))
                            {
                                // Nếu mã sản phẩm nhập vào là một số, sử dụng nó làm mã sản phẩm
                                maSPTimeBased = maSPHoaDon;
                            }
                            else
                            {
                                // Nếu mã sản phẩm nhập vào không hợp lệ, tạo mã SP dựa trên thời gian hiện tại
                                maSPTimeBased = maSPHoaDon;
                            }

                            // Thêm vào bảng SanPham
                            string queryInsertSP = @"INSERT INTO SanPham (MaSP, TenSP, DonViTinh, TenNSX, DonGia) 
                            VALUES (@MaSP, @TenSP, @DonViTinh, @TenNSX, @DonGia)";
                            SqlCommand cmdInsertSP = new SqlCommand(queryInsertSP, con, transaction);
                            cmdInsertSP.Parameters.AddWithValue("@MaSP", maSPTimeBased);
                            cmdInsertSP.Parameters.AddWithValue("@TenSP", tenSP); // Sử dụng mã sản phẩm từ hóa đơn
                            cmdInsertSP.Parameters.AddWithValue("@DonViTinh", donViTinh);
                            cmdInsertSP.Parameters.AddWithValue("@TenNSX", tenNSX);
                            cmdInsertSP.Parameters.AddWithValue("@DonGia", donGia);
                            cmdInsertSP.ExecuteNonQuery();

                            // Gán MaSP mới
                            maSPMoi = maSPTimeBased;
                        }

                        // Tiếp tục thêm bản ghi vào bảng ChiTietPhieuNhap
                        string queryCTPN = @"INSERT INTO ChiTietPhieuNhap (MaPhieu, MaSP, TenSP, SoLuongNhap, GiaNhap, GhiChu) 
                        VALUES (@MaPhieu, @MaSP, @TenSP, @SoLuongNhap, @GiaNhap, @GhiChu)";
                        SqlCommand cmdCTPN = new SqlCommand(queryCTPN, con, transaction);
                        cmdCTPN.Parameters.AddWithValue("@MaPhieu", maPhieu);
                        cmdCTPN.Parameters.AddWithValue("@MaSP", maSPMoi);
                        cmdCTPN.Parameters.AddWithValue("@TenSP", tenSP); // Sử dụng tên sản phẩm từ hóa đơn
                        cmdCTPN.Parameters.AddWithValue("@SoLuongNhap", soLuongNhap);
                        cmdCTPN.Parameters.AddWithValue("@GiaNhap", giaNhap);
                        cmdCTPN.Parameters.AddWithValue("@GhiChu", ghiChu);
                        cmdCTPN.ExecuteNonQuery();

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

        

        private void dgvThemDH_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvThemDH.Rows[e.RowIndex];

                txtMaPhieu.Text = row.Cells["MaPhieu"].Value.ToString();
                ccbMaNhanVien.Text = row.Cells["MaNV"].Value.ToString();
                txtMaSanPham.Text = row.Cells["MaSP"].Value.ToString();
                cbbTenNCC.Text = row.Cells["TenNCC"].Value.ToString();
                txtTenNSX.Text = row.Cells["TenNSX"].Value.ToString();
                cbbTenSanPham.Text = row.Cells["TenSP"].Value.ToString();
                dteNgayLap.Text = row.Cells["NgayLap"].Value.ToString();
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
                dgvThemDH.Refresh();
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
    }
}