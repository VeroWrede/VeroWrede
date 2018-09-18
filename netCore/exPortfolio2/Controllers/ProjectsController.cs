using Microsoft.AspNetCore.Mvc;

namespace Portfolio1.Controllers
{
    public class ProjectsController : Controller
    {
        [HttpGet("projects")]
        public string Projects()
        {
            return "Projects";
        }
    }
    
}