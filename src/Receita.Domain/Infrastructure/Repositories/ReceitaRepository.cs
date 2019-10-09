using Receita.Domain.Infrastructure.Context;
using Receita.Domain.Infrastructure.Repositories.Base;
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
    }
}
