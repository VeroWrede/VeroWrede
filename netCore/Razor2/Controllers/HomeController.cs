using Microsoft.AspNetCore.Mvc;

namespace Razor2.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet("")]
        public IActionResult Home()
        {
            ViewData["Message"] = "food... MEEEEEEAAAAT!";
            return View();
        }
    }
}