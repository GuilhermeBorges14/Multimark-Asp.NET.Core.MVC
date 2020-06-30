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
using Multimark.Models.Enums;

namespace Multimark.Controllers
{
    public class SalesController : Controller
    {
        private readonly SalesService _salesService;
        private readonly ClientService _clientService;
        private readonly StatusService _statusService;

        public SalesController(SalesService salesService, ClientService clientService, StatusService statusService)
        {
            _salesService = salesService;
            _clientService = clientService;
            _statusService = statusService;
        }

        public async Task<IActionResult> Index()
        {
            var list = await _salesService.FindAllAsync();
            var clients = await _clientService.FindAllAsync();
            var status = await _statusService.FindAllAsync();
            var viewModel = new SalesFormViewModel { Clients = clients, Status = status };

            return View(list);
        }

            public async Task<IActionResult> Create()
        {
            var clients = await _clientService.FindAllAsync();
            var status = await _statusService.FindAllAsync();
            var viewModel = new SalesFormViewModel { Clients = clients, Status = status };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Sales sales)
        {


            if (!ModelState.IsValid)
            {
                var clients = await _clientService.FindAllAsync();
                var status = await _statusService.FindAllAsync();
                var viewModel = new SalesFormViewModel { Sales = sales, Clients = clients , Status = status};
                return View(viewModel);
            }

            await _salesService.InsertAsync(sales);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não fornecido!" });
            }

            var obj = await _salesService.FindByIdAsync(id.Value);
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
            await _salesService.RemoveAsync(id);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não fornecido!" });
            }

            var obj = await _salesService.FindByIdAsync(id.Value);
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

            var obj = await _salesService.FindByIdAsync(id.Value);
            if (obj == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não encontrado!" });
            }

            List<Client> clients = await _clientService.FindAllAsync();
            List<Status> status = await _statusService.FindAllAsync();
            SalesFormViewModel viewModel = new SalesFormViewModel { Sales = obj, Clients = clients, Status = status};
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Sales sales)
        {


            if (!ModelState.IsValid)
            {
                var clients = await _clientService.FindAllAsync();
                var status = await _statusService.FindAllAsync();
                var viewModel = new SalesFormViewModel { Sales = sales, Clients = clients, Status = status };
                return View(viewModel);
            }

            if (id != sales.Id)
            {
                return RedirectToAction(nameof(Error), new { message = "Ids não correspondem!" });
            }
            try
            {
                await _salesService.UpdateAsync(sales);
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