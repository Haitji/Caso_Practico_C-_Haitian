using Bootcamp_store_backend.Domain.Entities;
using Bootcamp_store_backend.Domain.Persistence;

namespace Bootcamp_store_backend.Infrastructure.Persistence
{
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(StoreContext storeContext) : base(storeContext)
        {
        }
    }
}
