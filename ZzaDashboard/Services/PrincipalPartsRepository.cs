using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Zza.Data;

namespace ZzaDashboard.Services
{
    public class PrincipalPartsRepository : IPrincipalPartsRepsository
    {
        ZzaDbContext _context = new ZzaDbContext();

        public Task<List<PrincipalPart>> GetPrincipalPartsAsync()
        {
            return _context.PrincipalParts.ToListAsync();
        }

        public Task<PrincipalPart> GetPrincipalPartAsync(Guid id)
        {
            return _context.PrincipalParts.FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<PrincipalPart> AddPrincipalPartAsync(PrincipalPart principalPart)
        {
            _context.PrincipalParts.Add(principalPart);
            await _context.SaveChangesAsync();
            return principalPart;
        }

        public async Task<PrincipalPart> UpdatePrincipalPartAsync(PrincipalPart principalPart)
        {
            if (!_context.PrincipalParts.Local.Any(c => c.Id == principalPart.Id))
            {
                _context.PrincipalParts.Attach(principalPart);
            }
            _context.Entry(principalPart).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return principalPart;

        }

        public async Task DeletePrincipalPartAsync(Guid principalPartId)
        {
            var principalPart = _context.PrincipalParts.FirstOrDefault(c => c.Id == principalPartId);
            if (principalPart != null)
            {
                _context.PrincipalParts.Remove(principalPart);
            }
            await _context.SaveChangesAsync();
        }
    }
}
