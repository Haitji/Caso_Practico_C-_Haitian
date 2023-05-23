using Bootcamp_store_backend.Domain.Entities;
using Bootcamp_store_backend.Domain.Persistence;

namespace Bootcamp_store_backend.Infrastructure.Persistence
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly StoreContext _storeContext;

        public CategoryRepository(StoreContext storeContext)
        {
            _storeContext = storeContext;
        }

        public List<Category> GetAll()
        {
            return _storeContext.Categories.ToList<Category>();
        }
    }
}
