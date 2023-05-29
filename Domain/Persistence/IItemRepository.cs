using Bootcamp_store_backend.Application;
using Bootcamp_store_backend.Application.Dtos;
using Bootcamp_store_backend.Domain.Entities;

namespace Bootcamp_store_backend.Domain.Persistence
{
    public interface IItemRepository : IGenericRepository<Item>
    {
        List<ItemDTO> GetByCategoryId(long categoryId);
        PagedList<ItemDTO> GetItemsByCriteriaPaged(string? filter, PaginationParameters paginationParameters);
    }
}
