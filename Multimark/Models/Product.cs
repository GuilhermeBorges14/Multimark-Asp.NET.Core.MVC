﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Multimark.Models.Enums;

namespace Multimark.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Categories Categorie { get; set; }

        [DisplayFormat(DataFormatString = "{0:F2}")]
        public double Price { get; set; }
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
