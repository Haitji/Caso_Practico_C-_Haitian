using AutoMapper;
using Bootcamp_store_backend.Application.Dtos;
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

        public List<CategoryDTO> GetAllCategories()
        {
            var categories = _categoryRepository.GetAll();
            var categoriesDto= _mapper.Map<List<CategoryDTO>>(categories);
            return categoriesDto;
        }
    }
}
