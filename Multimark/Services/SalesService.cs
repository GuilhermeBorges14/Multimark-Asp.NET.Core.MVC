using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Multimark.Models;
using Microsoft.EntityFrameworkCore;
using Multimark.Services.Exceptions;

namespace Multimark.Services
{
    public class SalesService
    {
        private readonly MultimarkContext _context;

        public SalesService(MultimarkContext context)
        {
            _context = context;
        }

        public async Task<List<Sales>> FindAllAsync()
        {
            return await _context.Sales.ToListAsync();
        }

        public async Task InsertAsync(Sales obj)
        {
            _context.Add(obj);
            await _context.SaveChangesAsync();
        }

        public async Task<Sales> FindByIdAsync(int id)
        {
            return await _context.Sales.Include(obj => obj.Client).FirstOrDefaultAsync(x => x.Id == id);
        }


        public async Task RemoveAsync(int id)
        {
            var obj = await _context.Sales.FindAsync(id);
            _context.Sales.Remove(obj);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Sales obj)
        {
            bool hasAny = await _context.Sales.AnyAsync(x => x.Id == obj.Id);

            if (!hasAny)
            {
                throw new NotFoundException("Id não encontrado!");
            }
            try
            {
                _context.Update(obj);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException exp)
            {
                throw new DbConcurrencyException(exp.Message);
            }
        }


    }
}
