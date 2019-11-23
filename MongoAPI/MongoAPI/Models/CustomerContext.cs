using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MongoAPI.Models
{
    public class CustomerContext
    {
        MongoClient mongoClient;
        IMongoDatabase database;

        public CustomerContext(IConfiguration configuration)
        {
            string server = configuration.GetSection("MongoDB:server").Value;
            string db = configuration.GetSection("MongoDB:database").Value;

            mongoClient = new MongoClient(server);
            database = mongoClient.GetDatabase(db);
        }

        public IMongoCollection<Customer> Customers => database.GetCollection<Customer>("Customers"); //equivalent to get property
                                    //here collection name                             mongodb collection name
        //ie
        //public IMongoCollection<Customer> Customers
        //{
        //    get
        //    {
        //        return database.GetCollection<Customer>("Customers"); 
        //    }
        //}
    }
}
