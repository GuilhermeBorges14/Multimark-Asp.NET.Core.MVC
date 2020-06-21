using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Multimark.Models.ViewModels
{
    public class ClientFormViewModel
    {
        public Sale Sale { get; set; }
        public ICollection<Client> Clients { get; set; }
    }
}
