using Microsoft.AspNetCore.Identity;

namespace kieugiaconstruction.Models // Tên namespace cho dự án của bạn
{
    public class ApplicationUser : IdentityUser
    {
        public string? FullName { get; set; }
    }
}
