using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Multimark.Models;


namespace Multimark.Data
{
    public class SeedingService
    {
        private MultimarkContext _context;

        public SeedingService(MultimarkContext context)
        {
            _context = context;
        }

        public void Seed()
        {
            if (_context.Status.Any())
            {
                return;
            }

            Status s1 = new Status(1, "Finalizada");
            Status s2 = new Status(2, "Cancelada");

            _context.Status.AddRange(s1, s2);
            _context.SaveChanges();
        }
    }
}
