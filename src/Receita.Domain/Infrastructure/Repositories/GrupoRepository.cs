using Receita.Domain.Infrastructure.Context;
using Receita.Domain.Infrastructure.Repositories.Base;
using Receita.Domain.Models;

namespace Receita.Domain.Infrastructure.Repositories
{
    internal class GrupoRepository : RepositoryBase<Grupo>
    {
        private readonly ReceitaContext _context;

        public GrupoRepository(ReceitaContext context) : base(context)
        {
            _context = context;
        }
    }
}
