using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Multimark.Models
{
    public class Client
    {
        public int Id { get; set; }
        public string Name { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime Date { get; set; }
        public string Cpf_Cnpj { get; set; }
        public string Rg { get; set; }
        public string Address { get; set; }
        public int AddressNumber { get; set; }
        public string Neighborhood { get; set; }
        public string City { get; set; }
        public string TelePhone { get; set; }
        public string CellPhone { get; set; }
        public string Email { get; set; }
        public string Comments { get; set; }

        public ICollection<Sales> Sales { get; set; } = new List<Sales>();

        public Client()
        {

        }


        public Client(int id, string name, DateTime date, string cpf_Cnpj, string rg, string address, int addressNumber, string neighborhood, string city, string telePhone, string cellPhone, string email, string comments)
        {
            Id = id;
            Name = name;
            Date = date;
            Cpf_Cnpj = cpf_Cnpj;
            Rg = rg;
            Address = address;
            AddressNumber = addressNumber;
            Neighborhood = neighborhood;
            City = city;
            TelePhone = telePhone;
            CellPhone = cellPhone;
            Email = email;
            Comments = comments;
        }

        public void AddSale(Sales sales)
        {
            Sales.Add(sales);
        }

        public double TotalSales(DateTime initial, DateTime final)
        {
            return Sales.Sum(sale => sale.TotalSales(initial, final));
        }
    }
}
