using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;

namespace DAL
{
    public class ConnectedRepository
    {
        SqlConnection con;
        SqlConnection cmd;
        public List<Customer> GetCustomers()
        {
            List<Customer> customers = new List<Customer>();
            using (SqlConnection con = new SqlConnection())
            {
                con.ConnectionString = @"server = .\sqlexpress; database = sampledb; integrated security = true";
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = "Select * from Customer";
                    cmd.Connection = con;
                    con.Open();
                    SqlDataReader sdr = cmd.ExecuteReader();
                    while (sdr.Read())
                    {
                        Customer customer = new Customer();
                        customer.CustomerId = Convert.ToInt32(sdr["customerid"]);
                        customer.CustomerName = sdr["cutomername"].ToString();
                        customer.Address = sdr["address"].ToString();
                        customer.Contact = sdr["contact"].ToString();
                        customers.Add(customer);
                    }
                    con.Close();
                }
                return customers;
            }

        }
        public int AddCustomer(Customer customer)
        {
            int rows = 0;
            using (SqlConnection con = new SqlConnection())
            {
                con.ConnectionString = @"server = .\sqlexpress; database = sampledb; integrated security = true";
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = $"Insert into customer values({customer.CustomerId},'{customer.CustomerName}','{customer.Address}','{customer.Contact}')";
                    cmd.Connection = con;
                    con.Open();
                    //For Insert, Update and Delete, Use ExecuteNonQuerry
                    rows = cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
            return rows;
        }
        public int GetOrderAmount()
        {
            int totalAmount = 0;

            using (SqlConnection con = new SqlConnection())
            {
                con.ConnectionString = @"server = .\sqlexpress; database = sampledb; integrated security = true";
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = $"Select sum(amount) from orders";
                    cmd.Connection = con;
                    con.Open();
                    //For Insert, Update and Delete, Use ExecuteNonQuerry
                    totalAmount = Convert.ToInt32(cmd.ExecuteScalar());
                    con.Close();
                }
            }
            return totalAmount;
        }
        public List<Customer> GetCustomerByLocation(string address)
        {
            List<Customer> customers = new List<Customer>();

            using (SqlConnection con = new SqlConnection())
            {
                con.ConnectionString = @"server = .\sqlexpress; database = sampledb; integrated security = true";
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText ="sp_getcustomer";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@addr", address);
                    cmd.Connection = con;
                    con.Open();
                    //For Insert, Update and Delete, Use ExecuteNonQuerry
                    SqlDataReader sdr = cmd.ExecuteReader();
                    while (sdr.Read())
                    {
                        Customer customer = new Customer();
                        customer.CustomerId = Convert.ToInt32(sdr["customerid"]);
                        customer.CustomerName = sdr["cutomername"].ToString();
                        customer.Address = sdr["address"].ToString();
                        customer.Contact = sdr["contact"].ToString();
                        customers.Add(customer);
                    }
                    con.Close();
                }
                return customers;
            }
        }
    }
}
