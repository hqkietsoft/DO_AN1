using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database
{
    class NhanvienBLL
    {
        NhanVienDAL dalnv;
        public NhanvienBLL()
        {
            dalnv = new NhanVienDAL();
            
        }
        public DataSet getAllNV()
        {
            return dalnv.getAllNV();
        }
        public bool ThemNV(tblNhanvien nv)
        {
            return dalnv.ThemNV(nv);
        }
        public bool SuaNV(tblNhanvien nv)
        {
            return dalnv.SuaNV(nv);
        }
        public bool XoaNV(tblNhanvien nv)
        {
            return dalnv.XoaNV(nv);
        }
    }
}
