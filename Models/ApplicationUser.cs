using Microsoft.AspNetCore.Identity;

namespace KieuGiaConstruction.Models // Thay YourNamespace bằng namespace của bạn
{
    public class ApplicationUser : IdentityUser
    {
        // Bạn có thể thêm thuộc tính tùy chỉnh ở đây
        public string FullName { get; set; } // Ví dụ về thuộc tính tùy chỉnh
    }
}
