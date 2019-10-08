using Receita.Domain.Context;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace Receita.Domain.Repository
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T>, IDisposable where T : class
    {

        private ReceitaContext _Context;

        public RepositoryBase(ReceitaContext context)
        {
            _Context = context;
        }

        public void Adicionar(T entity)
        {
            _Context.Set<T>().Add(entity);
            Commit();
        }

        public void Atualizar(T entity)
        {
            _Context.Set<T>().Update(entity);
            Commit();
        }

        public void Commit()
        {
            _Context.SaveChanges();
        }

        public void Deletar(Func<T, bool> predicate)
        {
            _Context.Set<T>()
            .Where(predicate).ToList()
            .ForEach(del => _Context.Set<T>().Remove(del));

        }

        public void Dispose()
        {
            _Context.Dispose();
        }

        public T Find(params object[] key)
        {
            return _Context.Set<T>().Find(key);
        }

        public T First(Expression<Func<T, bool>> predicate)
        {
            return _Context.Set<T>()
                 .Where(predicate).FirstOrDefault();


        }

        public IQueryable<T> Get(Expression<Func<T, bool>> predicate)
        {
            return _Context.Set<T>().Where(predicate);
        }

        public IQueryable<T> GetAll()
        {
            return _Context.Set<T>();
        }
    }
}
