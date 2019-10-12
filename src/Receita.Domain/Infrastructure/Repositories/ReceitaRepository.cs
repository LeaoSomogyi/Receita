using Microsoft.EntityFrameworkCore;
using Receita.Domain.Infrastructure.Repositories.Base;
using Receita.Domain.Infrastructure.Repositories.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Receita.Domain.Infrastructure.Repositories
{
    public class ReceitaRepository : RepositoryBase<Models.Receita>, IReceitaRepository
    {
        private readonly DbContext _context;

        public ReceitaRepository(DbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Models.Receita>> GetPorCategoriaAsync(int id)
        {
            return await _context.Set<Models.Receita>().Where(r => r.IdCategoria == id).ToListAsync();
        }
    }
}
