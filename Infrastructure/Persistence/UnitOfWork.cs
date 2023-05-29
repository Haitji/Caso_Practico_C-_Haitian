using Bootcamp_store_backend.Domain.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Bootcamp_store_backend.Infrastructure.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DbContext _dbContext;

        public UnitOfWork (DbContext dbContext)
        {
            _dbContext = dbContext;
        }
        IWork IUnitOfWork.Init()
        {
            return new Work(_dbContext.Database.BeginTransaction());
        }
    }
}
