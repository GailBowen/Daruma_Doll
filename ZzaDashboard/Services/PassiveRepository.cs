using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Zza.Data;

namespace ZzaDashboard.Services
{
    public class PassiveRepository : IPassiveRepository
    {
        ZzaDbContext _context = new ZzaDbContext();

        public Task<List<Passive>> GetPassivesAsync()
        {
            return _context.Passives.ToListAsync();
        }
              
    }
}
