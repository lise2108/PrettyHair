using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;

namespace Application
{
    public class Controller
    {
        DBController Dbcontroller = new DBController();

        public void CreateCustomer(string name, string address, int zip, string town, string telephone)
        {
            Customer customer = new Customer { Name = name, Address = address, Zip = zip, Town = town, Telephone = telephone };
            Dbcontroller.CreateCustomer(customer);
        }
        public void CreateOrder(DateTime orderDate, DateTime deliveryDate, int customerID, bool picked)
        {
            Order order = new Order { OrderDate = orderDate, DeliveryDate = deliveryDate, CustomerID = customerID, Picked = picked };
            Dbcontroller.CreateOrder(order);
        }

        public string GetCustomer(int CustomerID)
        {
            return Dbcontroller.GetCustomer(CustomerID);
        }

        public string GetOrderID()
        {
            return Dbcontroller.GetOrderID();
        }
        

        public void AddOrderLine(int orderID, int productID, int quantity, double price)
        {
            OrderLine orderLine = new OrderLine { OrderID = orderID, ProductID = productID, Quantity = quantity, Price = price};
            Dbcontroller.AddOrderLine(orderLine);
        }
    }
}
