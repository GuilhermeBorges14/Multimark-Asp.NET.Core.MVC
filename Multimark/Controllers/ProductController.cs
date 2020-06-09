using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Multimark.Services;
using Multimark.Models;
using Multimark.Models.ViewModels;
using Multimark.Services.Exceptions;
using System.Diagnostics;

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
            var categories = _categoriesService.FindAll();
            var viewModel = new ProductFormViewModel { Categories = categories };
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
            if (!ModelState.IsValid)
            {
                var categories = _categoriesService.FindAll();
                var viewModel = new ProductFormViewModel { Product = product, Categories = categories };
                return View(viewModel);
            }

            _productService.Insert(product);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não fornecido!" });
            }

            var obj = _productService.FindById(id.Value);
            if (obj == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não encontrado!" });
            }

            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            _productService.Remove(id);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não fornecido!" });
            }

            var obj = _productService.FindById(id.Value);
            if (obj == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não encontrado!" });
            }

            return View(obj);
        }

        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não fornecido!" });
            }

            var obj = _productService.FindById(id.Value);
            if (obj == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não encontrado!" });
            }

            List<Categories> categories = _categoriesService.FindAll();
            ProductFormViewModel viewModel = new ProductFormViewModel { Product = obj, Categories = categories };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Product product)
        {


            if (!ModelState.IsValid)
            {
                var categories = _categoriesService.FindAll();
                var viewModel = new ProductFormViewModel { Product = product, Categories = categories };
                return View(viewModel);
            }

            if (id != product.Id)
            {
                return RedirectToAction(nameof(Error), new { message = "Ids não correspondem!" });
            }
            try
            {
                _productService.Update(product);
                return RedirectToAction(nameof(Index));
            }
            catch (ApplicationException e)
            {
                return RedirectToAction(nameof(Error), new { message = e.Message });
            }
        }

        public IActionResult Error(string message)
        {
            var viewModel = new ErrorViewModel
            {
                Message = message,
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
            };
            return View(viewModel);
        }
    }
}