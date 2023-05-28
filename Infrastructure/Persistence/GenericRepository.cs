using Bootcamp_store_backend.Domain.Entities;
using Bootcamp_store_backend.Domain.Persistence;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Reflection;

namespace Bootcamp_store_backend.Infrastructure.Persistence
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly DbContext _context;
        protected readonly DbSet<T> _dbset;

        public GenericRepository(StoreContext storeContext)
        {
            _context = storeContext;
            _dbset = _context.Set<T>();
        }

        public virtual void Delete(long id)
        {
            var entity = _dbset.Find(id);
            if (entity == null)
            {
                throw new ElementNotFoundException();
            }
            _dbset.Remove(entity);
            _context.SaveChanges();
        }

        public virtual List<T> GetAll()
        {
            return _dbset.ToList<T>();
        }

        public virtual T GetById(long id)
        {
            var entity = _dbset.Find(id);
            if(entity == null)
            {
                throw new ElementNotFoundException();
            }
            return entity;
        }

        public virtual T Insert(T entity)
        {
            _dbset.Add(entity);
            _context.SaveChanges();
            return entity;
        }

        public virtual T Update(T entity)
        {
            _dbset.Update(entity);
            _context.SaveChanges();
            return entity;
        }

        protected virtual IQueryable<T> ApplySortOrder(IQueryable<T> entities, string sortOrder)
        {
            var orderByParameters = sortOrder.Split(',');
            var orderByAttribute = Char.ToUpper(orderByParameters[0][0]) + orderByParameters[0][1..];
            var orderByDirection = orderByParameters.Length > 1 ? orderByParameters[1] : "asc";

            var propertyInfo = typeof(T).GetProperty(orderByAttribute, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);

            if(propertyInfo != null)
            {
                var parameter = Expression.Parameter(typeof(Item), "x");
                var property = Expression.Property(parameter, propertyInfo);

                if(propertyInfo.PropertyType.IsValueType)
                {
                    var orderByExpression = Expression.Lambda<Func<T, dynamic>>(Expression.Convert(property, typeof(object)), parameter);

                    entities = orderByDirection.Equals("asc", StringComparison.OrdinalIgnoreCase)
                        ? entities.OrderBy(orderByExpression) 
                        : entities.OrderByDescending(orderByExpression);
                }
                else
                {
                    var orderByExpression = Expression.Lambda<Func<T, object>>(property, parameter);

                    entities = orderByDirection.Equals("asc", StringComparison.OrdinalIgnoreCase)
                        ? entities.OrderBy(orderByExpression)
                        : entities.OrderByDescending(orderByExpression);
                }
            }
            return entities;
        }
    }
}
