using library.Models.Base;
using System;
using System.ComponentModel.DataAnnotations;

namespace library.Models
{
    public class DoiTac : ModelBaseExt
    {
        [Required(ErrorMessage = "{0} is required")]
        [MaxLength(20)]
        [DataType(DataType.Text)]
        private string _CMT;


        [Required(ErrorMessage = "{0} is required")]
        private int _NamSinh;


        [Required(ErrorMessage = "{0} is required")]
        [Phone]
        [DataType(DataType.PhoneNumber)]
        private string _SDT;


        public string CMT { get { return this._CMT; } set { this._CMT = value; } }
        public int NamSinh { get { return this._NamSinh; } set { this._NamSinh = value; } }
        public string SDT { get { return this._SDT; } set { this._SDT = value; } }
    }
}
