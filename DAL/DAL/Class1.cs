using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace DAL
{
    public class CustomerRepository
    {
        SqlDataAdapter dataAdapter;
        DataSet dataSet;
        public CustomerRepository()
        {
       
            dataAdapter = new SqlDataAdapter("select * from customer", @"server = .\sqlexpress;database=sampledb;integrated security = true");
            dataSet = new DataSet();
            dataAdapter.Fill(dataSet, "Customer");

        }

        public List<Customer> GetCustomers()
        {
            List<Customer> customers = new List<Customer>();
            foreach (DataRow row in dataSet.Tables["Customer"].Rows)
            {
                Customer customer = new Customer();
                customer.CustomerId = Convert.ToInt32(row["customerid"]);
                customer.CustomerName = row["cutomername"].ToString();
                customer.Address = row["address"].ToString();
                customer.Contact = row["contact"].ToString();
                customers.Add(customer);
            }
            return customers;
        }
        public void AddCustomer(Customer customer)
        {
            //Created Empty Row with same structure
            DataRow row = dataSet.Tables["Customer"].NewRow();

            //populated row with values
            row["customerid"] = customer.CustomerId;
            row["cutomername"] = customer.CustomerName;
            row["address"] = customer.Address;
            row["contact"] = customer.Contact;
            dataSet.Tables["Customer"].Rows.Add(row);
        }
        public void RemoveCustomer(int id)
        {
            dataSet.Tables["Customer"].Select($"customerid = {id}")[0].Delete();
        }
        public void UpdateCustomer(Customer customer)
        {
            var r = dataSet.Tables["Customer"].Select($"customerid = {customer.CustomerId}").FirstOrDefault();
            r["address"] = customer.Address;
        }
        public void SaveChanges()
        {
            SqlCommandBuilder commandBuilder = new SqlCommandBuilder(dataAdapter);
            dataAdapter.Update(dataSet, "Customer");
         
        }
    }
}
