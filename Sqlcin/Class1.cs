using Microsoft.EntityFrameworkCore;
using System;

namespace Sqlcin
{
    public class Class1:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=New Database;Trusted_Connection=true");
        }
        public DbSet<Customer> Customers { get; set; }




    }
}
