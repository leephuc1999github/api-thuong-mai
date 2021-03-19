using library.Models.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    public class KinhDoanh : ModelBaseExt
    {
        [Key]
        private int? _CuaHangId;
        [Key]
        private int? _MatHangId;

        public int? CuaHangId { get { return this._CuaHangId; } set { this._CuaHangId = value; } }
        [ForeignKey("CuaHangId")]
        public virtual CuaHang CuaHang { get; set; }

        public int? MatHangId { get { return this._MatHangId; } set { this._MatHangId = value; } }
        [ForeignKey("MatHangId")]
        public virtual MatHang MatHang { get; set; }
        

    }
}
