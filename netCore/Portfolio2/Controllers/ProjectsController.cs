using System;
using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Portfolio2.Models;

namespace Portfolio2.Controllers
{
    public class ProjectsController : Controller
    {
        [HttpGet("Projects")]
        public IActionResult Projects()
        {
            ViewData["Message"] = "A listing of my projects.";

            return View();
        }
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}