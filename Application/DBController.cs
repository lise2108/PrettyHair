using Domain;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace Application
{
    public class DBController
    {
        private static readonly string connectionString =
        "Server = ealSQL1.eal.local; Database = A_DB29_2018; User Id = A_STUDENT29; Password = A_OPENDB29;";
        public void CreateCustomer(Customer customer)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("AddCustomer", con)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    cmd.Parameters.Add(new SqlParameter("@Name", customer.Name));
                    cmd.Parameters.Add(new SqlParameter("@Address", customer.Address));
                    cmd.Parameters.Add(new SqlParameter("@Zip", customer.Zip));
                    cmd.Parameters.Add(new SqlParameter("@Town", customer.Town));
                    cmd.Parameters.Add(new SqlParameter("@Telephone", customer.Telephone));
                    cmd.ExecuteNonQuery();

                }

                catch (SqlException e)
                {
                    Console.WriteLine("Fejl " + e.Message);
                }
            }
        }
        public void CreateOrder(Order order)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("AddOrder", con)
                    {
                        CommandType = CommandType.StoredProcedure
                    };

                    cmd.Parameters.Add(new SqlParameter("@OrderDate", order.OrderDate));
                    cmd.Parameters.Add(new SqlParameter("@DeliveryDate", order.DeliveryDate));
                    cmd.Parameters.Add(new SqlParameter("@CustomerID", order.CustomerID));
                    cmd.Parameters.Add(new SqlParameter("@Picked", order.Picked));

                    cmd.ExecuteNonQuery();
                }

                catch (SqlException e)
                {
                    Console.WriteLine("Fejl " + e.Message);
                }
            }
        }

        public void AddOrderLine(OrderLine orderLine)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("AddOrderLine", con)
                    {
                        CommandType = CommandType.StoredProcedure
                    };

                    cmd.Parameters.Add(new SqlParameter("@OrderID", orderLine.OrderID));
                    cmd.Parameters.Add(new SqlParameter("@ProductID", orderLine.ProductID));
                    cmd.Parameters.Add(new SqlParameter("@Quantity", orderLine.Quantity));
                    cmd.Parameters.Add(new SqlParameter("@Price", orderLine.Price));
                    cmd.ExecuteNonQuery();
                }

                catch (SqlException e)
                {
                    Console.WriteLine("Fejl " + e.Message);
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
                    SqlCommand cmd = new SqlCommand("GetCustomer", con)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
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
                    Console.WriteLine("Fejl " + e.Message);
                }
                return name + ";" + address;
            }
        }
        public int GetOrderID()
        {
            int orderidX = 0;
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("GetOrderID", con)
                    {
                        CommandType = CommandType.StoredProcedure
                    };

                    SqlDataReader read = cmd.ExecuteReader();

                    while (read.Read())
                    {
                        orderidX = read.GetInt32(0);
                    }
                }

                catch (SqlException e)
                {
                    Console.WriteLine("Fejl " + e.Message);
                }
                return orderidX;
            }
        }
        public int GetCustomerID()
        {
            int customeridX = 0;
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("GetCustomerID", con)
                    {
                        CommandType = CommandType.StoredProcedure
                    };

                    SqlDataReader read = cmd.ExecuteReader();

                    while (read.Read())
                    {
                        customeridX = read.GetInt32(0);
                    }
                }

                catch (SqlException e)
                {
                    Console.WriteLine("Fejl " + e.Message);
                }
                return customeridX;
            }
        }

        public string[] GetPrice()
        {
            List<double> temppName = new List<double>();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SELECT * FROM A_DB29_2018.dbo.K_Product", con);
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        temppName.Add(reader.GetDouble(3));
                    }
                }
                catch (Exception e)
                {
                    throw e;
                }
                double[] pPrice = temppName.ToArray();

                string[] result = pPrice.Select(x => x.ToString()).ToArray();
                return result;
            }
        }

        public string GetDescription(int descriptionID)
        {
            string description = "";
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("GetDescription", con)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    cmd.Parameters.Add(new SqlParameter("@DescriptionID", descriptionID));
                    SqlDataReader read = cmd.ExecuteReader();

                    while (read.Read())
                    {
                        description = read["Description"].ToString();
                    }
                }

                catch (SqlException e)
                {
                    Console.WriteLine("Fejl " + e.Message);
                }
                return description;
            }
        }
            public string[] GetProducts()
            {
                List<string> temppName = new List<string>();
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    try
                    {
                        con.Open();
                        SqlCommand cmd = new SqlCommand("SELECT * FROM A_DB29_2018.dbo.K_Product", con);
                        SqlDataReader reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            temppName.Add(reader.GetString(1));
                        }
                    }
                    catch (Exception e)
                    {
                        throw e;
                    }
                    string[] pName = temppName.ToArray();
                    return pName;
                }
            }

            public int[] GetQuantity()
            {
                List<int> temppName = new List<int>();
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    try
                    {
                        con.Open();
                        SqlCommand cmd = new SqlCommand("SELECT * FROM A_DB29_2018.dbo.K_Product", con);
                        SqlDataReader reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            temppName.Add(reader.GetInt32(4));
                        }
                    }
                    catch (Exception e)
                    {
                        throw e;
                    }
                    int[] pQuantity = temppName.ToArray();
                    return pQuantity;
                }
            }
        }
    }
