using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MongoAPI.Models
{
    public interface ICustomerRepository
    {
        void AddCustomer(Customer customer);
        Customer GetCustomerById(int customerId);
        List<Customer> GetCustomers();
        bool RemoveCustomer(int customerId);
        bool UpdateCustomer(int customerId, Customer customer);
    }
}
