using AutoMapper;
using Bootcamp_store_backend.Application.Dtos;
using Bootcamp_store_backend.Domain.Entities;
using Bootcamp_store_backend.Domain.Persistence;
using Bootcamp_store_backend.Domain.Services;

namespace Bootcamp_store_backend.Application.Services
{
    public class CategoryService : GenericService<Category, CategoryDTO>, ICategoryService
    {
        private ICategoryRepository _categoryRepository;
        private IImageVerifier _imageVerifier;
        public CategoryService(ICategoryRepository repository, IMapper mapper,IImageVerifier imageVerifier) : base(repository, mapper)
        {
            _categoryRepository = repository;
            _imageVerifier = imageVerifier;
        }

        public override CategoryDTO Insert(CategoryDTO dto)
        {
            if(!_imageVerifier.IsImage(dto.Image))
                throw new InvalidImageException();
            return base.Insert(dto);

        }

        public override CategoryDTO Update(CategoryDTO dto)
        {
            if (!_imageVerifier.IsImage(dto.Image))
                throw new InvalidImageException();
            return base.Update(dto);

        }
    }
}
