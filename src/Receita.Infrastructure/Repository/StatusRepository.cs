using Receita.Domain.Context;
using Receita.Infrastructure.Repository;

namespace Receita.Infrastructure.Repository
{
    public class StatusRepository : RepositoryBase
    {
        private readonly ReceitaContext _context;

        public StatusRepository(ReceitaContext context) : base(context)
        {
            _context = context;
        }
    }
}
