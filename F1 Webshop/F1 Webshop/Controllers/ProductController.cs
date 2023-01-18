using DAL;
using F1_Webshop.Models;
using Logic;
using Logic.Helpers;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using static Logic.ProductCollection;

namespace F1_Webshop.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index(ProductViewModel productViewModel,string btnorder, string btninformation, string Orderbyorderid)
        {
            ProductDAL productdal = new ProductDAL();
            OrderDAL orderdal = new OrderDAL();
            OrderCollection orderCollection = new(orderdal);
            Order order = new Order(orderdal);
            productViewModel.ordernumbers = orderCollection.GetAllOrderIds((int)HttpContext.Session.GetInt32("UserId"));
            if (!string.IsNullOrEmpty(btninformation))
            {
                HttpContext.Response.Cookies.Append("ProductName", productViewModel.ProductName.ToString());
                ProductCollection product = new ProductCollection(productdal);
                productViewModel.products = product.GetProduct(productViewModel.ProductName);
            }

            if(!string.IsNullOrEmpty(btnorder))
            {
                ProductCollection product = new ProductCollection(productdal);
                string productname = HttpContext.Request.Cookies["ProductName"];
                foreach (ProductNameEnum.ProductName name in Enum.GetValues(typeof(ProductNameEnum.ProductName)))
                {
                    if (name.ToString() == productname)
                    {
                        productViewModel.products = product.GetProduct(name);
                        break;
                    }
                }
                bool ordersucceed = order.OrderProduct(productViewModel.products,productdal, (int)HttpContext.Session.GetInt32("UserId"));
                if (ordersucceed == false)
                {
                    productViewModel.Error = "Product is out of stock";
                    return View(productViewModel);
                }
                else
                {
                    return RedirectToAction("Index", "Order");
                }
            }

            if (!string.IsNullOrEmpty(Orderbyorderid))
            {
                ProductCollection product = new ProductCollection(productdal);
                string productname = HttpContext.Request.Cookies["ProductName"];
                foreach (ProductNameEnum.ProductName name in Enum.GetValues(typeof(ProductNameEnum.ProductName)))
                {
                    if (name.ToString() == productname)
                    {
                        productViewModel.products = product.GetProduct(name);
                        break;
                    }
                }
                bool ordersucceed = order.OrderProductToExistingOrder(productViewModel.products, productdal,productViewModel.chosenordernumber, (int)HttpContext.Session.GetInt32("UserId"));
                if (ordersucceed == false)
                {
                    productViewModel.Error = "Product is out of stock";
                    return View(productViewModel);
                }
                else
                {
                    return RedirectToAction("Index", "Order");
                }
                return RedirectToAction("Index", "Order");
            }
            return View(productViewModel);
        }
    }
    
}
