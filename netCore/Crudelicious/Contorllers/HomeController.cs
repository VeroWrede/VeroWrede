using System;
using System.Collections.Generic;
using Crudelicious.Models;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace  Crudelicious.Controllers 
{
    public class HomeController : Controller
    {
        private DishContext dbContext;
        public HomeController(DishContext context)
        {
            dbContext = context;
        }

        [HttpGet("")]
        public IActionResult Index()
        {
            ViewBag.Dishes = dbContext.Dishes.Take(10);
            return View();
        }
    }
}