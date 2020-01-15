using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Zza.Data;

namespace ZzaDashboard.Services
{
    public interface INonFiniteSuffixRepository
    {
        Task<List<NonFiniteSuffix>> GetNonFiniteSuffixsAsync();
        Task<NonFiniteSuffix> GetNonFiniteSuffixAsync(int id);
        
    }
}
