using System;

namespace Domain
{
    public class Order
    {
        public DateTime OrderDate { get; set; }
        public DateTime DeliveryDate { get; set; }
        public int CustomerID { get; set; }
        public bool Picked { get; set; }
    }
}
