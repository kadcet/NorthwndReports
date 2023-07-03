﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormUI.Data
{
    public class OrderDetail
    {
        public int OrderID { get; set; }
        public int ProductID { get; set; }
        public Product Product { get; set; }
        public Order Order { get; set; }


        public decimal UnitPrice { get; set; }
        public short Quantity { get; set; }
    }
}
