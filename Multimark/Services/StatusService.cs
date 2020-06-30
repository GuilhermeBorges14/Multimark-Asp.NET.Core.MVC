using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Multimark.Models;
using Microsoft.EntityFrameworkCore;

namespace Multimark.Services
{
    public class StatusService
    {
        private readonly MultimarkContext _context;

        public StatusService(MultimarkContext context)
        {
            _context = context;
        }

        public async Task<List<Status>> FindAllAsync()
        {
            return await _context.Status.ToListAsync();
        }
    }
}
