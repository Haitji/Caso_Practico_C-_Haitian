using Bootcamp_store_backend.Application.Dtos;

namespace Bootcamp_store_backend.Application.Services
{
    public interface IItemService : IGenericService<ItemDTO>
    {
        List<ItemDTO> GetAllByCategoryId(long categoryId);
    }
}
