using Microsoft.EntityFrameworkCore;
using Receita.Domain.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Receita.Domain.Infrastructure.Repositories.Base
{
    internal abstract class RepositoryBase<T> : IRepositoryBase<T>, IDisposable where T : class
    {

        private ReceitaContext _context;

        public RepositoryBase(ReceitaContext context)
        {
            _context = context;
        }

        public async Task<int> AddAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> UpdateAsync(T entity)
        {
            _context.Set<T>().Update(entity);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> RemoveAsync(int id)
        {
            var entity = GetById(id);
            if (entity != null)
            {
                _context.Remove(entity);
                return await _context.SaveChangesAsync();
            }

            return 0;
        }

        public async Task<T> GetById(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task<IList<T>> GetAllAsync()
        {
            var item = await _context.Set<T>().ToListAsync();
            return item;
        }

        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}
