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
            List<Dish> Dishes = dbContext.Dishes.ToList();
            return View(Dishes);
        }

        [HttpGet("new/{id?}")]
        public IActionResult New()
        {
            return View("New");
        }

        [HttpPost("create")]
        public IActionResult Create(Dish dish)
        {
            if(ModelState.IsValid)
            {
                if (dbContext.Dishes.Any(d => d.Name == dish.Name && d.Chef == dish.Chef))
                {
                    ModelState.AddModelError("Dish", $"{dish.Chef}'s {dish.Name} is already in the system");
                    ViewBag.Dishes = dbContext.Dishes.Reverse().Take(10);
                    return View("New");
                }
                dbContext.Dishes.Add(dish);
                dbContext.SaveChanges();

                return RedirectToAction("Index");
            }
            return View("New");
        }

        [HttpGet("details/{id}")]
        public IActionResult Details(int id)
        {
            Dish currDish = dbContext.Dishes.FirstOrDefault(d => d.DishId == id);

            return View("Details", currDish);
        }

        [HttpGet("edit/{DishId}")]
        public IActionResult Edit (int DishId) 
        {
            var dishModel = dbContext.Dishes.FirstOrDefault(d => d.DishId == DishId);
            if(dishModel == null)
            {
                return RedirectToAction("Details", DishId);
            }
            return View("Edit", dishModel);
        }

        [HttpPost("update/{dishId}")]
        public IActionResult Update(Dish Dish, int dishId)
        {
            if(ModelState.IsValid)
            {
                Dish updateDish = dbContext.Dishes.FirstOrDefault(d => d.DishId == dishId);
                updateDish.Name = Dish.Name;
                updateDish.Chef = Dish.Chef;
                updateDish.Tastiness = Dish.Tastiness;
                updateDish.Calories = Dish.Calories;
                updateDish.Description = Dish.Description;
                dbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }

        [HttpGet("details/delete/{id}")]
        public IActionResult Delete(int id)
        {
            Dish badDish = dbContext.Dishes.FirstOrDefault(d => d.DishId == id);
            dbContext.Dishes.Remove(badDish);
            dbContext.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}