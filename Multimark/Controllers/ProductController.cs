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

        public async Task<IActionResult> Index()
        {
            var list = await _productService.FindAllAsync();
            var categories = await _categoriesService.FindAllAsync();
            var viewModel = new ProductFormViewModel { Categories = categories };
            
            return View(list);
        }

        public async Task<IActionResult> Create()
        {
            var categories = await _categoriesService.FindAllAsync();
            var viewModel = new ProductFormViewModel { Categories = categories };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Product product)
        {
            

            if (!ModelState.IsValid)
            {
                var categories = await _categoriesService.FindAllAsync();
                var viewModel = new ProductFormViewModel { Product = product, Categories = categories };
                return View(viewModel);
            }

            await _productService.InsertAsync(product);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não fornecido!" });
            }

            var obj = await _productService.FindByIdAsync(id.Value);
            if (obj == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não encontrado!" });
            }

            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            await _productService.RemoveAsync(id);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não fornecido!" });
            }

            var obj = await _productService.FindByIdAsync(id.Value);
            if (obj == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não encontrado!" });
            }

            return View(obj);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não fornecido!" });
            }

            var obj = await _productService.FindByIdAsync(id.Value);
            if (obj == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não encontrado!" });
            }

            List<Categories> categories = await _categoriesService.FindAllAsync();
            ProductFormViewModel viewModel = new ProductFormViewModel { Product = obj, Categories = categories };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Product product)
        {


            if (!ModelState.IsValid)
            {
                var categories = await _categoriesService.FindAllAsync();
                var viewModel = new ProductFormViewModel { Product = product, Categories = categories };
                return View(viewModel);
            }

            if (id != product.Id)
            {
                return RedirectToAction(nameof(Error), new { message = "Ids não correspondem!" });
            }
            try
            {
                await _productService.UpdateAsync(product);
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