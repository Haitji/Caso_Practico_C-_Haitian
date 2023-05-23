using AutoMapper;
using Bootcamp_store_backend.Application.Dtos;
using Bootcamp_store_backend.Domain.Entities;
using Bootcamp_store_backend.Domain.Persistence;

namespace Bootcamp_store_backend.Application.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public CategoryService(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public void DeleteCategory(long id)
        {
            _categoryRepository.Delete(id);
        }

        public List<CategoryDTO> GetAllCategories()
        {
            var categories = _categoryRepository.GetAll();
            var categoriesDto= _mapper.Map<List<CategoryDTO>>(categories);
            return categoriesDto;
        }

        public CategoryDTO GetCategory(long id)
        {
            var category = _categoryRepository.GetById(id);
            return _mapper.Map<CategoryDTO>(category);
        }

        public CategoryDTO InsertCategory(CategoryDTO categoryDTO)
        {
            Category category = _mapper.Map<Category>(categoryDTO);
            category = _categoryRepository.Insert(category);
            return _mapper.Map<CategoryDTO>(category);
        }

        public CategoryDTO UpdateCategory(CategoryDTO categoryDTO)
        {
            Category category = _mapper.Map<Category>(categoryDTO);
            category = _categoryRepository.Update(category);
            return _mapper.Map<CategoryDTO>(category);
        }
    }
}
