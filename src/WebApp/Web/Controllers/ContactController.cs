using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    public class ContactController : AspNetLayeredArchitectureWithDapperBase
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}