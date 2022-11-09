using Microsoft.AspNetCore.Mvc.Rendering;
using static Logic.Product;

namespace F1_Webshop.Models
{
    public class OrderViewModel
    {
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public double Points { get; set; }
        public ProductName Productname { get; set; }

    }
}
