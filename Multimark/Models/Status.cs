using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Multimark.Models
{
    public class Status
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Sales> Sales { get; set; } = new List<Sales>();

        public Status()
        {

        }

        public Status(int id, string name)
        {
            Id = id;
            Name = name;
        }


    }
}
