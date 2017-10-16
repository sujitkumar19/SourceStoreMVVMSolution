using SportsStoreDomainLibrary2.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsStoreDomainLibrary2.Concrete
{
    class SportsStoreDBcontext:DbContext
    {
        public SportsStoreDBcontext() : base("SportsStoreConnection") { }
        public DbSet<Product> Products { get; set; }
    }
}
