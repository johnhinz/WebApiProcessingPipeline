using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebApplication15
{
    public class HumberContext : DbContext
    {
        public HumberContext() : base(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=HumberDatabase;Integrated Security=True;")
        {
        }
        public DbSet<Customer> Customers { get; set; }
    }

    public class Customer
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime Dob { get; set; }

    }
}