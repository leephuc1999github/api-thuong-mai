using System.ComponentModel.DataAnnotations;

namespace api.Models
{
    public class NhanVienDaiDien : NhanVien
    {
        [Required]
        [MaxLength(100)]
        private string _ChucVu;

        [Required]
        [MaxLength(100)]
        private string _LinhVuc;


        public string ChucVu { get { return this._ChucVu; } set { this._ChucVu = value; } }
        public string LinhVuc { get { return this._LinhVuc; } set { this._LinhVuc = value; } }
    }
}
