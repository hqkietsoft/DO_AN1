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

namespace DO_AN_1
{
    public partial class QLNH_CNThemDH : DevExpress.XtraEditors.XtraForm
    {
        string duongdan = "";
        public QLNH_CNThemDH()
        {
            InitializeComponent();
            
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
        }

        private void btnThem_Click(object sender, EventArgs e)
        {

        }
    }
}