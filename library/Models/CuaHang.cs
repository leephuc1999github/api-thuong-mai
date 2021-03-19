using library.Models.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    public class CuaHang : ModelBaseExt
    {
        [Required]
        private string _Ten;

        private float? _DienTich;

        private string _ViTri;

        [Key]
        private int? _NhanVienQuanLyId;


        public string Ten { get { return this._Ten; } set { this._Ten = value; } }
        public float? DienTich { get { return this._DienTich; } set { this._DienTich = value; } }
        public string ViTri { get { return this._ViTri; } set { this._ViTri = value; } }

        public int? NhanVienQuanLyId { get { return this._NhanVienQuanLyId; } set { this._NhanVienQuanLyId = value; } }
        [ForeignKey("NhanVienQuanLyId")]
        public virtual NhanVienQuanLy NhanVienQuanLy { get; set; }

    }
}
