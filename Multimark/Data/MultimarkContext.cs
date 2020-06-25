using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Multimark.Models;

namespace Multimark.Models
{
    public class MultimarkContext : DbContext
    {
        

        public MultimarkContext (DbContextOptions<MultimarkContext> options)
            : base(options)
        {
        }

        public DbSet<Categories> Categories { get; set; }
        
        public DbSet<Product> Product { get; set; }

        public DbSet<Adm> Adms { get; set; }

        public DbSet<Client> Client { get; set; }

        public DbSet<Sales> Sales { get; set; }

        public DbSet<ItemSales> ItemSales { get; set; }

    



    }
}
