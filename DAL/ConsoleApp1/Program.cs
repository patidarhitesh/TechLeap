using System;
using DAL;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            //CustomerRepository repository = new CustomerRepository();
            Customer customer1 = new Customer { CustomerId = 115, CustomerName = "Sagar", Address = "Faridabad", Contact = "1234567890" };
            //Customer customer2 = new Customer { CustomerId = 111, CustomerName = "Hitesh", Address = "Delhi", Contact = "1234567890" };

            ////repository.AddCustomer(customer1);
            ////repository.RemoveCustomer(104);
            //repository.UpdateCustomer(customer2);
            //repository.SaveChanges();

            ConnectedRepository repository = new ConnectedRepository();
            //repository.AddCustomer(customer1);
            // Console.WriteLine(repository.GetOrderAmount());


            var customers = repository.GetCustomerByLocation("Delhi");
            //Console.WriteLine("Customer List");
            //var customers = repository.GetCustomers();
            foreach (Customer customer in customers)
            {
                Console.WriteLine($"Id: {customer.CustomerId},  Name: {customer.CustomerName}, Address: {customer.Address}, Contact: {customer.Contact}");
            }
            
        }
    }
}
