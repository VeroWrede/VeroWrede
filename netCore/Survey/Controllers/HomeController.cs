using System;
using Survey.Models;
using Microsoft.AspNetCore.Mvc;

namespace Survey.Controllers 
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
            return View("Result", newSurvey);
        }
    }
}