﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormUI.Data
{
    public class Product
    {
        public string ProductName { get; set; }
        public int ProductID { get; set; }
        public int? CategoryID { get; set; }
        public Category Category { get; set; }

        public ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
