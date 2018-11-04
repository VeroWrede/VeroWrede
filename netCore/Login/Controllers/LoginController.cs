using System;
using System.Collections.Generic;
using Login.Models;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace Login.Controllers
{
    public class LoginController : Controller
    {
        private PeopleContext dbContext;
        public LoginController(PeopleContext context)
        {
            dbContext = context;
        }

        [HttpGet("")]
        public IActionResult Index()
        {
            return View("Register");
        }

        [HttpPost("create")]
        public IActionResult Create(Person person)
        {
            if(ModelState.IsValid)
            {
                if(dbContext.People.Any(p => p.Email == person.Email))
                {
                    ModelState.AddModelError("Email", "Email already exists");
                    return View("Register");
                }
                PasswordHasher<Person> Hasher = new PasswordHasher<Person>();
                person.Password = Hasher.HashPassword(person, person.Password);
                dbContext.People.Add(person);
                dbContext.SaveChanges();
                return RedirectToAction("Login", person);
            }
            return View("Register");
        }

        [HttpGet("login")]
        public IActionResult Login ()
        {
            return View("Login");
        }
        [HttpPost("verify")]
        public IActionResult Verify(Person person)
        {
            var existingPerson = dbContext.People.FirstOrDefault(p => p.Email == person.Email);
            if (existingPerson == null)
            {
                ModelState.AddModelError("Email", "invalid login information");
                return View("Login");
            }
            var hasher = new PasswordHasher<Person>();
            var result = hasher.VerifyHashedPassword(person, existingPerson.Password, person.Password);
            if(result == 0)
            {
                ModelState.AddModelError("Password", "Invalid login info");
                return View("Login");
            }
            return RedirectToAction("Success", existingPerson);
            return View("Login");
        }

        // [HttpGet("success/{existingPerson.FirstName}")]
        [HttpGet("success")]
        public IActionResult Success (Person user)
        {
            return View("Success", user);
        }
    }
}