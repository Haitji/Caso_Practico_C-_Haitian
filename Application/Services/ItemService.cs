using AutoMapper;
using Bootcamp_store_backend.Application.Dtos;
using Bootcamp_store_backend.Domain.Entities;
using Bootcamp_store_backend.Domain.Persistence;
using Bootcamp_store_backend.Domain.Services;
using Bootcamp_store_backend.Infrastructure.Persistence;

namespace Bootcamp_store_backend.Application.Services
{
    public class ItemService : GenericService<Item, ItemDTO>, IItemService
    {
        private readonly IItemRepository _itemRepository;
        private readonly IImageVerifier _imageVerifier;
        private readonly IStoreUnitOfWork _storeUnitOfWork;

        public ItemService(IItemRepository repository, IMapper mapper, IImageVerifier imageVerifier, IStoreUnitOfWork context) : base(repository, mapper)
        {
            _itemRepository = repository;
            _imageVerifier = imageVerifier;
            _storeUnitOfWork = context;
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

        public List<ItemDTO> postNewItemsFromCategory(long categoryId, List<ItemDTO> items)
        {
            List<ItemDTO> newItems = new List<ItemDTO>();
            using (IWork work = _storeUnitOfWork.Init())
            {
                foreach (var item in items)
                {
                    item.CategoryId = categoryId;
                    newItems.Add(Insert(item));
                }
                work.Complete();
                return newItems;
            }
            
        }

        public override ItemDTO Update(ItemDTO dto)
        {
            if (!_imageVerifier.IsImage(dto.Image))
                throw new InvalidImageException();
            return base.Update(dto);

        }
    }
}
