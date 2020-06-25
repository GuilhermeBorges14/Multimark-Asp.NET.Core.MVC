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
            return View(await _context.ItemSales.ToListAsync());
        }

        // GET: ItemSales/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var itemSales = await _context.ItemSales
                .FirstOrDefaultAsync(m => m.Id == id);
            if (itemSales == null)
            {
                return NotFound();
            }

            return View(itemSales);
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
        public async Task<IActionResult> Create([Bind("Id,SalesId,ProductId,Quantity,Price,Subtotal")] ItemSales itemSales)
        {
            if (ModelState.IsValid)
            {
                _context.Add(itemSales);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(itemSales);
        }

        // GET: ItemSales/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var itemSales = await _context.ItemSales.FindAsync(id);
            if (itemSales == null)
            {
                return NotFound();
            }
            return View(itemSales);
        }

        // POST: ItemSales/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,SalesId,ProductId,Quantity,Price,Subtotal")] ItemSales itemSales)
        {
            if (id != itemSales.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(itemSales);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ItemSalesExists(itemSales.Id))
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
            return View(itemSales);
        }

        // GET: ItemSales/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var itemSales = await _context.ItemSales
                .FirstOrDefaultAsync(m => m.Id == id);
            if (itemSales == null)
            {
                return NotFound();
            }

            return View(itemSales);
        }

        // POST: ItemSales/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var itemSales = await _context.ItemSales.FindAsync(id);
            _context.ItemSales.Remove(itemSales);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ItemSalesExists(int id)
        {
            return _context.ItemSales.Any(e => e.Id == id);
        }
    }
}
