using Receita.Domain.Context;
using Receita.Domain.Repository;

namespace Receita.Infrastructure.Repository
{
    public class CategoriaRepository : RepositoryBase<Categoria>
    {
        private readonly ReceitaContext _context;

        public CategoriaRepository(ReceitaContext context) : base(context)
        {
            _context = context;
        }
    }
}
