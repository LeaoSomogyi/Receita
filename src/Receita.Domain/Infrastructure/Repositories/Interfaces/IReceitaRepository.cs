using Receita.Domain.Infrastructure.Repositories.Base;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Receita.Domain.Infrastructure.Repositories.Interfaces
{
    public interface IReceitaRepository : IRepositoryBase<Models.Receita> 
    {
        Task<IEnumerable<Models.Receita>> GetPorCategoriaAsync(int id);
    }
}
