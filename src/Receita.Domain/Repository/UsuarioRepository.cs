using Receita.Domain.Context;
using Receita.Domain.Model;

namespace Receita.Domain.Repository
{
    public class UsuarioRepository : RepositoryBase<Usuario>
    {
        private readonly ReceitaContext _context;

        public UsuarioRepository(ReceitaContext context) : base(context)
        {
            _context = context;
        }
    }
}
