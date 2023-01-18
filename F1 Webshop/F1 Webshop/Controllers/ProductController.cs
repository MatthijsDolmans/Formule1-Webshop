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
                GetProductInformationToShow(productViewModel);
            }
            if(!string.IsNullOrEmpty(btnorder))
            {
               
                string productname = HttpContext.Request.Cookies["ProductName"];
                bool ordersucceed = order.OrderProduct(GetProductInformationToOrder(productname,productViewModel),productdal, (int)HttpContext.Session.GetInt32("UserId"));
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
                string productname = HttpContext.Request.Cookies["ProductName"];
                order.OrderProductToExistingOrder(GetProductInformationToOrder(productname, productViewModel),productdal,productViewModel.chosenordernumber, (int)HttpContext.Session.GetInt32("UserId"));
                return RedirectToAction("Index", "Order");
            }
            return View(productViewModel);
        }
        public Product GetProductInformationToShow(ProductViewModel productviewmodel)
        {
            ProductDAL productdal = new ProductDAL();
            ProductCollection product = new ProductCollection(productdal);
            productviewmodel.products = product.GetProduct(productviewmodel.ProductName);
            
            return productviewmodel.products;
        }
        public Product GetProductInformationToOrder(string productname, ProductViewModel productviewmodel)
        {
            ProductDAL productdal = new ProductDAL();
            ProductCollection product = new ProductCollection(productdal);
           foreach(ProductNameEnum.ProductName name in Enum.GetValues(typeof(ProductNameEnum.ProductName)))
            {
                if(name.ToString() == productname)
                {
                    productviewmodel.products = product.GetProduct(name);
                    break;
                }
            }
            return productviewmodel.products;
        }
    }
    
}
