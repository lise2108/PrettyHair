using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Windows;
using Domain;

namespace PrettyHair
{
    public class DBController
    {
        private static string connectionString = 
        "Server = ealSQL1.eal.local; Database = A_DB29_2018; User Id = A_STUDENT29; Password = A_OPENDB29;";
        public void CreateCustomer(Customer customer)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("AddCustomer", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@Name", customer.Name));
                    cmd.Parameters.Add(new SqlParameter("@Address", customer.Address));
                    cmd.Parameters.Add(new SqlParameter("@Zip", customer.Zip));
                    cmd.Parameters.Add(new SqlParameter("@Town", customer.Town));
                    cmd.Parameters.Add(new SqlParameter("@Telephone", customer.Telephone));
                    cmd.ExecuteNonQuery();
                }

                catch (SqlException e)
                {
                    throw e;
                }
            }
        }

        public string GetCustomer(int CustomerID)
        {
            string name = "";
            string address = "";
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("GetCustomer", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@CustomerID", CustomerID));
                    SqlDataReader read = cmd.ExecuteReader();

                    while (read.Read())
                    {
                        name = read["Name"].ToString();
                        address = read["Address"].ToString();
                    }
                }

                catch (SqlException e)
                {
                    Console.WriteLine("Fejl " + e.Message); ;
                }
                return name + ";" + address;
            }
        }
    }
}
