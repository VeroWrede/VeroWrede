using System;
using Microsoft.AspNetCore.Mvc;

namespace Time.Controllers
{
    public class HomeController : Controller 
    {
        [HttpGet("")]
        public IActionResult Index()
        {
            DateTime date = new DateTime;
            ViewData["Title"] = "The Time!";
            ViewData["Date"] = date.Date;
            ViewData["Time"] = date.TimeOfDay;
            return View();
        }
    }
}