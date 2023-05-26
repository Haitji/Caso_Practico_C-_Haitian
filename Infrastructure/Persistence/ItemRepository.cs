using Bootcamp_store_backend.Application.Dtos;
using Bootcamp_store_backend.Domain.Entities;
using Bootcamp_store_backend.Domain.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Bootcamp_store_backend.Infrastructure.Persistence
{
    public class ItemRepository : GenericRepository<Item>, IItemRepository
    {
        private StoreContext _storeContext;

        public ItemRepository(StoreContext storeContext) : base(storeContext)
        {
            _storeContext = storeContext;
        }

        public List<ItemDTO> GetByCategoryId(long categoryId)
        {
            var items = _dbset.Where(i => i.CategoryId == categoryId)
                .Select(i => new ItemDTO
                { 
                    Id = i.Id,
                    Name = i.Name,
                    Description = i.Description,
                    Price = i.Price,
                    Image = i.Image,
                    CategoryId = categoryId,
                    CategoryName = i.Category.Name
                }).ToList();
            if(items == null)
            {
                return new List<ItemDTO>();
            }
            return items.ToList();
        }
        public override Item GetById(long id)
        {
            var item = _storeContext.Items.Include(i => i.Category).SingleOrDefault(i => i.Id == id);
            if (item == null)
            {
                throw new ElementNotFoundException();
            }
            return item;
        }

        public override Item Insert(Item entity)
        {
            _storeContext.Items.Add(entity);
            _storeContext.SaveChanges();
            _storeContext.Entry(entity).Reference(i => i.Category).Load();
            return entity;
        }

        public override Item Update(Item entity)
        {
            _storeContext.Items.Update(entity);
            _storeContext.SaveChanges();
            _storeContext.Entry(entity).Reference(i => i.Category).Load();
            return entity;
        }
    }
}
