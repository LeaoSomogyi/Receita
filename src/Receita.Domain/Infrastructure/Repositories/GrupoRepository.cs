using Microsoft.EntityFrameworkCore;
using Receita.Domain.Infrastructure.Repositories.Base;
using Receita.Domain.Infrastructure.Repositories.Interfaces;
using Receita.Domain.Models;

namespace Receita.Domain.Infrastructure.Repositories
{
    public class GrupoRepository : RepositoryBase<Grupo>, IGrupoRepository
    {
        private readonly DbContext _context;

        public GrupoRepository(DbContext context) : base(context)
        {
            _context = context;
        }
    }
}
