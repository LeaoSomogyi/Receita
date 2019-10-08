using Receita.Domain.Context;
using Receita.Domain.Model;

namespace Receita.Domain.Repository
{
    public class PapelRepository : RepositoryBase<Papel>
    {
        private readonly ReceitaContext _Context;

        public PapelRepository(ReceitaContext Context) : base(Context)
        {
            _Context = Context;
        }
    }
}
