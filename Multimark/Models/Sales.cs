using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Multimark.Models.Enums;

namespace Multimark.Models
{
    public class Sales
    {
        public int Id { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime Date { get; set; }
        public Client Client { get; set; }
        public int ClientId { get; set; }

        [Required(ErrorMessage = "Preço obrigatório")]
        [DisplayFormat(DataFormatString = "{0:F2}")]
        public double Total { get; set; }
        public Status Status { get; set; }

        public ICollection<Sales> Saless{ get; set; } = new List<Sales>();


        public Sales()
        {

        }

        public Sales(int id, DateTime date, Client client, double total)
        {
            Id = id;
            Date = date;
            Client = client;
            Total = total;
        }

        public void AddSales(Sales sales)
        {
            Saless.Add(sales);
        }

        public void RemoveSales(Sales sales)
        {
            Saless.Remove(sales);
        }

        public double TotalSales(DateTime initial, DateTime final)
        {
            return Saless.Where(sr => sr.Date >= initial && sr.Date <= final).Sum(sr => sr.Total);
        }
    }
}
