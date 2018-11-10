using System;
using System.Collections.Generic;
using Chefs.Models;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Chefs.Controllers 
{
    [Route("cook")]
    public class CookController : Controller{
        private ChefsNDishesContext dbContext;
        public CookController(ChefsNDishesContext context)
        {
            dbContext = context;
        }

        [HttpGet("New")]
        public IActionResult New()
        {
            return View("NewCook");
        }

        [HttpPost("CreateCook")]
        public IActionResult CreateCook(Cook cook)
        {
            if (ModelState.IsValid)
            {
                if (dbContext.Cooks.Any(c => c.FullName == cook.FullName))
                {
                    ModelState.AddModelError("Cook", "This cook is already registered");
                    return RedirectToAction("New");
                }
                cook.NumberOfDishes = (dbContext.Dishes.Where(d => d.Cook == cook)).Count();
                dbContext.Cooks.Add(cook);
                dbContext.SaveChanges();

                return RedirectToAction("Home/Index");
            }
            return RedirectToAction("New");

        }

    }
}