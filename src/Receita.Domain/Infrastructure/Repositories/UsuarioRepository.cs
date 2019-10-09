using Receita.Domain.Infrastructure.Context;
using Receita.Domain.Infrastructure.Repositories.Base;
using Receita.Domain.Models;

namespace Receita.Infrastructure.Repositories
{
    internal class UsuarioRepository : RepositoryBase<Usuario>
    {
        private readonly ReceitaContext _context;

        public UsuarioRepository(ReceitaContext context) : base(context)
        {
            _context = context;
        }
    }
}
