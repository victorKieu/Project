using Microsoft.AspNetCore.Mvc;

namespace KieuGiaConstruction.Controllers
{
    public class DashboardController : Controller
    {
        // GET: Hiển thị Dashboard
        public IActionResult Index()
        {
            return View();
        }
    }
}