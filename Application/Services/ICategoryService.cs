using Bootcamp_store_backend.Application.Dtos;

namespace Bootcamp_store_backend.Application.Services
{
    public interface ICategoryService
    {
        List<CategoryDTO> GetAllCategories();
    }
}