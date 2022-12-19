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
            OrderDAL orderdal = new OrderDAL();
            Order order = new Order(orderdal);
            orderviewmodel.Boughtproducts = order.GetOrders((int)HttpContext.Session.GetInt32("UserId"));
            return View(orderviewmodel);
        }


    
    }
}
