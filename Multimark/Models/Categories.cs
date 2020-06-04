using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Multimark.Models
{
    public class Categories
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Product> Products { get; set; } = new List<Product>();

        public Categories()
        {

        }

        public Categories(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public void AddProduct(Product product)
        {
            Products.Add(product);
        }
    }
}
