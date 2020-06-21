using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Multimark.Models;

namespace Multimark.Controllers
{
    public class ItemSalesController : Controller
    {
        private readonly MultimarkContext _context;

        public ItemSalesController(MultimarkContext context)
        {
            _context = context;
        }

        // GET: ItemSales
        public async Task<IActionResult> Index()
        {
            return View(await _context.ItemSale.ToListAsync());
        }

        // GET: ItemSales/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var itemSale = await _context.ItemSale
                .FirstOrDefaultAsync(m => m.Id == id);
            if (itemSale == null)
            {
                return NotFound();
            }

            return View(itemSale);
        }

        // GET: ItemSales/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ItemSales/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ProductId,SaleId,ProductQuantity,ProductPrice,SubTotal")] ItemSale itemSale)
        {
            if (ModelState.IsValid)
            {
                _context.Add(itemSale);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(itemSale);
        }

        // GET: ItemSales/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var itemSale = await _context.ItemSale.FindAsync(id);
            if (itemSale == null)
            {
                return NotFound();
            }
            return View(itemSale);
        }

        // POST: ItemSales/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ProductId,SaleId,ProductQuantity,ProductPrice,SubTotal")] ItemSale itemSale)
        {
            if (id != itemSale.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(itemSale);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ItemSaleExists(itemSale.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(itemSale);
        }

        // GET: ItemSales/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var itemSale = await _context.ItemSale
                .FirstOrDefaultAsync(m => m.Id == id);
            if (itemSale == null)
            {
                return NotFound();
            }

            return View(itemSale);
        }

        // POST: ItemSales/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var itemSale = await _context.ItemSale.FindAsync(id);
            _context.ItemSale.Remove(itemSale);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ItemSaleExists(int id)
        {
            return _context.ItemSale.Any(e => e.Id == id);
        }
    }
}
