﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using DevExpress.XtraExport.Helpers;
using DevExpress.Xpo.DB.Helpers;

namespace DO_AN_1
{
    public partial class TimKiem_ND : Form
    {
        public TimKiem_ND()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string ketnoi;
            ketnoi = "Data Source=DESKTOP-H2UCOT4\\SQLEXPRESS;Initial Catalog=QLKinhDoanhMayTinh;Integrated Security=True";
            SqlConnection sqlcon= new SqlConnection(ketnoi);
            sqlcon.Open();

            string sql;
            sql = "SELECT * FROM NguoiDung WHERE MaNV = '"+txt_MaNV.Text+"' ";
            SqlDataAdapter sqlda = new SqlDataAdapter(sql, sqlcon);
            DataSet ds = new DataSet();
            sqlda.Fill(ds);
            dgv_timkiem.DataSource = ds.Tables[0];
        }
    }
}
