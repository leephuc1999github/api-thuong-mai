using library.Models;
using library.Models.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    public class HopDong : ModelBaseExt
    {
        [Required(ErrorMessage = "{0} is required")]
        [DataType(DataType.DateTime)]
        private DateTime _NgayKyHopDong;

        [Key]
        [Column(Order = 1)]
        private int? _DoiTacId;

        [Key]
        [Column(Order = 2)]
        private int? _NhanVienDaiDienId;



        [ForeignKey("DoiTacId")]
        public int? DoiTacId { get { return this._DoiTacId; } set { this._DoiTacId = value; } }
        public virtual DoiTac DoiTac { get; set; }

        [ForeignKey("NhanVienDaiDienId")]
        public int? NhanVienDaiDienId { get { return this._NhanVienDaiDienId; } set { this._NhanVienDaiDienId = value; } }
        public virtual NhanVienDaiDien NhanVienDaiDien { get; set; }

        public DateTime NgayKyHopDong { get { return this._NgayKyHopDong; } set { this._NgayKyHopDong = value; } }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
