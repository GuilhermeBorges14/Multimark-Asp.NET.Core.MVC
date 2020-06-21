using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Multimark.Models
{
    public class ItemSale
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int SaleId { get; set; }
        public int ProductQuantity { get; set; }
        public double ProductPrice { get; set; }
        public double SubTotal { get; set; }
    }
}
