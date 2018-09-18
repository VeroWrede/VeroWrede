using System;
using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Portfolio2.Models;

namespace Portfolio2.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            ViewData["message"] = "All you ever needed to know";
            ViewData["afterThought"] = "How very lucky you must feel now and indeed you are!!";
            return View();
        }
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
