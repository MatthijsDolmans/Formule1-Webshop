﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Logic.Product;

namespace Logic
{
    public interface IproductDAL
    {
        List<Product> GetProduct(ProductName productname);
    }
}