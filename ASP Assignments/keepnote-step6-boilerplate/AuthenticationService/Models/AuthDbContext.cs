using Microsoft.EntityFrameworkCore;

namespace AuthenticationService.Models
{
    public class AuthDbContext:DbContext
    {
        public AuthDbContext() { }
        public AuthDbContext(DbContextOptions options) : base(options)
        {
            
            //make sure that database is auto generated using EF Core Code first
            this.Database.EnsureCreated();
        }

        //Define a Dbset for User in the database
        public DbSet<User> Users { get; set; }
    }
}
