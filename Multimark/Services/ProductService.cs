using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Multimark.Models;
using Microsoft.EntityFrameworkCore;
using Multimark.Services.Exceptions;

namespace Multimark.Services
{
    public class ProductService
    {
        private readonly MultimarkContext _context;

        public ProductService(MultimarkContext context)
        {
            _context = context;
        }

        public async Task<List<Product>> FindAllAsync()
        {
            return await _context.Product.ToListAsync();
        }

        public async Task InsertAsync(Product obj)
        {
            _context.Add(obj);
           await _context.SaveChangesAsync();
        }

        public async Task<Product> FindByIdAsync(int id)
        {
            return await _context.Product.Include(obj => obj.Categorie).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task RemoveAsync(int id)
        {
            var obj = await _context.Product.FindAsync(id);
            _context.Product.Remove(obj);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Product obj)
        {
            bool hasAny = await _context.Product.AnyAsync(x => x.Id == obj.Id);

            if (!hasAny)
            {
                throw new NotFoundException("Id não encontrado!");
            }
            try
            {
                _context.Update(obj);
               await _context.SaveChangesAsync();
            }
            catch(DbUpdateConcurrencyException exp)
            {
                throw new DbConcurrencyException(exp.Message);
            }
        }
    }
}
