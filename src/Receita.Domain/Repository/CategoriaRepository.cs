using Receita.Domain.Context;
using Receita.Domain.Model;

namespace Receita.Domain.Repository
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
