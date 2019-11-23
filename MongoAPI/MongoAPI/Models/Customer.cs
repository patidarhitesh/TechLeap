using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MongoAPI.Models
{
    public class Customer
    {
        [BsonId] //will map _id to customerid
        public int CustomerId { get; set; }
        [BsonElement("name")]//to map C# property with mongodb document property
        public string Name { get; set; }
        public int Age { get; set; }
        public string City { get; set; }
    }
}
