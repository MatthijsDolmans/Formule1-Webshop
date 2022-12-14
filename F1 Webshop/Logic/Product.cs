
using Logic.Helpers;
using Logic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Logic.Helpers.ProductNameEnum;

namespace Logic
{
    public class Product
    {
        public ProductName productName { get; private set; }
        public decimal Price { get; private set; }
        public int Stock { get; private set; }
        public double Points { get; private set; }
        public int orderid { get; private set; }
        private bool HasEarlyAccess { get; set; } = false;

        private readonly IProductDAL _product;
        public Product(IProductDAL product)
        {
            _product = product;
        }
        public Product(decimal prize, ProductName productname, int stock)
        {
            Price = prize;
            productName = productname;
            Stock = stock;
            Points = CalculatePoints();
        }
        public Product(int Orderid, decimal prize, ProductName productname)
        {
            Price = prize;
            productName = productname;
            orderid = Orderid;
            Points = CalculatePoints();
        }


        public bool IsProductInStock(int stock)
        {
            if(stock <= 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public bool ProductNeedsEarlyaccess()
        {
            if (HasEarlyAccess)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public double CalculatePoints()
        {
            Points = (double)Price * 10;
            Points = Math.Round(Points, 0);
            return Points;
        }
        public void UpdateProductPrice(ProductName productname,decimal Price)
        {
            _product.UpdateProductPrice(productname, Price);
        }
        public void UpdateProductStock(ProductName productname)
        {

            _product.UpdateProductStock(productname);
        }
    }
}
