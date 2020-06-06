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

        public List<Product> FindAll()
        {
            return _context.Product.ToList();
        }

        public void Insert(Product obj)
        {
            _context.Add(obj);
            _context.SaveChanges();
        }

        public Product FindById(int id)
        {
            return _context.Product.Include(obj => obj.Categorie).FirstOrDefault(x => x.Id == id);
        }

        public void Remove(int id)
        {
            var obj = _context.Product.Find(id);
            _context.Product.Remove(obj);
            _context.SaveChanges();
        }

        public void Update(Product obj)
        {
            if(!_context.Product.Any(x => x.Id == obj.Id))
            {
                throw new NotFoundException("Id não encontrado!");
            }
            try
            {
                _context.Update(obj);
                _context.SaveChanges();
            }
            catch(DbUpdateConcurrencyException exp)
            {
                throw new DbConcurrencyException(exp.Message);
            }
        }
    }
}
