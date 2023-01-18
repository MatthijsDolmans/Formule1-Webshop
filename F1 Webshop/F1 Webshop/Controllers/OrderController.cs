using DAL;
using F1_Webshop.Models;
using Logic;
using Microsoft.AspNetCore.Mvc;

namespace F1_Webshop.Controllers
{
    public class OrderController : Controller
    {
        
        public IActionResult Index(OrderViewModel orderviewmodel)
        {
            OrderDAL orderdal = new();
            ProductDAL productdal = new();
            OrderCollection ordercollection = new(orderdal);
            orderviewmodel.Orders = ordercollection.GetAllOrders(productdal,(int)HttpContext.Session.GetInt32("UserId"));
            return View(orderviewmodel);
        }
    }
}
