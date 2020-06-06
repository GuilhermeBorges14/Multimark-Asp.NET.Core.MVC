using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Multimark.Models.ViewModels
{
    public class ProductFormViewModel
    {
        public Product Product { get; set; }
        public ICollection<Categories> Categories { get; set; }
    }
}
