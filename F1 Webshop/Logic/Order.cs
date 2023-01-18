﻿using Logic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Logic
{
    public class Order
    {
        public DateTime Date { get; private set; }
        public int Id { get; private set; }
        public List<Product> OrderedProducts { get; private set; }

        private readonly IorderDAL _dal;
        public Order(IorderDAL order)
        {
            _dal = order;
            Date = DateTime.Now;
        }
        public Order(List<Product> products, int orderid, DateTime date)
        {
            OrderedProducts = products;
            Id = orderid;
            Date = date;
        }
        public bool OrderProduct(Product product, IProductDAL Product, int userid)
        {

            if (CanBeBought(product))
            {
                _dal.MakeOrder(Date, product.Id, userid);
                Product.UpdateProductStock(product.productName);
                return true;
            }
            else
            {
                return false;
            }
        }
          
        public bool OrderProductToExistingOrder(Product product, IProductDAL Product, int orderid, int userid)
        {
            if (CanBeBought(product))
            {
                    _dal.AddOrderToExistingOrder(product.Id,orderid);
                    Product.UpdateProductStock(product.productName);
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool CanBeBought(Product product)
        {            
                if (product.IsProductInStock() == true & product.ProductNeedsEarlyaccess() == false)
                {
                    return true;
                }
                else
                {
                    return false;
                }        
        }
    }
}
