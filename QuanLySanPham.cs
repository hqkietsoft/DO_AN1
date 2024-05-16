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
            DuaDLVaoBang();
            ketnoi.layDLhienthilenCombobox(cboMaLoai, "select MaLoai from LoaiHang", "MaLoai");
            ketnoi.layDLhienthilenCombobox(cboSoLuongNhap, "select SoLuongNhap from ChiTietPhieuNhap", "SoLuongNhap");
            ketnoi.layDLhienthilenCombobox(cboGiaNhap, "select GiaNhap from ChiTietPhieuNhap", "GiaNhap");
            ketnoi.layDLhienthilenCombobox(cboSoLuongBan, "select SoLuongBan from ChiTietHoaDon", "SoLuongBan");
            ketnoi.layDLhienthilenCombobox(cboGiaBan, "select GiaBan from ChiTietHoaDon", "GiaBan");
        }
        void DuaDLVaoBang()
        {
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
                cboSoLuongNhap.Text = row.Cells[6].Value.ToString();
                cboGiaNhap.Text = row.Cells[7].Value.ToString();
                cboSoLuongBan.Text = row.Cells[8].Value.ToString();
                cboGiaBan.Text = row.Cells[9].Value.ToString();
                row.Cells[0].ReadOnly = true;
                row.Cells[1].ReadOnly = true;
                row.Cells[2].ReadOnly = true;
                row.Cells[3].ReadOnly = true;
                row.Cells[4].ReadOnly = true;
                row.Cells[5].ReadOnly = true;
                row.Cells[6].ReadOnly = true;
                row.Cells[7].ReadOnly = true;
                row.Cells[8].ReadOnly = true;
                row.Cells[9].ReadOnly = true;
            }
            txtmasp.ReadOnly = true;
        }
        
    }
}