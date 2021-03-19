using library.Models.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    public class GiamSat : ModelBaseExt
    {
        [Key]
        [Column(Order = 1)]
        private int? _KhachHangId;

        [Key]
        [Column(Order = 2)]
        private int? _NhanVienBaoVeId;

        [ForeignKey("KhachHangId")]
        public int? KhachHangId { get { return this._KhachHangId; } set { this._KhachHangId = value; } }
        public virtual KhachHang KhachHang { get; set; }

        [ForeignKey("NhanVienBaoVeId")]
        public int? NhanVienBaoVeId { get { return this._NhanVienBaoVeId; } set { this._NhanVienBaoVeId = value; } }
        public virtual NhanVienBaoVe NhanVienBaoVe { get; set; }
    }
}
