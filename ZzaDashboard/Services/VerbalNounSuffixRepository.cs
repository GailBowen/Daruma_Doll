using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Zza.Data;

namespace ZzaDashboard.Services
{
    public class VerbalNounSuffixRepository : IVerbalNounSuffixRepository
    {
        ZzaDbContext _context = new ZzaDbContext();

        public Task<List<VerbalNounSuffix>> GetVerbalNounSuffixsAsync()
        {
            return _context.VerbalNounSuffixes.ToListAsync();
        }

        public Task<VerbalNounSuffix> GetVerbalNounSuffixAsync(int id)
        {
            return _context.VerbalNounSuffixes.FirstOrDefaultAsync(c => c.Id == id);
        }

      
    }
}
