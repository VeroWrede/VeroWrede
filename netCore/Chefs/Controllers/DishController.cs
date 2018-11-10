using System;
using System.Collections.Generic;
using Chefs.Models;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Crudelicious.Controllers
{
    [Route("dish")]
    public class DishController : Controller
    {
        private ChefsNDishesContext dbContext;
        public DishController(ChefsNDishesContext context)
        {
            dbContext = context;
        }

        [HttpGet("")]
        public IActionResult Index()
        {
            List<Dish> Dishes = dbContext.Dishes.ToList();
            return View("Dishes", Dishes);
        }

        [HttpGet("New")]
        public IActionResult New()
        {
            ViewBag.Cooks = dbContext.Cooks.ToList();
            return View("NewDish");
        }

        [HttpPost("createDish")]
        public IActionResult CreateDish(Dish dish)
        {
            if (ModelState.IsValid)
            {
                if (dbContext.Dishes.Any(d => d.Name == dish.Name && d.Cook == dish.Cook))
                {
                    ModelState.AddModelError("Dish", $"{dish.Cook.FullName}'s {dish.Name} is already in the system");
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
        public IActionResult Edit(int DishId)
        {
            var dishModel = dbContext.Dishes.FirstOrDefault(d => d.DishId == DishId);
            if (dishModel == null)
            {
                return RedirectToAction("Details", DishId);
            }
            return View("Edit", dishModel);
        }

        [HttpPost("update/{dishId}")]
        public IActionResult Update(Dish Dish, int dishId)
        {
            if (ModelState.IsValid)
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