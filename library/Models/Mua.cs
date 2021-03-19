using library.Models.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    public class Mua : ModelBaseExt
    {
        [Key]
        [Column(Order = 2)]
        private int? _KhachHangId;
        [Key]
        [Column(Order = 3)]
        private int? _MatHangId;

        public int? KhachHangId { get { return this._KhachHangId; } set { this._KhachHangId = value; } }
        [ForeignKey("KhachHangId")]
        public virtual KhachHang KhacHang { get; set; }

        public int? MatHangId { get { return this._MatHangId; } set { this._MatHangId = value; } }
        [ForeignKey("MatHangId")]
        public virtual MatHang MatHang { get; set; }

    }
}
