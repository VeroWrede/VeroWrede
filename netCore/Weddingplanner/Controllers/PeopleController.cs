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
    [Route("people")]
    public class PeopleController : Controller
    {
        private WeddingContext dbContext;
        public PeopleController(WeddingContext context)
        {
            dbContext = context;
        }

        [HttpGet("")]
        public IActionResult Index()
        {
            List<Wedding> Weddings = dbContext.Weddings.ToList();
            return View(Weddings);
        }
    }
}