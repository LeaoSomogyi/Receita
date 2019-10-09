using Receita.Domain.Context;
using Receita.Domain.Repository;

namespace Receita.Infrastructure.Repository
{
    public class PapelRepository : RepositoryBase<Grupo>
    {
        private readonly ReceitaContext _context;

        public PapelRepository(ReceitaContext context) : base(context)
        {
            _context = context;
        }
    }
}
