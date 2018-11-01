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
        private TrailContext dbContext;
        public HomeController(TrailContext context)
        {
            dbContext = context;
        }
        [HttpGet("")]
        public IActionResult Index()
        {
            ViewBag.Trail = dbContext.Trail.Take(10);
            return View();
        }

        [HttpGet("New")]
        public IActionResult New()
        {
            return View("New");
        }

        [HttpPost("Create")]
        public IActionResult Create(Trail trail)
        {
            if(ModelState.IsValid)
            {
                if(dbContext.Trail.Any(t => t.Name == trail.Name))
                {
                    ModelState.AddModelError("Name", "This name is already taken");
                    return View("New");
                }

                dbContext.Trail.Add(trail);
                dbContext.SaveChanges();

                return RedirectToAction("Index");
            } 
            return RedirectToAction("New");
        }

        [HttpGet("details/{id}")]
        public IActionResult Details(int id)
        {
            Trail currTrail = dbContext.Trail.FirstOrDefault(t => t.TrailId == id);
            ViewBag.Trail = currTrail;
            //return View("Details");
            return View("Details", currTrail);
        }
    }
}


