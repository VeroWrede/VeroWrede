using System;
using ModelSurvey.Models;
using Microsoft.AspNetCore.Mvc;

namespace ModelSurvey.Controllers 
{
    public class HomeController : Controller 
    {
        [HttpGet("")]
        public IActionResult Index() 
        {
            return View();
        }

        [HttpPost("create")]
        public IActionResult ProcessForm(MySurvey newSurvey)
        {
            if(ModelState.IsValid)
            {
                return View("Result", newSurvey);
            }
            
            return View();
        }
    }
}