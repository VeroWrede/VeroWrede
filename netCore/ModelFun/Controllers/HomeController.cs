using Microsoft.AspNetCore.Mvc;
using ModelFun.Models;
using System;
using System.Collections.Generic;

namespace ModelFun.Controllers
{
    public class UserController : Controller 
    {
        [HttpGet("")]
        public IActionResult String()
        {
            string[] Messages = new string[]
            {
                "When you fall, I will be there to catch you - With love, the floor.",
                "I don't like violence but I don't mind if I get hit by luck.",
                "Maybe if we all sit extremely still, Monday won't be able to see us.",
                "A real friend is one who walks in when the rest of the world walks out.",
                "Be happy, it drives people crazy."
            };
            return View(Messages);
        }

        [HttpGet("numbers")]
        public IActionResult Numbers()
        {
            Random rand = new Random();
            List<int> Numbers = new List<int>();
            int i = 0;
            while (i < 10)
            {
                int n = rand.Next(0, 100);
                Numbers.Add(n);
            };
            return View(Numbers);
        }

        [HttpGet("users")]
        public IActionResult Users()
        {
            string[] Users = new string[]
            {
                "Mina",
                "Burley",
                "Leonard",
                "Sweepo"
            };
            return View(Users);
        }

        [HttpGet("{username}")]
        public IActionResult UserDetail(string username)
        {
            string Name = username;
            return View(Name);

        }
    }
}