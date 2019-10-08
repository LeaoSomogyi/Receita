using Receita.Domain.Context;
using Receita.Domain.Model;

namespace Receita.Domain.Repository
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
