using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace WebAPI.Models
{
    public class DataAccess:DbContext
    {
        public DataAccess()
           : base("name=DBConnection")
        {
        }

        public virtual DbSet<Customer> Customers { get; set; }
    }
}