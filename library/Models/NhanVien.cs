using library.Models.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    public class NhanVien : ModelBaseExt
    {
        [Required]
        [MaxLength(20)]
        private string _CMT;

        [Required]
        [MaxLength(100)]
        private string _Ten;

        private string _DiaChi;

        private DateTime? _NgaySinh;

        [Required]
        [Phone]
        [DataType(DataType.PhoneNumber)]
        private string _SDT;

        [Key]
        private int? _GiamDocId;

        public string CMT { get { return this._CMT; } set { this._CMT = value; } }
        public string Ten { get { return this._Ten; } set { this._Ten = value; } }
        public string DiaChi { get { return this._DiaChi; } set { this._DiaChi = value; } }
        public DateTime? NgaySinh { get { return this._NgaySinh; } set { this._NgaySinh = value; } }
        public string SDT { get { return this._SDT; } set { this._SDT = value; } }

        [ForeignKey("GiamDocId")]
        public int? GiamDocId { get { return this._GiamDocId; } set { this._GiamDocId = value; } }
        public virtual GiamDoc GiamDoc { get; set; }
    }
}
