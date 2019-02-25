using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public string GetCustomer(int CustomerID)
        {
            return Dbcontroller.GetCustomer(CustomerID);
           
        }

    }
}
