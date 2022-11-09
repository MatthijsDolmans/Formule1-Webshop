using Microsoft.AspNetCore.Mvc;

namespace F1_Webshop.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
