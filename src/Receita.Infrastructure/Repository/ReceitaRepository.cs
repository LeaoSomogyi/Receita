using Receita.Domain.Context;
using Receita.Domain.Repository;

namespace Receita.Infrastructure.Repository
{
    public class ReceitaRepository : RepositoryBase<Models.Receita>
    {
        private readonly ReceitaContext _context;

        public ReceitaRepository(ReceitaContext context) : base(context)
        {
            _context = context;
        }
    }
}
