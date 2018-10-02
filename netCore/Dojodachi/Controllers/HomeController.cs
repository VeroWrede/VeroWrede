using Microsoft.AspNetCore.Mvc;
using Dojodachi.Models;
using Microsoft.AspNetCore.Http;
using Dojodachi.Extensions;

namespace Dojodachi.Controllers
{
    public class DachiController : Controller
    {
        [HttpGet("")]

        public ViewResult Index()
        {
            Dachi newDachi = new Dachi();
            if(HttpContext.Session.GetObjectFromJson<Dachi>())
            HttpContext.Session.SetObjectAsJson("CurrDachi", newDachi);

            return View();
        }

        // [HttpPost("setName")]
        
        // public RedirectToAction Start()
        // {
        //     if (HttpContent.Session.)
        // }

        [HttpGet("feed")]
        public IActionResult Feed()
        {
            var currMeals = (int)HttpContext.Session.GetInt32("meals");
            var currFullness = (int)HttpContext.Session.GetInt32("fullness");
            Dachi.Feed(currMeals, currFullness);
        }

    }
}