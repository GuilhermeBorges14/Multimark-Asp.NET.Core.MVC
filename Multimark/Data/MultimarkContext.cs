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

        public DbSet<Multimark.Models.Categories> Categories { get; set; }
    }
}
