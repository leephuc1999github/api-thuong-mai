using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    public class NhanVienBaoVe : NhanVien
    {
        private string _ChucVu;
        private string _KhuVucQuanLy;

        public string ChucVu { get { return this._ChucVu; } set { this._ChucVu = value; } }
        public string KhuVucQuanLy { get { return this._KhuVucQuanLy; } set { this._KhuVucQuanLy = value; } }
    }
}
