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
                row.Cells[0].ReadOnly = true;
                row.Cells[1].ReadOnly = true;
            }
            txtmasp.ReadOnly = true;
        }
    }
}