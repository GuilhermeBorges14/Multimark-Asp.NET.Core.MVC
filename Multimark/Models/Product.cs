using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Multimark.Models.Enums;
using System.Globalization;

namespace Multimark.Models
{
    public class Product
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="Nome obrigatório")]
        [StringLength(60, MinimumLength = 3, ErrorMessage = "O tamanho do nome deve ser entre 3 e 60 caracteres")]
        public string Name { get; set; }

        public Categories Categorie { get; set; }

        [Required(ErrorMessage = "Preço obrigatório")]
        [DisplayFormat(DataFormatString = "{0:F2}")]
        [Range(0, 500.00, ErrorMessage = "O preço deve ser entre R${1} e R${2}")]
        public double Price { get; set; }

        [Required(ErrorMessage = "Quantidade obrigatórioa")]
        public int Quantity { get; set; }

        public Size Size { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime Date { get; set; }

        public int CategoriesId { get; set; }


        public Product()
        {

        }

        public Product(int id, string name, Categories categorie, double price, int quantity, Size size, DateTime date)
        {
            Id = id;
            Name = name;
            Categorie = categorie;
            Price = price;
            Quantity = quantity;
            Size = size;
            Date = date;
        }

        
        
    }
}
