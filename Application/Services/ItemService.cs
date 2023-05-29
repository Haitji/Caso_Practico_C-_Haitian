using AutoMapper;
using Bootcamp_store_backend.Application.Dtos;
using Bootcamp_store_backend.Domain.Entities;
using Bootcamp_store_backend.Domain.Persistence;
using Bootcamp_store_backend.Domain.Services;

namespace Bootcamp_store_backend.Application.Services
{
    public class ItemService : GenericService<Item, ItemDTO>, IItemService
    {
        private IItemRepository _itemRepository;
        private IImageVerifier _imageVerifier;

        public ItemService(IItemRepository repository, IMapper mapper, IImageVerifier imageVerifier) : base(repository, mapper)
        {
            _itemRepository = repository;
            _imageVerifier = imageVerifier;
        }

        public List<ItemDTO> GetAllByCategoryId(long categoryId)
        {
            var items = _itemRepository.GetByCategoryId(categoryId);
            return items;
        }

        public PagedList<ItemDTO> GetItemsByCriteriaPaged(string? filter, PaginationParameters paginationParameters)
        {
            var items = _itemRepository.GetItemsByCriteriaPaged(filter, paginationParameters);
            return items;
        }

        public override ItemDTO Insert(ItemDTO dto)
        {
            if (!_imageVerifier.IsImage(dto.Image))
                throw new InvalidImageException();
            return base.Insert(dto);

        }

        public override ItemDTO Update(ItemDTO dto)
        {
            if (!_imageVerifier.IsImage(dto.Image))
                throw new InvalidImageException();
            return base.Update(dto);

        }
    }
}
