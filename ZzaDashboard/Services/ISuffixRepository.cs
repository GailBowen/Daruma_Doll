using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Zza.Data;

namespace ZzaDashboard.Services
{
    public interface ISuffixRepository
    {
        Task<List<Suffix>> GetSuffixsAsync();
        Task<Suffix> GetSuffixAsync(int id);
        
    }
}
