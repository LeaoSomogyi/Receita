using Receita.Domain.Context;
using Receita.Domain.Model;

namespace Receita.Domain.Repository
{
    public class StatusRepository : RepositoryBase<Status>
    {
        private readonly ReceitaContext _Context;

        public StatusRepository(ReceitaContext Context) : base(Context)
        {
            _Context = Context;
        }
    }
}
