using AutoMapper;
using Bootcamp_store_backend.Application.Dtos;
using Bootcamp_store_backend.Domain.Entities;
using Bootcamp_store_backend.Domain.Persistence;

namespace Bootcamp_store_backend.Application.Services
{
    public class ItemService : GenericService<Item, ItemDTO>, IItemService
    {
        private IItemRepository _itemRepository;

        public ItemService(IItemRepository repository, IMapper mapper) : base(repository, mapper)
        {
            _itemRepository = repository;
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
    }
}
