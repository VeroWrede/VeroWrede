using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Lost.Models;

namespace Lost.Controllers
{
    public class HomeController : Controller
    {
        private readonly TrailFactory _trailFactory;
        [HttpGet("")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("Add")]
        public IActionResult Add()
        {
            return View("New");
        }
    }
}
