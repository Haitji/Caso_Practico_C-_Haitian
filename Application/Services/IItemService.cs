using Bootcamp_store_backend.Application.Dtos;

namespace Bootcamp_store_backend.Application.Services
{
    public interface IItemService : IGenericService<ItemDTO>
    {
        List<ItemDTO> GetAllByCategoryId(long categoryId);
        PagedList<ItemDTO> GetItemsByCriteriaPaged(string? filter, PaginationParameters paginationParameters);
        List<ItemDTO> postNewItemsFromCategory(long categoryId, List<ItemDTO> items);
    }
}
