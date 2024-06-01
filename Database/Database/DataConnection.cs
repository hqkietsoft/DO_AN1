using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
namespace Database
{
    class DataConnection
    {
        string conn;
        public DataConnection()
        {
            conn = "Data Source=DESKTOP-TEOF11\\SQLEXPRESS;Initial Catalog=QuanLyNhanVien;Integrated Security=True";

        }
        public SqlConnection getconnect()
        {
            return new SqlConnection(conn);
        }

    }
}
