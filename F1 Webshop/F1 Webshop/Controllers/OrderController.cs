using DAL;
using F1_Webshop.Models;
using Logic;
using Microsoft.AspNetCore.Mvc;

namespace F1_Webshop.Controllers
{
    public class OrderController : Controller
    {
        
        public IActionResult Index()
        {         

            return View();
        }

    
    }
}
