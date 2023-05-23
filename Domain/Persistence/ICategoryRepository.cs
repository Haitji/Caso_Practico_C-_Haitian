
using Bootcamp_store_backend.Domain.Entities;

namespace Bootcamp_store_backend.Domain.Persistence
{
    public interface ICategoryRepository
    {
        List<Category> GetAll();
    }
}