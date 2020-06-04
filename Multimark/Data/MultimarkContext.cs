using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

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
    }
}
