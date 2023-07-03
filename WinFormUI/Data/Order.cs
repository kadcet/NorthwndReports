using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormUI.Data
{
    public class Order
    {
        public int OrderID { get; set; }
        public ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
