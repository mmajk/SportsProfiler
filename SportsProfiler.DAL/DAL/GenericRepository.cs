using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace SportsProfiler.DAL.DAL
{
    public abstract class GenericRepository<T, C> : 
        IGenericRepository<T> where T : class where C : DbContext, new()
    {
        private C _entities = new C();
        public C Context {

            get { return _entities; }
            set { _entities = value; }
        }


        public IQueryable<T> GetAll()
        {
            return Context.Set<T>();
        }

        public virtual async Task<ICollection<T>> GetAllAsync()
        {
            return await _entities.Set<T>().ToListAsync();
        }

        public virtual T Get(int id)
        {
            return _entities.Set<T>().Find(id);
        }

        public virtual async Task<T> GetAsync(int id)
        {
            return await _entities.Set<T>().FindAsync(id);
        }

        public virtual T Add(T t)
        {
            _entities.Set<T>().Add(t);
            return t;
        }

        public virtual async Task<T> AddAsync(T t)
        {
            _entities.Set<T>().Add(t);
            await _entities.SaveChangesAsync();
            return t;
        }

        public virtual T Find(Expression<Func<T, bool>> match)
        {
            return _entities.Set<T>().SingleOrDefault(match);
        }

        public virtual async Task<T> FindAsync(Expression<Func<T, bool>> match)
        {
            return await _entities.Set<T>().SingleOrDefaultAsync(match);
        }

        public ICollection<T> FindAll(Expression<Func<T, bool>> match)
        {
            return _entities.Set<T>().Where(match).ToList();
        }

        public async Task<ICollection<T>> FindAllAsync(Expression<Func<T, bool>> match)
        {
            return await _entities.Set<T>().Where(match).ToListAsync();
        }

        public virtual void Delete(T entity)
        {
            _entities.Set<T>().Remove(entity);
        }

        public virtual async Task<int> DeleteAsync(T entity)
        {
            _entities.Set<T>().Remove(entity);
            return await _entities.SaveChangesAsync();
        }

        public virtual T Update(T t, object key)
        {
            if (t == null)
                return null;
            T exist = _entities.Set<T>().Find(key);
            if (exist != null)
            {
                _entities.Entry(exist).CurrentValues.SetValues(t);
            }

            return exist;
        }

        public virtual async Task<T> UpdateAsync(T t, object key)
        {
            if (t == null)
                return null;
            T exist = await _entities.Set<T>().FindAsync(key);
            if (exist != null)
            {
                _entities.Entry(exist).CurrentValues.SetValues(t);
                await _entities.SaveChangesAsync();
            }

            return exist;
        }

        public int Count()
        {
            return _entities.Set<T>().Count();
        }

        public async Task<int> CountAsync()
        {
            return await _entities.Set<T>().CountAsync();
        }

        public virtual void Save()
        {
        }

        public virtual async Task<int> SaveAsync()
        {
            return await _entities.SaveChangesAsync();
        }

        public virtual IQueryable<T> FindBy(Expression<Func<T, bool>> predicate)
        {
            IQueryable<T> query = _entities.Set<T>().Where(predicate);
            return query;
        }

        public virtual async Task<ICollection<T>> FindByAsync(Expression<Func<T, bool>> predicate)
        {
            return await _entities.Set<T>().Where(predicate).ToListAsync();
        }

        public IQueryable<T> GetAllIncluding(params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> queryable = GetAll();
            foreach (Expression<Func<T, object>> includeProperty in includeProperties)
            {
                queryable = queryable.Include<T, object>(includeProperty);
            }

            return queryable;
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _entities.Dispose();
                }

                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}