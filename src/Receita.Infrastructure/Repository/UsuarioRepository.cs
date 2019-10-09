using Receita.Domain.Context;

namespace Receita.Infrastructure.Repository
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
