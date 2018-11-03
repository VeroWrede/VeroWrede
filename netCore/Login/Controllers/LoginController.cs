using System;
using System.Collections.Generic;
using Login.Models;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Login.Controllers
{
    public class LoginController : Controller
    {
        private UserContext dbContext;
        public LoginController(UserContext context)
        {
            dbContext = context;
        }

        [HttpGet("")]
        public IActionResult Index()
        {
            return View("Register");
        }

        [HttpPost("create")]
        public IActionResult Create(User user)
        {
            if(ModelState.IsValid)
            {
                if(dbContext.Users.Any(u => u.Email == User.Email))
                {
                    ModelState.AddModelError("Email", "Email already exists");
                    return View("Register");
                }
                dbContext.Users.Add(user);
                dbContext.SaveChanges();
                return RedirectToAction("Login");
            }
            return View("Register");
        }
    }
}