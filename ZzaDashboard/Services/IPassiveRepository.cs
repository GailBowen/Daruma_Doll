using System.Collections.Generic;
using System.Threading.Tasks;
using Zza.Data;

namespace ZzaDashboard.Services
{
    public interface IPassiveRepository
    {
        Task<List<Passive>> GetPassivesAsync();
    }
}
