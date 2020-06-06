using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Multimark.Services;
using Multimark.Models;
using Multimark.Models.ViewModels;

namespace Multimark.Controllers
{
    public class ProductController : Controller
    {
        private readonly ProductService _productService;
        private readonly CategoriesService _categoriesService;

        public ProductController(ProductService productService, CategoriesService categoriesService)
        {
            _productService = productService;
            _categoriesService = categoriesService;
        }

        public IActionResult Index()
        {
            var list = _productService.FindAll();
            return View(list);
        }

        public IActionResult Create()
        {
            var categories = _categoriesService.FindAll();
            var viewModel = new ProductFormViewModel { Categories = categories };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Product product)
        {
            _productService.Insert(product);
            return RedirectToAction(nameof(Index)) ;
        }
    }
}