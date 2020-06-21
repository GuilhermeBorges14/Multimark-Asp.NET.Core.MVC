using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Multimark.Models
{
    public class Sale
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int ClientId { get; set; }
        public double Total { get; set; }
    }
}
