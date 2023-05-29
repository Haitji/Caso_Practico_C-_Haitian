using Bootcamp_store_backend.Application;
using Bootcamp_store_backend.Application.Dtos;
using Bootcamp_store_backend.Domain.Entities;
using Bootcamp_store_backend.Domain.Persistence;
using Bootcamp_store_backend.Infrastructure.Rest;
using Bootcamp_store_backend.Infrastructure.Specs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;

namespace Bootcamp_store_backend.Infrastructure.Persistence
{
    public class ItemRepository : GenericRepository<Item>, IItemRepository
    {
        private StoreContext _storeContext;
        private readonly ISpecificationParser<Item> _specificationParser;

        public ItemRepository(StoreContext storeContext, ISpecificationParser<Item> specificationParser) : base(storeContext)
        {
            _storeContext = storeContext;
            _specificationParser = specificationParser;
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
        
        
        
        public PagedList<ItemDTO> GetItemsByCriteriaPaged(string? filter, PaginationParameters paginationParameters)
        {
            var items = _storeContext.Items.AsQueryable();

            if (!string.IsNullOrEmpty(filter))
            {
                Specification<Item> specification = _specificationParser.ParseSpecification(filter);
                items = specification.ApplySpecification(items);
            }

            if(!string.IsNullOrEmpty(paginationParameters.Sort))
            {
                items = ApplySortOrder(items, paginationParameters.Sort);
            }

            var itemsDto = items.Select(i => new ItemDTO
            {
                Id = i.Id,
                Name = i.Name,
                Description = i.Description,
                Price = i.Price,
                Image = i.Image,
                CategoryId = i.CategoryId,
                CategoryName = i.Category.Name
            });

            return PagedList<ItemDTO>.ToPagedList(itemsDto, paginationParameters.PageNumber,paginationParameters.PageSize);
        }

    }
}
