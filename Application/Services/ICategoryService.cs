using Bootcamp_store_backend.Application.Dtos;

namespace Bootcamp_store_backend.Application.Services
{
    public interface ICategoryService
    {
        void DeleteCategory(long id);
        List<CategoryDTO> GetAllCategories();
        CategoryDTO GetCategory(long id);
        CategoryDTO InsertCategory(CategoryDTO categoryDTO);
        CategoryDTO UpdateCategory(CategoryDTO categoryDTO);
    }
}