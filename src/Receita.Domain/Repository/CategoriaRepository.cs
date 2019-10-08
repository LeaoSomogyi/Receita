using Receita.Domain.Context;
using Receita.Domain.Model;

namespace Receita.Domain.Repository
{
    public class CategoriaRepository : RepositoryBase<Categoria>
    {
        private readonly ReceitaContext _Context;

        public CategoriaRepository(ReceitaContext Context) : base(Context)
        {
            _Context = Context;
        }
    }
}
