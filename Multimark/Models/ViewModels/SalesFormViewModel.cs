using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Multimark.Models.Enums;

namespace Multimark.Models.ViewModels
{
    public class SalesFormViewModel
    {
        public Sales Sales { get; set; }
        public ICollection<Client> Clients { get; set; }
        public Status Statuss { get; set; }

    }
}
