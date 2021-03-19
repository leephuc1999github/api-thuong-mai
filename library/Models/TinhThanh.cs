using library.Models.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    public class TinhThanh : ModelBaseExt
    {
        [Required]
        private int _MaTinhThanh;

        [Required]
        [MaxLength(100)]
        private string _TenTinhThanh;

        [Required]
        [MaxLength(100)]
        private string _ThanhPho;

        [Key]
        private int? _ChiNhanhId;

        public int MaTinhThanh { get { return this._MaTinhThanh; } set { this._MaTinhThanh = value; } }
        public string TenTinhThanh { get { return this._TenTinhThanh; } set { this._TenTinhThanh = value; } }
        public string ThanhPho { get { return this._ThanhPho; } set { this._ThanhPho = value; } }

        public int? ChiNhanhId { get { return this._ChiNhanhId; } set { this._ChiNhanhId = value; } }
        [ForeignKey("ChiNhanhId")]
        public virtual ChiNhanh ChiNhanh { get; set; }
        
    }
}
