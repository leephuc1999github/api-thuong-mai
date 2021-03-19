using library.Models.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    public class ChiNhanh : ModelBaseExt
    {
        [Required]
        private string _GioHoatDong;

        [Required(ErrorMessage = "{0} is required")]
        [MaxLength(100)]
        private string _TenChiNhanh;

        [Key]
        private int? _GiamDocId;

        public string GioHoatDong { get { return this._GioHoatDong; } set { this._GioHoatDong = value; } }
        public string TenChiNhanh { get { return this._TenChiNhanh; } set { this._TenChiNhanh = value; } }

        public int? GiamDocId { get { return this._GiamDocId; } set { this._GiamDocId = value; } }
        [ForeignKey("GiamDocId")]
        public virtual GiamDoc GiamDoc { get; set; }

    }
}
