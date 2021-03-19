using library.Models.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    public class MatHang : ModelBaseExt
    {
        [Required(ErrorMessage = "{0} is required")]
        [MaxLength(100)]
        private string _Ten;

        [Required]
        private string _Loai;

        [Required]
        private int _SoLuong;

        public string Ten { get { return this._Ten; } set { this._Ten = value; } }
        public string Loai { get { return this._Loai; } set { this._Loai = value; } }
        public int SoLuong { get { return this._SoLuong; } set { this._SoLuong = value; } }


    }
}
