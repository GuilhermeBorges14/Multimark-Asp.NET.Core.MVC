using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Multimark.Models;

namespace Multimark.Services
{
    public class CategoriesService
    {
        private readonly MultimarkContext _context;

        public CategoriesService(MultimarkContext context)
        {
            _context = context;
        }

        public List<Categories> FindAll()
        {
            return _context.Categories.OrderBy(x => x.Name).ToList();
        }
    }
}
