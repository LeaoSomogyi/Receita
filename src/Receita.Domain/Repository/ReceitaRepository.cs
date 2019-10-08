using Receita.Domain.Context;
using Models = Receita.Domain.Model;

namespace Receita.Domain.Repository
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
