using AutoMapper;
using Bootcamp_store_backend.Application.Dtos;
using Bootcamp_store_backend.Domain.Entities;
using Bootcamp_store_backend.Domain.Persistence;

namespace Bootcamp_store_backend.Application.Services
{
    public class CategoryService : GenericService<Category, CategoryDTO>, ICategoryService
    {
        public CategoryService(ICategoryRepository repository, IMapper mapper) : base(repository, mapper)
        {
        }
    }
}
