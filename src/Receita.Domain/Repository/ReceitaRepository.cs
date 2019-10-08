using Receita.Domain.Context;
using Models = Receita.Domain.Model;

namespace Receita.Domain.Repository
{
    public class ReceitaRepository : RepositoryBase<Models.Receita>
    {
        private ReceitaContext DbContext;

        public ReceitaRepository(ReceitaContext Context) : base(Context)
        {
            DbContext = Context;
        }
    }
}
