using System.Collections.Generic;
using System.Linq;
using DouQuo.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace DouQuo.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet("")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("create")]
        public IActionResult Create(Quote quote)
        {
            if (ModelState.IsValid)
            {
                string query = $"SELECT * FROM quotes WHERE Content = '{quote.Content};";
                List<Dictionary<string, object>> result = DbConnector.Query(query);

                if(result.Count > 0)
                {
                    ModelState.AddModelError("Content", "Quote already exists");
                }
                return RedirectToAction("Index");
            }
            ViewBag.Quotes = DbConnector.Query("SELECT * FROM quotes");
            return View("Display");
        }
    }
}