﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Order
    {
        public DateTime OrderDate { get; set; }
        public DateTime DeliveryDate { get; set; }
        public int ProductTypeID { get; set; }
        public int Quantity { get; set; }
    }
}
