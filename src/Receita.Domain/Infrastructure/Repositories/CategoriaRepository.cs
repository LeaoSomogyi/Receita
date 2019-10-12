using Microsoft.EntityFrameworkCore;
using Receita.Domain.Infrastructure.Repositories.Base;
using Receita.Domain.Infrastructure.Repositories.Interfaces;
using Receita.Domain.Models;

namespace Receita.Domain.Infrastructure.Repositories
{
    public class CategoriaRepository : RepositoryBase<Categoria>, ICategoriaRepository
    {
        private readonly DbContext _context;

        public CategoriaRepository(DbContext context) : base(context)
        {
            _context = context;
        }
    }
}
