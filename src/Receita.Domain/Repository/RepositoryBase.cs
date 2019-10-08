using Receita.Domain.Context;
using Receita.Domain.Repository.Interfaces;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace Receita.Domain.Repository
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T>, IDisposable where T : class
    {

        private ReceitaContext _context;

        public RepositoryBase(ReceitaContext context)
        {
            _context = context;
        }

        public void Adicionar(T entity)
        {
            _context.Set<T>().Add(entity);
            Commit();
        }

        public void Atualizar(T entity)
        {
            _context.Set<T>().Update(entity);
            Commit();
        }

        public void Commit()
        {
            _context.SaveChanges();
        }

        public void Deletar(Func<T, bool> predicate)
        {
            _context.Set<T>()
            .Where(predicate).ToList()
            .ForEach(del => _context.Set<T>().Remove(del));
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public T Find(params object[] key)
        {
            return _context.Set<T>().Find(key);
        }

        public T First(Expression<Func<T, bool>> predicate)
        {
            return _context.Set<T>()
                 .Where(predicate).FirstOrDefault();

        }

        public IQueryable<T> Get(Expression<Func<T, bool>> predicate)
        {
            return _context.Set<T>().Where(predicate);
        }

        public IQueryable<T> GetAll()
        {
            return _context.Set<T>();
        }
    }
}
