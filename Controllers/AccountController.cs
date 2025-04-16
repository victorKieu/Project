using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using System;
using System.Threading.Tasks;
using KieuGiaConstruction.Data;
using KieuGiaConstruction.Models;

namespace KieuGiaConstruction.Controllers
{
    public class AccountController(AppDbContext context, IPasswordHasher<string> passwordHasher) : Controller
    {
        private readonly AppDbContext _context = context ?? throw new ArgumentNullException(nameof(context));
        private readonly IPasswordHasher<string> _passwordHasher = passwordHasher ?? throw new ArgumentNullException(nameof(passwordHasher));

        // GET: Hiển thị trang Login
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        // POST: Xử lý dữ liệu Login
        [HttpPost]
        public async Task<IActionResult> Login(string username, string password)
        {
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                ViewBag.ErrorMessage = "Tên đăng nhập và mật khẩu không được để trống.";
                return View();
            }

            // Tìm người dùng trong cơ sở dữ liệu
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Username == username);
            if (user == null)
            {
                ViewBag.ErrorMessage = "Tên đăng nhập không tồn tại.";
                return View();
            }

            if (string.IsNullOrEmpty(user.PasswordHash))
            {
                ViewBag.ErrorMessage = "Mật khẩu không hợp lệ. Vui lòng liên hệ quản trị viên.";
                return View();
            }

            // Xác thực mật khẩu
            try
            {
                var passwordVerificationResult = _passwordHasher.VerifyHashedPassword(username, user.PasswordHash, password);
                if (passwordVerificationResult != PasswordVerificationResult.Success)
                {
                    ViewBag.ErrorMessage = "Mật khẩu không chính xác.";
                    return View();
                }
            }
            catch (FormatException ex)
            {
                Console.WriteLine($"Lỗi xác thực mật khẩu: {ex.Message}");
                ViewBag.ErrorMessage = "Dữ liệu mật khẩu không hợp lệ. Vui lòng liên hệ quản trị viên.";
                return View();
            }

            // Đăng nhập thành công
            user.LastLogin = DateTime.Now;
            _context.Users.Update(user);
            await _context.SaveChangesAsync();

            HttpContext.Session.SetString("User", username);
            return RedirectToAction("Index", "Dashboard");
        }

        [HttpPost]
        public async Task<IActionResult> UpdatePassword(string username, string newPassword)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Username == username);
            if (user == null)
            {
                return NotFound("Người dùng không tồn tại.");
            }

            // Mã hóa mật khẩu mới
            var hashedPassword = _passwordHasher.HashPassword(username, newPassword);
            user.PasswordHash = hashedPassword;

            _context.Users.Update(user);
            await _context.SaveChangesAsync();

            return Ok("Mật khẩu đã được cập nhật thành công.");
        }

        // GET: Đăng xuất
        [HttpGet]
        public IActionResult Logout()
        {
            // Xóa Session và điều hướng tới trang Login
            HttpContext.Session.Clear();
            return RedirectToAction("Login", "Account");
        }
    }
}