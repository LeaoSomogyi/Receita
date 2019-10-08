using Receita.Domain.Context;
using Receita.Domain.Model;

namespace Receita.Domain.Repository
{
    public class UsuarioRepository : RepositoryBase<UsuarioAdm>
    {
        private readonly ReceitaContext _Context;

        public UsuarioRepository(ReceitaContext Context) : base(Context)
        {
            _Context = Context;
        }
    }
}
