using Microsoft.EntityFrameworkCore;
using Receita.Domain.Infrastructure.Repositories.Base;
using Receita.Domain.Infrastructure.Repositories.Interfaces;
using Receita.Domain.Models;

namespace Receita.Domain.Infrastructure.Repositories
{
    public class UsuarioRepository : RepositoryBase<Usuario>, IUsuarioRepository
    {
        private readonly DbContext _context;

        public UsuarioRepository(DbContext context) : base(context)
        {
            _context = context;
        }
    }
}
