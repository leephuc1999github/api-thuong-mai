using library.Models.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    public class KhachHang : ModelBaseExt
    {
        [Required]
        [MaxLength(20)]
        private string _CMT;

        [Required]
        [MaxLength(100)]
        private string _Ten;

        private int _NamSinh;

        [Required]
        [MaxLength(100)]
        private string _SDT;

        [Key]
        private int? _TinhThanhId;

        public string CMT { get { return this._CMT; } set { this._CMT = value; } }
        public string Ten { get { return this._Ten; } set { this._Ten = value; } }
        public int NamSinh { get { return this._NamSinh; } set { this._NamSinh = value; } }
        public string SDT { get { return this._SDT; } set { this._SDT = value; } }

        public int? TinhThanhId { get { return this._TinhThanhId; } set { this._TinhThanhId = value; } }
        [ForeignKey("TinhThanhId")]
        public virtual TinhThanh TinhThanh { get; set; }

    }
}
