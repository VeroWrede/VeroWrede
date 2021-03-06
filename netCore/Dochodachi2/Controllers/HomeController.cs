using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Dojodachi2.Extensions;

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
                HttpContext.Session.SetInt32("Fullness" , 30);
                HttpContext.Session.SetInt32("Meals" , 3);
                HttpContext.Session.SetInt32("Happiness" , 30);
                HttpContext.Session.SetInt32("Sleep" , 50);
                TempData["Message"] = " ";
            }
            ViewBag.Fullness = HttpContext.Session.GetInt32("Fullness");
            ViewBag.Meals = HttpContext.Session.GetInt32("Meals");
            ViewBag.Happiness = HttpContext.Session.GetInt32("Happiness");
            ViewBag.Sleep = HttpContext.Session.GetInt32("Sleep");

            if ((Fullness >= 100) && (Happiness >= 100) && (Sleep >= 100))
            {
                return RedirectToAction("Win");
            }
            if ((Fullness <= 0) || (Happiness <= 0))
            {
                return RedirectToAction("Loss");
            }
            return View();
        }
        [HttpGet("win")]

        public IActionResult Win()
        {
            return View("Win");
        }
        [HttpGet("loss")]

        public IActionResult Loss()
        {
            int? Fullness = HttpContext.Session.GetInt32("Fullness");
            int? Happiness = HttpContext.Session.GetInt32("Happiness");
            if (Fullness <= 0)
            {
                ViewData["Message"] = "Your Dachi STARVED TO DEATH ";
            } else if (Happiness <= 0)
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
            int? Meals = HttpContext.Session.GetInt32("Meals");
            if (Meals <= 0)
            {
                TempData["Message"] = "Out of food, go work buddy!";
                return RedirectToAction("Index");
            }
            int? Fullness = HttpContext.Session.GetInt32("Fullness");
            int? Sleep = HttpContext.Session.GetInt32("Sleep");
            if (Sleep <= 15) //Dachi is still a kid
            {
                filling += rand.Next(5, 11);
            }
            if (Sleep > 15 && Sleep <= 40) // young adult to grown up
            {
                filling += rand.Next(7, 13);
            }
            if (Sleep > 40 && Sleep <= 80) //grown up
            {
                filling += rand.Next(10 , 16);
            }
            if (Sleep > 80) //old
            {
                int fill;
                int chance = rand.Next(1,16);
                if (chance == 1)
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
            Meals -= 1;
            HttpContext.Session.SetInt32("Meals", (int)Meals);
            Fullness += filling;
            HttpContext.Session.SetInt32("Fullness", (int)Fullness);
            TempData["Message"] = $"Feeding resulted in: {filling} to Fullness and cost one meal";
            return RedirectToAction("Index");
        }

        [HttpGet("play")]
        public RedirectToActionResult Play()
        {
            int joy = 0;
            Random rand = new Random();
            int? Happiness = HttpContext.Session.GetInt32("Happiness");
            int? Fullness = HttpContext.Session.GetInt32("Fullness");
            int? Sleep = HttpContext.Session.GetInt32("Sleep");
            int? Energy = HttpContext.Session.GetInt32("Energy");
            if (Energy <= 0)
            {
                joy += 1;
                Fullness -= 7;
            } else if (Happiness <= 33) //depressed Dachi
            {
                int chance = rand.Next(1,6);
                if ( chance == 1)
                {
                    Fullness -= 7;
                    joy = -7;
                } else {
                    Fullness -= 5;
                    joy = 2;
                }
            } else if (Happiness <= 66) // neutral Dachi
            {
                Fullness -= 3;
                joy = 5;
            } else { // happy Dachi!
                joy = rand.Next(10, 16);
            }
            Happiness += joy;
            HttpContext.Session.SetInt32("Happiness", (int)Happiness);
            Sleep -= 5;
            HttpContext.Session.SetInt32("Sleep", (int)Sleep);
            HttpContext.Session.SetInt32("Fullness", (int)Fullness);
            TempData["Message"] = $"Playing resulted in: {joy} Happiness, {Fullness} new Fullness, and -5 Sleep";
            return RedirectToAction("Index");
        }
        [HttpGet("work")]

        public IActionResult Work()
        {
            int wear = 0;
            int filling = 0;
            int earnings = 0;
            int joy = 0;
            Random rand = new Random();
            int? Happiness = HttpContext.Session.GetInt32("Happiness");
            int? Sleep = HttpContext.Session.GetInt32("Sleep");
            int? Meals = HttpContext.Session.GetInt32("Meals");
            int? Fullness = HttpContext.Session.GetInt32("Fullness");
            if (Happiness <= 33)
            {
                wear -=8;
                filling -= 7;
                joy -= 3;
            } else if (Happiness > 33 && Happiness < 66)
            {
                filling -=5;
                wear -= 5;
            } else {
                filling -=3;
                wear -= 3;
                joy += 1;
            }
            Fullness += filling;
            HttpContext.Session.SetInt32("Fullness", (int)Fullness);
            Sleep += wear;
            HttpContext.Session.SetInt32("Sleep", (int)Sleep);
            earnings += rand.Next(1,4);
            Meals += earnings;
            HttpContext.Session.SetInt32("Meals", (int)Meals);
            Happiness += joy;
            HttpContext.Session.SetInt32("Happiness", (int)Happiness);
            TempData["Message"] = $"Work resulted in: {wear} Sleep, {filling} added Fullness, {earnings} earned Meals, and {joy} Happiness";
            return RedirectToAction("Index");
        }
        [HttpGet("sleep")]
        public IActionResult Sleep()
        {
            int rest = 0;
            int filling = 0;
            int joy = 0;
            Random rand = new Random();
            int? Sleep = HttpContext.Session.GetInt32("Sleep");
            int? Fullness = HttpContext.Session.GetInt32("Fullness");
            int? Happiness = HttpContext.Session.GetInt32("Happiness");
            rest += rand.Next(10, 16);
            filling -= rand.Next(8, 14);
            joy -= 3;
            if ( Happiness > 66)
            {
                rest += 5;
                filling -= 5;
            }
            Sleep += rest;
            HttpContext.Session.SetInt32("Sleep", (int)Sleep);
            Fullness += filling;
            HttpContext.Session.SetInt32("Fullness", (int)Fullness);
            Happiness += joy;
            HttpContext.Session.SetInt32("Happiness", (int)Happiness);
            TempData["Message"] = $"Sleeping resulted in: {rest} rest, {filling} Fullness, and {joy} Happiness";
            return RedirectToAction("Index");
        }
        [HttpGet("reset")]
        public IActionResult Reset()
        {
            HttpContext.Session.Clear();
            TempData["Message"] = "Starting new game";
            return RedirectToAction("Index");
        }
    }
}