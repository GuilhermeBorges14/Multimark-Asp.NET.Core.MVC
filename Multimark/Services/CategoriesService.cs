using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Multimark.Models;
using Microsoft.EntityFrameworkCore;

namespace Multimark.Services
{
    public class CategoriesService
    {
        private readonly MultimarkContext _context;

        public CategoriesService(MultimarkContext context)
        {
            _context = context;
        }

        public async Task<List<Categories>> FindAllAsync()
        {
            return await _context.Categories.OrderBy(x => x.Name).ToListAsync();
        }
    }
}
