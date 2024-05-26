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

namespace Database
{
    public partial class Form1 : Form
    {
        ConnectDB Objcon;
        public Form1()
        {
            InitializeComponent();
            Objcon = new ConnectDB();
            
        }
        public void EnabledReadOnly()
        {
            txtten.ReadOnly = true;
            
        }
        private void btnthoat_Click(object sender, EventArgs e)
        {
            DialogResult ans = MessageBox.Show("Do you want to exit ?", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (ans == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        
        private void btnxoa_Click(object sender, EventArgs e)
        {
            Objcon.DeleteSinhVien(txtma);
            Form1_Load(sender, e);

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Objcon.ShowAllNhanVien(dataGridView1);
            
        }
        public void checkdata()
        {
            if(txtma.Text == "" && txtten.Text == "" && dtp_ngaysinh.Text == "1/1/1900" && rdonam.Checked == false && rdonu.Checked == false && txtdiachi.Text == "" && txtdienthoai.Text == "")
            {
                MessageBox.Show("Ban chua nhap gi ca!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtma.Focus();

            }
            else if(txtma.Text == "")
            {
                MessageBox.Show("Ban chua nhap ma nhan vien!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtma.Focus();
            }
            else if (txtten.Text == "")
            {
                MessageBox.Show("Ban chua nhap ten nhan vien!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtten.Focus();
            }
            else if (dtp_ngaysinh.Text == "1/1/1900")
            {
                MessageBox.Show("Ban chua nhap ngay sinh !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dtp_ngaysinh.Focus();
            }
            else if (rdonam.Checked == false && rdonu.Checked == false)
            {
                MessageBox.Show("Ban chua nhap ma nhan vien!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else if (txtdiachi.Text == "")
            {
                MessageBox.Show("Ban chua nhap dia chi!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtdiachi.Focus();
            }
            else if (txtdienthoai.Text == "")
            {
                MessageBox.Show("Ban chua nhap so dien thoai!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtdienthoai.Focus();
            }

        }

        private void btnthem_Click(object sender, EventArgs e)
        {
            checkdata();
            string gioitinh;
            if(rdonam.Checked == true)
            {
                gioitinh = "nam";
            }
            else
            {
                gioitinh = "nu";
            }

            Objcon.AddSinhVien(txtma, txtten, dtp_ngaysinh, gioitinh, txtdiachi, txtdienthoai);
            Form1_Load(sender, e);
        }

        

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
            txtma.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            txtten.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            dtp_ngaysinh.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            if(dataGridView1.CurrentRow.Cells[3].Value.ToString() == "Nam")
            {
                rdonam.Checked = true;
            }
            else
            {
                rdonu.Checked = true;
            }

            txtdiachi.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            txtdienthoai.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();

        }

        private void btnboqua_Click(object sender, EventArgs e)
        {
            
            txtma.Text = "";
            txtten.Text = "";

            dtp_ngaysinh.Text = "1/1/1900";

            rdonam.Checked = false;
            rdonu.Checked= false;

            txtdiachi.Text = "";

            txtdienthoai.Text = "";
            txtma.Focus();
            txtma.ReadOnly = false;



        }

        
        private void btnsua_Click(object sender, EventArgs e)
        {
            txtma.ReadOnly = true;
            txtten.Focus();
            
        }

        private void btnluu_Click(object sender, EventArgs e)
        {
            string gioitinh;
            if (rdonam.Checked == true)
            {
                gioitinh = "nam";
            }
            else
            {
                gioitinh = "nu";
            }
            Objcon.ModifierSinhVien(txtma, txtten, dtp_ngaysinh, gioitinh, txtdiachi, txtdienthoai);
            Form1_Load(sender, e);
        }
    }
}
