using Microsoft.EntityFrameworkCore;
using Receita.Domain.Infrastructure.Context;
using Receita.Domain.Infrastructure.Repositories.Base;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Models = Receita.Domain.Models;

namespace Receita.Infrastructure.Repositories
{
    internal class ReceitaRepository : RepositoryBase<Models.Receita>
    {
        private readonly ReceitaContext _context;

        public ReceitaRepository(ReceitaContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Models.Receita>> GetPorCategoriaAsync(int id) 
        {
            return await _context.Receitas.Where(r => r.IdCategoria == id).ToListAsync();
        }
    }
}
