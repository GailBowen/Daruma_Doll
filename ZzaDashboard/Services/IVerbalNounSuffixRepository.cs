using System.Collections.Generic;
using System.Threading.Tasks;
using Zza.Data;

namespace ZzaDashboard.Services
{
    public interface IVerbalNounSuffixRepository
    {
        Task<List<VerbalNounSuffix>> GetVerbalNounSuffixsAsync();
        Task<VerbalNounSuffix> GetVerbalNounSuffixAsync(int id);
    }
}
