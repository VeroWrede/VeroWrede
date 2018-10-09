using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace RandPass.Controllers
{
    public class HomeController : Controller 
    {
        [HttpGet("")]
        public IActionResult Index()
        {
            string[] oks = new string[] {"A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z", "1", "2", "3", "4", "5", "6", "8", "9", "0"};
            string res = "";
            Random rand = new Random();
            int? NumOfCodes = HttpContext.Session.GetInt32("NumOfCodes");
            string Code = HttpContext.Session.GetString("Code");
            if(NumOfCodes == null)
            {
                NumOfCodes = 0;
            }
            int len = 14;
            while (0 < len--)
            {
                int i = rand.Next(0,35);
                res += oks[i];
            }
            NumOfCodes ++;
            HttpContext.Session.SetInt32("NumOfCodes", (int)NumOfCodes);
            HttpContext.Session.SetString("Code", res);
            ViewBag.NumOfCodes = HttpContext.Session.GetInt32("NumOfCodes");
            ViewBag.Code = HttpContext.Session.GetString("Code");
            return View();
        }

        [HttpGet("new")]
        public IActionResult NewCode()
        {
            return RedirectToAction("Index");
        }
    }
}