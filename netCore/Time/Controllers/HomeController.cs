using System;
using Microsoft.AspNetCore.Mvc;

namespace Time.Controllers
{
    public class HomeController : Controller 
    {
        [HttpGet("")]
        public IActionResult Index()
        {
            DateTime date = DateTime.Now;
            ViewData["Title"] = "The Time!";
            ViewData["Date"] = date.Date;
            ViewData["Date2"] = date.Date.ToString("dd-mm-yyyy");
            ViewData["Time"] = date.TimeOfDay;
            return View();
        }
    }
}