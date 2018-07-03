using Microsoft.AspNetCore.Mvc;

namespace fuzzy_core.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}