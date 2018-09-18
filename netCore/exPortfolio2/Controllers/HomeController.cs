using Microsoft.AspNetCore.Mvc;

namespace Portfolio1.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet("")]
        public IActionResult Home() 
        {
            return View();
        }
    }
    
}