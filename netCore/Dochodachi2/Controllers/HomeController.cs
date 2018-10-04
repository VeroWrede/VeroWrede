using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace Dojodachi2.Controllers
{
    public class HomeController : Controller 
    {
        [HttpGet("")]
        public IActionResult Index()
        {
            int? Fullness = HttpContext.Session.GetInt32("Fullness");
            int? Meals = HttpContext.Session.GetInt32("Meals");
            int? Happiness = HttpContext.Session.GetInt32("Happiness");
            int? Sleep = HttpContext.Session.GetInt32("Sleep");

            if (Fullness == null && Meals == null && Happiness == null && Sleep == null)
            {
                HttpContext.Session.SetInt32("Fullness" , 20);
                HttpContext.Session.SetInt32("Meals" , 3);
                HttpContext.Session.SetInt32("Happiness" , 20);
                HttpContext.Session.SetInt32("Sleep" , 50);
            }
            ViewBag.Fullness = HttpContext.Session.GetInt32("Fullness");
            ViewBag.Meals = HttpContext.Session.GetInt32("Meals");
            ViewBag.Happiness = HttpContext.Session.GetInt32("Happiness");
            ViewBag.Sleep = HttpContext.Session.GetInt32("Sleep");

            if ((Fullness >= 100) && (Happiness >= 100) && (Sleep >= 100))
            {
                return RedirectToAction("Win");
            }
            if ((Fullness <= 0) || (Happiness <= 100))
            {
                return RedirectToAction("Loss");
            }
            return View();
        }

        public IActionResult Win()
        {
            return View("Win");
        }

        public IActionResult Loss()
        {
            if (ViewBag.Fullness <= 0)
            {
                ViewData["Message"] = "Your Dachi STARVED TO DEATH ";
            } else if (ViewBag.Happiness <= 0)
            {
                ViewData["Message"] = "A depressed Dachi is a dead Dachi";
            } else {
                ViewBag["Message"] = "Guess your Dachi just died ... Sucks, pal";
            }
            return View("Loss");
        }

        [HttpGet("feed")]
        public IActionResult Feed()
        {
            Random rand = new Random();
            int filling = 0;
            if (ViewBag.Sleep <= 15) //Dachi is still a kid
            {
                filling = rand.Next(3, 11);
            }
            if (ViewBag.Sleep > 15 && ViewBag.Sleep <= 40) // young adult to grown up
            {
                filling = rand.Next(7, 13);
            }
            if (ViewBag.Sleep > 40 && ViewBag.Sleep <= 80) //grown up
            {
                filling = rand.Next(10 , 16);
            }
            if (ViewBag.Sleep > 80) //old
            {
                int fill;
                int chance = rand.Next(1,16);
                if (chance == 1 || chance == 15)
                {
                    fill  = -100;
                    Console.WriteLine("accidental death by food");
                } else if (chance % 5 == 0)
                {
                    fill = -5;
                    Console.WriteLine("not good food for an elderly Dachi");
                } else {
                    fill = 5;
                }
                filling = fill;
            }
            ViewBag.Meals -= 1;
            ViewBag.Sleep += filling;
            return RedirectToAction("Index");
        }

        [HttpGet("play")]
        public IActionResult Play()
        {
            int joy = 0;
            Random rand = new Random();
            if (ViewBag.Happiness <= 33) //depressed Dachi
            {
                int chance = rand.Next(1,6);
                if ( chance == 1)
                {
                    joy = -5;
                } else {
                    joy = 2;
                }
            } else if (ViewBag.Happiness <= 66) // neutral Dachi
            {
                joy = 5;
            } else { // happy Dachi!
                joy = rand.Next(10, 16);
            }
            ViewBag.Happiness += joy;
            ViewBag.Sleep -= 5;
            return RedirectToAction("Index");
        }

    }
}