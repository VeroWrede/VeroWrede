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
        private TrailsContext dbContext;
        public HomeController(TrailsContext context)
        {
            dbContext = context;
        }
        [HttpGet("")]
        public IActionResult Index()
        {
            ViewBag.Trails = dbContext.Trails.Take(10);
            return View();
        }
        
        [HttpGet("New")]
        public IActionResult New()
        {
            return View("New");
        }

        [HttpGet("Add")]
        public IActionResult Add(Trail trail)
        {
            if(ModelState.IsValid)
            {
                if(dbContext.Trails.Any(t => t.Name == trail.Name))
                {
                    ModelState.AddModelError("Name", "This name is already taken");
                    return View("New");
                }

                dbContext.Trails.Add(trail);
                dbContext.SaveChanges();

                return View(trail.TrailId);
            }
            return View("Index");
        }

        [HttpGet("{id}")]
        public IActionResult Details(int trailId)
        {
            Trail currTrail = dbContext.Trails.FirstOrDefault(t => t.TrailId == trailId);
            if (currTrail == null)
                return RedirectToAction("Index");
            return View(currTrail);
        }
    }
}
