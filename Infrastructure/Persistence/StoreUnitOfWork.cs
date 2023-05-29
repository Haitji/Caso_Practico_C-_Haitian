using Bootcamp_store_backend.Domain.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Bootcamp_store_backend.Infrastructure.Persistence
{
    public class StoreUnitOfWork : UnitOfWork, IStoreUnitOfWork
    {
        public StoreUnitOfWork(StoreContext dbContext) : base(dbContext)
        {
        }
    }
}
