using Logic;
using Microsoft.AspNetCore.Mvc.Rendering;
using static Logic.ProductCollection;

namespace F1_Webshop.Models
{
    public class OrderViewModel
    {
        public List<Order> Orders { get; set; }
    }
}
