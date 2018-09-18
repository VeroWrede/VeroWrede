using Microsoft.AspNetCore.Mvc;

namespace Portfolio1.Controllers
{
    public class ContactController : Controller
    {
        [HttpGet("contact")]
        public string Contacts()
        {
            return "Contact route";
        }
    }
    
}