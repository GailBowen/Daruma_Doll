using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Zza.Data;

namespace ZzaDashboard.Services
{
    public class NonFiniteSuffixRepository : INonFiniteSuffixRepository
    {
        ZzaDbContext _context = new ZzaDbContext();

        public Task<List<NonFiniteSuffix>> GetNonFiniteSuffixsAsync()
        {
            return _context.NonFiniteSuffixes.ToListAsync();
        }

        public Task<NonFiniteSuffix> GetNonFiniteSuffixAsync(int id)
        {
            return _context.NonFiniteSuffixes.FirstOrDefaultAsync(c => c.Id == id);
        }

      
    }
}
