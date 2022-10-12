using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class Product
    {

       
        private ProductName productName { get; set; }
        private Sizes Size { get; set; }
        private decimal Price { get; set; }
        private int Stock { get; set; }
        private double Points { get; set; }
        private bool HasEarlyAccess { get; set; }
        public enum Sizes
        {
            Small,
            Medium,
            Large,
            XL
        }
        public enum ProductName
        {
            Tshirt,
            Cap,
            Trousers
        }
        public Product(decimal prize, ProductName productname, int stock, double points)
        {
            Price = prize;
            productName = productname;
            Stock = stock;
            Points = points;
        }


        public int GetStock()
        {
            Stock = 10;
            return Stock;
        }
        public double CalculatePoints()
        {
            Points = (double)Price * 10;
            Points = Math.Round(Points, 0);
            return Points;
        }
        public decimal CalculatePrice()
        {
            if(ProductName.Tshirt == productName)
            {
                Price = 22;
            }
           else if (ProductName.Cap == productName)
            {
                Price = 23;
            }
            else if (ProductName.Trousers == productName)
            {
                Price = 18.99m;
            }
            return Price;
        }
    }
}
