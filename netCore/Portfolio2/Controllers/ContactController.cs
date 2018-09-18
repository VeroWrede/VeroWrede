using System;
using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Portfolio2.Models;

namespace Portfolio2.Controllers
{
    public class ContactController : Controller
    {
        [HttpGet("contact")]
        public IActionResult Contact()
        {
            ViewData["Message"] = "Say Hello!";
            return View();
        }

                public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}