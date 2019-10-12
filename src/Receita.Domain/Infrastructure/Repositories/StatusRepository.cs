using Microsoft.EntityFrameworkCore;
using Receita.Domain.Infrastructure.Repositories.Base;
using Receita.Domain.Infrastructure.Repositories.Interfaces;
using Receita.Domain.Models;

namespace Receita.Domain.Infrastructure.Repositories
{
    public class StatusRepository : RepositoryBase<Status>, IStatusRepository
    {
        private readonly DbContext _context;

        public StatusRepository(DbContext context) : base(context)
        {
            _context = context;
        }
    }
}
