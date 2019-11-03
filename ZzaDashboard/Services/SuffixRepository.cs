using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Zza.Data;

namespace ZzaDashboard.Services
{
    public class SuffixRepository : ISuffixRepository
    {
        ZzaDbContext _context = new ZzaDbContext();

        public Task<List<Suffix>> GetSuffixsAsync()
        {
            return _context.Suffixes.ToListAsync();
        }

        public Task<Suffix> GetSuffixAsync(int id)
        {
            return _context.Suffixes.FirstOrDefaultAsync(c => c.Id == id);
        }

      
    }
}
