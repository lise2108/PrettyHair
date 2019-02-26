using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;

namespace PrettyHair
{
    public class Controller
    {
        DBController Dbcontroller = new DBController();

        public void CreateCustomer(string name, string address, int zip, string town, string telephone)
        {
            Customer customer = new Customer { Name = name, Address = address, Zip = zip, Town = town, Telephone = telephone };
            Dbcontroller.CreateCustomer(customer);
        }
        public void CreateOrder(DateTime orderDate, DateTime deliveryDate, int productTypeID, int quantity)
        {
            Order order = new Order { OrderDate = orderDate, DeliveryDate = deliveryDate, ProductTypeID = productTypeID, Quantity = quantity };
            Dbcontroller.CreateOrder(order);
        }

        public string GetCustomer(int CustomerID)
        {
            return Dbcontroller.GetCustomer(CustomerID);
        }

    }
}
