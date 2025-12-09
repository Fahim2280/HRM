using Microsoft.AspNetCore.Mvc;

namespace HRM.API.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
