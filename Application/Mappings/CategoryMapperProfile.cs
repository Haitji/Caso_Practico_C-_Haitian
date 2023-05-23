using AutoMapper;
using Bootcamp_store_backend.Application.Dtos;
using Bootcamp_store_backend.Domain.Entities;

namespace Bootcamp_store_backend.Application.Mappings
{
    public class CategoryMapperProfile:Profile
    {
        public CategoryMapperProfile()
        {
            CreateMap<Category, CategoryDTO>();
            CreateMap<CategoryDTO, Category>();
        }
    }
}
