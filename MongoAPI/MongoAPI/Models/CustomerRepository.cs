using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MongoAPI.Models
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly CustomerContext context;

        public CustomerRepository(CustomerContext customerContext)
        {
            context = customerContext;
        }
        public void AddCustomer(Customer customer)
        {
            context.Customers.InsertOne(customer);
        }

        public Customer GetCustomerById(int customerId)
        {
            return context.Customers.Find(c => c.CustomerId == customerId).FirstOrDefault();
        }

        public List<Customer> GetCustomers()
        {
            return context.Customers.Find(_ => true).ToList();
        }

        public bool RemoveCustomer(int customerId)
        {
            var deleteResult = context.Customers.DeleteOne(c => c.CustomerId == customerId);
            return deleteResult.DeletedCount > 0;
        }

        public bool UpdateCustomer(int customerId, Customer customer)
        {
            var filter = Builders<Customer>.Filter.Where(c => c.CustomerId == customerId);
            var update = Builders<Customer>.Update.Set(c => c.Age, customer.Age).Set(c => c.City, customer.City);

            var updateResult = context.Customers.UpdateOne(filter, update);
            //var updateResult = context.Customers.ReplaceOne(filter, customer);

            return updateResult.MatchedCount > 0;
        }
    }
}
