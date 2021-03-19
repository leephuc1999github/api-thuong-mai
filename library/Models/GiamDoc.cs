using library.Models.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    public class GiamDoc : ModelBaseExt
    {
        [Required(ErrorMessage = "{0} is required")]
        [MaxLength(20)]
        private string _CMT;

        [Required]
        [MaxLength(100)]
        private string _Ten;

        private int _NamKinhNghiem;

        [Required]
        [MaxLength(100)]
        private string _SDT;

        public string CMT { get { return this._CMT; } set { this._CMT = value; } }
        public string Ten { get { return this._Ten; } set { this._Ten = value; } }
        public int NamKinhNghiem { get { return this._NamKinhNghiem; } set { this._NamKinhNghiem = value; } }
        public string SDT { get { return this._SDT; } set { this._SDT = value; } }
        
    }
}
