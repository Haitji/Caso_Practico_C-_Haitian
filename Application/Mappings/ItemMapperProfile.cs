using AutoMapper;
using Bootcamp_store_backend.Application.Dtos;
using Bootcamp_store_backend.Domain.Entities;

namespace Bootcamp_store_backend.Application.Mappings
{
    public class ItemMapperProfile:Profile
    {
        public ItemMapperProfile() { 
            CreateMap<Item,ItemDTO>();
            CreateMap<ItemDTO, Item>();
        }
    }
}
