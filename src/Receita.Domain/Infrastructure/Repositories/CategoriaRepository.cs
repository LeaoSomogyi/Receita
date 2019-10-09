using Receita.Domain.Infrastructure.Context;
using Receita.Domain.Infrastructure.Repositories.Base;
using Receita.Domain.Models;

namespace Receita.Domain.Infrastructure.Repositories
{
    internal class CategoriaRepository : RepositoryBase<Categoria>
    {
        private readonly ReceitaContext _context;

        public CategoriaRepository(ReceitaContext context) : base(context)
        {
            _context = context;
        }
    }
}
