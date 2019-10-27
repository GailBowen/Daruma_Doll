using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Zza.Data;

namespace ZzaDashboard.Services
{
    public interface IPrincipalPartsRepsository
    {
        Task<List<PrincipalPart>> GetPrincipalPartsAsync();
        Task<PrincipalPart> GetPrincipalPartAsync(Guid id);
        Task<PrincipalPart> AddPrincipalPartAsync(PrincipalPart principalPart);
        Task<PrincipalPart> UpdatePrincipalPartAsync(PrincipalPart principalPart);
        Task DeletePrincipalPartAsync(Guid principalPartId);
    }
}
