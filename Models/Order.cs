using fuzzy.core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace fuzzy.core.Models
{
    public class Order
    {
        public int OrderID { get; set; }

        public string CustomerID { get; set; }

        public OrderDetails OrderItem { get; set; }
    }
}
