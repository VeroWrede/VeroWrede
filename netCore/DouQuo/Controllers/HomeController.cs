using Microsoft.AspNetCore.Mvc;

namespace DouQuo.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet("")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("submit")]
        public IActionResult SubmitQuote()
        {
            ViewBag.Quotes = DbConnection.Query("SELECT * FROM Quote");
            return View("display");
        }
    }
}