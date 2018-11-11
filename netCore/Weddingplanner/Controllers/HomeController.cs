using System;
using System.Collections.Generic;
using Weddingplanner.Models;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;

namespace Weddingplanner.Controllers
{
    public class HomeController : Controller
    {
        private WeddingContext dbContext;
        public HomeController(WeddingContext context)
        {
            dbContext = context;
        }

        [HttpGet("")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost("create")]
        public IActionResult Create(LogRegModel model)
        {
            Person person = model.Register;

            if (ModelState.IsValid)
            {
                if (dbContext.People.Any(o => o.Email == person.Email))
                {
                    ModelState.AddModelError("Email", "Email already in use");
                    return View("Index");
                }

                PasswordHasher<Person> hasher = new PasswordHasher<Person>();
                person.Password = hasher.HashPassword(person, person.Password);

                var newPerson = dbContext.People.Add(person).Entity;
                dbContext.SaveChanges();

                HttpContext.Session.SetInt32("userId", newPerson.PersonId);

                return RedirectToAction("Index", "People");
            }
            return View("Index");
        }

        [HttpPost("login")]
        public IActionResult Login(LogRegModel model)
        {
            LoginUser person = model.Login;
            if (ModelState.IsValid)
            {
                Person toLogin = dbContext.People.FirstOrDefault(u => u.Email == person.EmailAttempt);
                if (toLogin == null)
                {
                    ModelState.AddModelError("Login.EmailAttempt", "Invalid Email/Password");
                    return View("Index");
                }
                PasswordHasher<LoginUser> hasher = new PasswordHasher<LoginUser>();
                var result = hasher.VerifyHashedPassword(person, toLogin.Password, person.PasswordAttempt);
                if (result == PasswordVerificationResult.Failed)
                {
                    ModelState.AddModelError("Login.EmailAttempt", "Invalid Email/Password");
                    return View("Index");
                }
                // Log user into session
                HttpContext.Session.SetInt32("userId", toLogin.PersonId);
                return RedirectToAction("Index", "People");
            }
            return View("Index");
        }

        [HttpGet("logout")]
        public RedirectToActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index");
        }
    }
}