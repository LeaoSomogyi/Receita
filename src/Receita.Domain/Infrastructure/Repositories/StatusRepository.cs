using Receita.Domain.Infrastructure.Context;
using Receita.Domain.Infrastructure.Repositories.Base;
using Receita.Domain.Models;

namespace Receita.Infrastructure.Repositories
{
    internal class StatusRepository : RepositoryBase<Status>
    {
        private readonly ReceitaContext _context;

        public StatusRepository(ReceitaContext context) : base(context)
        {
            _context = context;
        }
    }
}
