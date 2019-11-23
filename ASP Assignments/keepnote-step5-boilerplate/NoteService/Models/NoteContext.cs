﻿using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace NoteService.Models
{
    public class NoteContext
    {
        //declare variables to connect to MongoDB database
        MongoClient mongoClient;
        IMongoDatabase database;
        public NoteContext(IConfiguration configuration)
        {
            //Initialize MongoClient and Database using connection string and database name from configuration
            string server = configuration.GetSection("MongoDB:ConnectionString").Value;
            string db = configuration.GetSection("MongoDB:NoteDatabase").Value;
            mongoClient = new MongoClient(server);
            database = mongoClient.GetDatabase(db);
        }

        //Define a MongoCollection to represent the Notes collection of MongoDB based on NoteUser type
        public IMongoCollection<NoteUser> Notes => database.GetCollection<NoteUser>("Note");
    }
}
