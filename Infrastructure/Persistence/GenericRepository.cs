using Bootcamp_store_backend.Domain.Entities;
using Bootcamp_store_backend.Domain.Persistence;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Bootcamp_store_backend.Infrastructure.Persistence
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly DbContext _context;
        private readonly DbSet<T> _dbset;

        public GenericRepository(StoreContext storeContext)
        {
            _context = storeContext;
            _dbset = _context.Set<T>();
        }

        public void Delete(long id)
        {
            var entity = _dbset.Find(id);
            if (entity == null)
            {
                throw new ElementNotFoundException();
            }
            _dbset.Remove(entity);
            _context.SaveChanges();
        }

        public List<T> GetAll()
        {
            return _dbset.ToList<T>();
        }

        public T GetById(long id)
        {
            var entity = _dbset.Find(id);
            if(entity == null)
            {
                throw new ElementNotFoundException();
            }
            return entity;
        }

        public T Insert(T entity)
        {
            _dbset.Add(entity);
            _context.SaveChanges();
            return entity;
        }

        public T Update(T entity)
        {
            _dbset.Update(entity);
            _context.SaveChanges();
            return entity;
        }
    }
}
