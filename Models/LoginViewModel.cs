using System.ComponentModel.DataAnnotations;

namespace KieuGiaConstruction.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Vui lòng nhập tên đăng nhập.")]
        public required string Username { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập mật khẩu.")]
        [DataType(DataType.Password)]
        public required string Password { get; set; }
    }
}