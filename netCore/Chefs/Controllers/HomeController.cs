using System;
using System.Collections.Generic;
using Chefs.Models;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace  Chefs.Controllers 
{
    public class HomeController : Controller
    {
        private ChefsNDishesContext dbContext;
        public HomeController(ChefsNDishesContext context)
        {
            dbContext = context;
        }

        [HttpGet("")]
        public IActionResult Index()
        {
            List<Cook> Cooks = dbContext.Cooks.ToList();
            // List<Dish> Dishes = dbContext.Dishes.ToList();
            return View(Cooks);
        }

        [HttpGet("newDish/{id?}")]
        public IActionResult NewDish()
        {
            return View("NewDish");
        }

        [HttpPost("createDish")]
        public IActionResult CreateDish(Dish dish)
        {
            if(ModelState.IsValid)
            {
                if (dbContext.Dishes.Any(d => d.Name == dish.Name && d.Cook == dish.Cook))
                {
                    ModelState.AddModelError("Dish", $"{dish.Cook}'s {dish.Name} is already in the system");
                    ViewBag.Dishes = dbContext.Dishes.Reverse().Take(10);
                    return View("NewDish");
                }
                dbContext.Dishes.Add(dish);
                dbContext.SaveChanges();

                return RedirectToAction("Index");
            }
            return View("NewDish");
        }

        [HttpGet("dishDetails/{id}")]
        public IActionResult DishDetails(int id)
        {
            Dish currDish = dbContext.Dishes.FirstOrDefault(d => d.DishId == id);

            return View("DishDetails", currDish);
        }

        [HttpGet("editDish/{DishId}")]
        public IActionResult EditDish (int DishId) 
        {
            var dishModel = dbContext.Dishes.FirstOrDefault(d => d.DishId == DishId);
            if(dishModel == null)
            {
                return RedirectToAction("DishDetails", DishId);
            }
            return View("EditDish", dishModel);
        }

        [HttpPost("updateDish/{dishId}")]
        public IActionResult UpdateDish(Dish Dish, int dishId)
        {
            if(ModelState.IsValid)
            {
                Dish updateDish = dbContext.Dishes.FirstOrDefault(d => d.DishId == dishId);
                updateDish.Name = Dish.Name;
                updateDish.Cook = Dish.Cook;
                updateDish.Tastiness = Dish.Tastiness;
                updateDish.Calories = Dish.Calories;
                updateDish.Description = Dish.Description;
                dbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }

        [HttpGet("dishDetails/deleteDish/{id}")]
        public IActionResult DeleteDish(int id)
        {
            Dish badDish = dbContext.Dishes.FirstOrDefault(d => d.DishId == id);
            dbContext.Dishes.Remove(badDish);
            dbContext.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}