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
using System.Data;
using System.Data.SqlClient;

namespace DO_AN_1
{
    public partial class QLSP : DevExpress.XtraEditors.XtraForm
    {
        Connection ketnoi = new Connection();
        public QLSP()
        {
            InitializeComponent();
            DuaDLVaoBangSP();
            DuaDLVaoBangLoaiHang();
            DuaDLVaoBangCNSP();
            ketnoi.layDLhienthilenCombobox(cboMaLoai, "select MaLoai from LoaiHang", "MaLoai");
            
            // ketnoi.layDLhienthilenCombobox(cboma, "select SoLuongNhap from ChiTietPhieuNhap", "SoLuongNhap");
            //ketnoi.layDLhienthilenCombobox(cboGiaNhap, "select GiaNhap from ChiTietPhieuNhap", "GiaNhap");
            //ketnoi.layDLhienthilenCombobox(cboSoLuongBan, "select SoLuongBan from ChiTietHoaDon", "SoLuongBan");
            //ketnoi.layDLhienthilenCombobox(cboGiaBan, "select GiaBan from ChiTietHoaDon", "GiaBan");

        }

        /// <summary>
        ///                 CODE CHO TABCONTROL 'CẬP NHẬT SẢN PHẨM'
        /// </summary>
        void DuaDLVaoBangSP()
        {
            //Code đưa thông tin lên bảng cho "Cập nhật sản phẩm"
            dgvQuanLySanPham.DataSource = ketnoi.getDSSanPham();
            


        }
        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void dgvQuanLySanPham_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = e.RowIndex;
            if(i>=0)
            {
                DataGridViewRow row = new DataGridViewRow();
                row = dgvQuanLySanPham.Rows[i];
                txtmasp.Text = row.Cells[0].Value.ToString();
                txttensp.Text = row.Cells[1].Value.ToString();
                txtdonvitinh.Text = row.Cells[2].Value.ToString();
                cboMaLoai.Text = row.Cells[3].Value.ToString();
                txttennsx.Text = row.Cells[4].Value.ToString();
                txtdongia.Text = row.Cells[5].Value.ToString();
                row.Cells[0].ReadOnly = true;
                row.Cells[1].ReadOnly = true;
                row.Cells[2].ReadOnly = true;
                row.Cells[3].ReadOnly = true;
                row.Cells[4].ReadOnly = true;
                row.Cells[5].ReadOnly = true;
            }
           // txtmasp.ReadOnly = true;
        }

        //Sự kiện nút bỏ qua sản phẩm(reset)
        private void btnboqua_Click(object sender, EventArgs e)
        {
            btnLuu.Enabled = false;
            btnboqua.Enabled = false;
            btnthem.Enabled = true;
            btnsua.Enabled = true;
            btnxoa.Enabled = true;
            txtmasp .Enabled = true;
        }


        //Code vieets ngayf 17/5/2024
        //Hàm kiểm tra rỗng sản phẩm: true-đã nhập DL, false-Chư nhập DL
        bool kiemTraRongSP()
        {
            if (txtmasp.Text.Trim() == "") return false;
            if (txttennsx.Text.Trim() == "") return false;
            if (txtdonvitinh.Text.Trim() == "") return false;
            if (cboMaLoai.Text.Trim() == "") return false;
            if (txttennsx.Text.Trim() == "") return false;
            if (txtdongia.Text.Trim() == "") return false;
            return true;
        }

        //Hàm xoá 
        void clearsTextSP()
        {
            txtmasp.Text = "";
            txttensp.Text = "";
            txtdonvitinh.Text = "";
            cboMaLoai.Text = "";
            txttennsx.Text = "";
            txtdongia.Text = "";
        }

        //Sự kiện nút thêm sản phẩm
        private void btnthem_Click(object sender, EventArgs e)
        {
            if(!kiemTraRongSP())
            {
                MessageBox.Show("Chưa nhập đủ thông tin!","Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Information);
                return;
            }
            string ma = txtmasp.Text.Trim();
            string ten = txttensp.Text;
            string dvt = txtdonvitinh.Text;
            string maloai = cboMaLoai.Text;
            string tennsx = txttennsx.Text;
            string dongia = txtdongia.Text;
            if(ketnoi.tontaiSP(ma))
            {
                MessageBox.Show("Mã sản phẩm đã tồn tại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            ketnoi.themSanPham(ma, ten, dvt, maloai, tennsx, dongia);
            DuaDLVaoBangSP();
            clearsTextSP();
        }


        //Sự kiện nút xoá sản phẩm
        private void btnxoa_Click(object sender, EventArgs e)
        {
            if(txtmasp.Text.Trim()!="")
            {
                if(MessageBox.Show("Bạn chắc chắn muốn xoá không?","Thông báo",MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.Yes)
                {
                    ketnoi.xoaSP(txtmasp.Text.Trim());
                    DuaDLVaoBangSP();
                    clearsTextSP();
                }    
                else
                {
                    MessageBox.Show("Không thể xoá!");
                }    
            }    
        }

        //Sự kiện nút thoát sản phẩm
        private void btnthoat_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Bạn có muốn thoát không?","Thông báo",MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.Yes)
            {
                this.Dispose();
            }    
        }

        //Sự kiện nút sửa sản phẩm
        private void btnsua_Click(object sender, EventArgs e)
        {
            if(txtmasp.Text.Trim()=="")
            {
                MessageBox.Show("Bạn chưa chọn sản phẩm cần sửa thông tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }    
            if(!ketnoi.tontaiSP(txtmasp.Text.Trim()))
            {
                MessageBox.Show("Mã sản phẩm không tồn tại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            btnLuu.Enabled = true;
            btnboqua.Enabled = true;
            btnthem.Enabled = true;
            btnsua.Enabled = true;
            btnxoa.Enabled = true;
            txtmasp.Enabled = false;
        }

        //Sự kiện nút lưu sản phẩm
        private void btnLuu_Click(object sender, EventArgs e)
        {
            if(!kiemTraRongSP())
            {
                MessageBox.Show("Chưa nhập đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string ma = txtmasp.Text.Trim();
            string ten = txttensp.Text;
            string dvt = txtdonvitinh.Text;
            string maloai = cboMaLoai.Text;
            string tennsx = txttennsx.Text;
            string dongia = txtdongia.Text;
            ketnoi.capnhatSanPham(ma, ten, dvt, maloai, tennsx, dongia);

            DuaDLVaoBangSP();
            clearsTextSP();
            btnLuu.Enabled = false;
            btnboqua.Enabled = false;
            btnthem.Enabled = true;
            btnsua.Enabled = true;
            btnxoa.Enabled = true;
            txtmasp.Enabled = true;
            MessageBox.Show("Đã sửa thông tin có mã " + ma);
        }


        /*-----------------CODE CHO TABCONTROL 'CẬP NHẬT LOẠI HÀNG'---------------------*/
        /*--------20-05-2024-----------------------*/

        public void DuaDLVaoBangLoaiHang()
        {
            //Code đưa thông tin lên bảng cho "Cập nhật loại hàng"
            dgvCapNhatLoaiHang.DataSource = ketnoi.getDSLoaiHang();
        }

        //Sự kiện click chọn hàng đưa lên các ô textbox
        private void dgvCapNhatLoaiHang_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = e.RowIndex;
            if (i >= 0)
            {
                DataGridViewRow row = new DataGridViewRow();
                row = dgvCapNhatLoaiHang.Rows[i];
                txtmaloailh.Text = row.Cells[0].Value.ToString();
                cbotenhanglh.Text = row.Cells[1].Value.ToString();
                txttinhtranglh.Text = row.Cells[2].Value.ToString();
                txtgiabanlh.Text = row.Cells[3].Value.ToString();
                txtsoluonglh.Text = row.Cells[4].Value.ToString();
                txtmotalh.Text = row.Cells[5].Value.ToString();

            }
        }

        //Hàm kiểm tra rỗng loại hàng: true-đã nhập DL, false-Chư nhập DL
        bool kiemTraRongLH()
        {
            if (txtmaloailh.Text.Trim() == "") return false;
            if (cbotenhanglh.Text.Trim() == "") return false;
            if (txttinhtranglh.Text.Trim() == "") return false;
            if (txtgiabanlh.Text.Trim() == "") return false;
            if (txtsoluonglh.Text.Trim() == "") return false;
            if (txtmotalh.Text.Trim() == "") return false;
            return true;
        }

        //hàm xoá 
        void clearsTextLH()
        {
            txtmaloailh.Text = "";
            cbotenhanglh.Text = "";
            txttinhtranglh.Text = "";
            txtgiabanlh.Text = "";
            txtsoluonglh.Text = "";
            txtmotalh.Text = "";
        }

        //Sự kiện nút thêm loại hàng
        private void btnthemlh_Click(object sender, EventArgs e)
        {
            if (!kiemTraRongLH())
            {
                MessageBox.Show("Chưa nhập đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            string maloai = txtmaloailh.Text.Trim();
            string tenhang = cbotenhanglh.Text;
            string tinhtrang = txttinhtranglh.Text;
            string giaban = txtgiabanlh.Text;
            string soluong = txtsoluonglh.Text;
            string mota = txtmotalh.Text;
            if (ketnoi.tontaiLH(maloai))
            {
                MessageBox.Show("Mã loại hàng đã tồn tại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            ketnoi.themLoaiHang(maloai, tenhang, tinhtrang, giaban, soluong, mota);
            DuaDLVaoBangLoaiHang();
            
            clearsTextLH();
        }

        //Sự kiện nút sửa loại hàng
        private void btnsualh_Click(object sender, EventArgs e)
        {
            if (txtmaloailh.Text.Trim() == "")
            {
                MessageBox.Show("Bạn chưa chọn loại hàng cần sửa thông tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (!ketnoi.tontaiLH(txtmaloailh.Text.Trim()))
            {
                MessageBox.Show("Mã loại hàng không tồn tại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            btnluutlh.Enabled = true;
            btnboqualh.Enabled = true;
            btnthemlh.Enabled = true;
            btnsualh.Enabled = true;
            btnxoalh.Enabled = true;
            txtmaloailh.Enabled = false;
        }

        //Sự kiện nút xoá loại hàng
        private void btnxoalh_Click(object sender, EventArgs e)
        {
            if (txtmaloailh.Text.Trim() != "")
            {
                if (MessageBox.Show("Bạn chắc chắn muốn xoá không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    ketnoi.xoaLoaiHang(txtmaloailh.Text.Trim());
                    DuaDLVaoBangLoaiHang();
                    clearsTextLH();
                }
                else
                {
                    MessageBox.Show("Không thể xoá!");
                }
            }
        }

        //Sự kiện nút bỏ qua loại hàng(reset)
        private void btnboqualh_Click(object sender, EventArgs e)
        {
            btnluutlh.Enabled = false;
            btnboqualh.Enabled = false;
            btnthemlh.Enabled = true;
            btnsualh.Enabled = true;
            btnxoalh.Enabled = true;
            txtmaloailh.Enabled = true;
        }

        //Sự kiện nút lưu loại hàng
        private void btnluutlh_Click(object sender, EventArgs e)
        {
            if (!kiemTraRongLH())
            {
                MessageBox.Show("Chưa nhập đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string maloai = txtmaloailh.Text.Trim();
            string tenhang = cbotenhanglh.Text;
            string tinhtrang = txttinhtranglh.Text;
            string giaban = txtgiabanlh.Text;
            string soluong = txtsoluonglh.Text;
            string mota = txtmotalh.Text;
            ketnoi.capnhatLoaiHang(maloai, tenhang, tinhtrang, giaban, soluong, mota) ;
            DuaDLVaoBangLoaiHang();
            clearsTextLH();
            btnluutlh.Enabled = false;
            btnboqualh.Enabled = false;
            btnthemlh.Enabled = true;
            btnsualh.Enabled = true;
            btnxoalh.Enabled = true;
            txtmaloailh.Enabled = true;
            MessageBox.Show("Đã sửa thông tin có mã " + maloai);
        }

        //Sự kiện nút thoát
        private void btnthoatlh_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn thoát không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Dispose();
            }
        }

        /*-----------------CODE CHO TABCONTROL 'TÌM KIẾM SẢN PHẨM'---------------------*/
        /*--------24-05-2024-----------------------*/

        private void btntk_Click(object sender, EventArgs e)
        {
            string tukhoa = txttimkiem.Text.Trim();
            if(rdomasp.Checked)
            {
                dgvtkmasanpham.DataSource = ketnoi.TKTheoMaSP(tukhoa);
            }
            else
            {
                dgvtkmasanpham.DataSource = ketnoi.TKTheoTen(tukhoa);
            }
            
        }

        /*-----------------CODE CHO TABCONTROL 'CẬP NHẬT GIÁ'---------------------*/
        /*--------24-05-2024-----------------------*/

        private void btnthoatcng_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cboma_SelectedIndexChanged(object sender, EventArgs e)
        {
            ketnoi.hienthithongtinSP(txtten,txtgia,cboma);
            
        }

        private void tabPage3_Click(object sender, EventArgs e)
        {

        }


        //Load cbo mã
        private void QLSP_Load(object sender, EventArgs e)
        {
            cboma.Text = "---Chọn mã SP---";
            foreach (DataRow item in ketnoi.LaydulieuSP().Rows)
            {

                cboma.Items.Add(item["MaSP"]);
            }
        }

        private void btnsuacapnhatgia_Click(object sender, EventArgs e)
        {
            if (cboma.Text.Trim() == "")
            {
                MessageBox.Show("Bạn chưa chọn sản phẩm cần sửa thông tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (!ketnoi.tontaiSP(cboma.Text.Trim()))
            {
                MessageBox.Show("Mã sản phẩm không tồn tại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            btnluutlh.Enabled = true;
            btnboqualh.Enabled = true;
            btnsualh.Enabled = true;
            btnxoalh.Enabled = true;
            cboma.Enabled = false;
        }

        bool kiemTraRongCapNhatGia()
        {
            if (cboma.Text.Trim() == "") return false;
            if (txtten.Text.Trim() == "") return false;
            if (txtgia.Text.Trim() == "") return false;
            return true;
        }

        private void dgvcapnhatgia_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = e.RowIndex;
            if (i >= 0)
            {
                DataGridViewRow row = new DataGridViewRow();
                row = dgvcapnhatgia.Rows[i];
                cboma.Text = row.Cells[0].Value.ToString();
                txtten.Text = row.Cells[1].Value.ToString();
                txtgia.Text = row.Cells[2].Value.ToString();
                row.Cells[0].ReadOnly = true;
                row.Cells[1].ReadOnly = true;
                row.Cells[2].ReadOnly = true;
            }
        }

        void DuaDLVaoBangCNSP()
        {
            //Code đưa thông tin lên bảng cho "Cập nhật sản phẩm"
            dgvcapnhatgia.DataSource = ketnoi.getDSCNSanPham();
        }

        private void btnboquacapnhatgia_Click(object sender, EventArgs e)
        {

            btnluucapnhatgia.Enabled = false;
            btnboquacapnhatgia.Enabled = false;
            btnsuacapnhatgia.Enabled = true;
            //btnxoacapnhatgia.Enabled = true;
            cboma.Enabled = true;
        }

        void clearsTextCapNhatGia()
        {
            cboma.Text = "";
            txtten.Text = "";
            txtgia.Text = "";
        }


        //private void btnxoacapnhatgia_Click(object sender, EventArgs e)
        //{
        //    if (cboma.Text.Trim() != "")
        //    {
        //        if (MessageBox.Show("Bạn chắc chắn muốn xoá không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
        //        {
        //            ketnoi.xoaGiaBan(txtmaloailh.Text.Trim());
        //            DuaDLVaoBangLoaiHang();
        //            clearsTextCapNhatGia();
        //        }
        //        else
        //        {
        //            MessageBox.Show("Không thể xoá!");
        //        }
        //    }
        //}

        private void btnluucapnhatgia_Click(object sender, EventArgs e)
        {
            if (!kiemTraRongCapNhatGia())
            {
                MessageBox.Show("Chưa nhập đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string masp = cboma.Text.Trim();
            string tensp = txtten.Text;
            string dongia = txtgia.Text;
            ketnoi.capnhatGia(masp, tensp, dongia);
            DuaDLVaoBangCNSP();
            clearsTextCapNhatGia();
            btnluucapnhatgia.Enabled = false;
            btnboquacapnhatgia.Enabled = false;
            btnsuacapnhatgia.Enabled = true;
            //btnxoacapnhatgia.Enabled = true;
            cboma.Enabled = true;
            MessageBox.Show("Đã sửa thông tin có mã " + masp);
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            dgvCapNhatLoaiHang.DataSource = ketnoi.getDSLoaiHang();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dgvQuanLySanPham.DataSource = ketnoi.getDSSanPham();
        }
    }
}