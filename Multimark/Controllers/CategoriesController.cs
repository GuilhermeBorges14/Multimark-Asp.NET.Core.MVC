using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Multimark.Models;

namespace Multimark.Controllers
{
    public class CategoriesController : Controller
    {
        public IActionResult Index()
        {
            List<Categories> categoriesList = new List<Categories>();
            categoriesList.Add(new Categories { Id = 1, Name = "Roupas" });
            categoriesList.Add(new Categories { Id = 2, Name = "Acessórios" });

            return View(categoriesList);
        }
    }
}