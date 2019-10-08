using Receita.Domain.Context;
using Receita.Domain.Model;

namespace Receita.Domain.Repository
{
    public class StatusRepository : RepositoryBase<Status>
    {
        private readonly ReceitaContext _context;

        public StatusRepository(ReceitaContext context) : base(context)
        {
            _context = context;
        }
    }
}
