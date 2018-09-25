using System;
using FormSubmission.Models;
using Microsoft.AspNetCore.Mvc;


namespace FormSubmission.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet("")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost("create")]
        public IActionResult ProcessForm(User newUser)
        {
            return View("Login", newUser);
        }
    }
}