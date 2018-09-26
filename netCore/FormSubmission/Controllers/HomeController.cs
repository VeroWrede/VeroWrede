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
            if (ModelState.IsValid)
            {
                // return Json(newUser);
                return RedirectToAction("Success");
            }
            return View("Index");
        }

        [HttpGet("success")]
        public IActionResult Success()
        {
            return View("Success");
        }
    }
}