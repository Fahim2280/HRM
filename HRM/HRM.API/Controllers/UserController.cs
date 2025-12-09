using Microsoft.AspNetCore.Mvc;

namespace HRM.API.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
