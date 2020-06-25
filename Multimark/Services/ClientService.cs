using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Multimark.Models;
using Microsoft.EntityFrameworkCore;

namespace Multimark.Services
{
    public class ClientService
    {
        private readonly MultimarkContext _context;

        public ClientService(MultimarkContext context)
        {
            _context = context;
        }

        public async Task<List<Client>> FindAllAsync()
        {
            return await _context.Client.OrderBy(x => x.Name).ToListAsync();
        }
    }
}
