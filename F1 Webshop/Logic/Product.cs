using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class Product
    {

        public enum ProductName
        {
            Tshirt,
            Cap
        }
        private string productName { get; set; }
        private decimal Price { get; set; }
        private int Stock { get; set; }
        private double Points { get; set; }
        private bool HasEarlyAccess { get; set; }
        private enum Sizes
        {
            Small,
            Medium,
            Large,
            XL
        }
        public Product(decimal prize, string productname, int stock, double points, bool hasearlyaccess)
        {
            Price = prize;
            productName = productname;
            Stock = stock;
            Points = points;
            HasEarlyAccess = hasearlyaccess;
        }

        public Product (string productname)
        {
            productName = productname;
        }
        public Product(decimal price)
        {
            Price = price;
        }
        public double CalculatePoints()
        {
            Points = (double)Price * 10;
            Points = Math.Round(Points, 0);
            return Points;
        }
        public decimal CalculatePrice()
        {
            if("Cap" == productName)
            {
                Price = 22;
            }
            return Price;
        }
    }
}
