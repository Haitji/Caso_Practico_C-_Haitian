using Bootcamp_store_backend.Application.Dtos;
using Bootcamp_store_backend.Application.Services;
using Bootcamp_store_backend.Domain.Persistence;
using Microsoft.AspNetCore.Mvc;

namespace Bootcamp_store_backend.Infrastructure.Rest
{
    [Route("store/[controller]")]
    [ApiController]
    public class CategoriesController:GenericController<CategoryDTO>
    {

        public CategoriesController(ICategoryService service) : base(service)
        {
        }
    }
}
