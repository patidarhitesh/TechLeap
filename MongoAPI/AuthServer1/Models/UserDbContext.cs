using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthServer1.Models
{
    public class UserDbContext:DbContext
    {
        public UserDbContext() { }
        public UserDbContext(DbContextOptions options) : base(options)
        { this.Database.EnsureCreated(); }
        public DbSet<User> Users { get; set; }
    }
}
