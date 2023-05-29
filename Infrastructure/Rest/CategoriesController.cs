using Bootcamp_store_backend.Application.Dtos;
using Bootcamp_store_backend.Application.Services;
using Bootcamp_store_backend.Domain.Persistence;
using Bootcamp_store_backend.Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace Bootcamp_store_backend.Infrastructure.Rest
{
    [Route("store/[controller]")]
    [ApiController]
    public class CategoriesController:GenericController<CategoryDTO>
    {
        private readonly ILogger _logger;
        public CategoriesController(ICategoryService service, ILogger<CategoriesController> logger) : base(service)
        {
            _logger = logger;
        }

        public override ActionResult<CategoryDTO> Insert(CategoryDTO categoryDTO)
        {
            try
            {
                return base.Insert(categoryDTO);
            }catch (InvalidImageException)
            {
                _logger.LogInformation("Invalid image inserting category with {categoryDTO.Name} name", categoryDTO.Name);
                return BadRequest();
            }
        }

        public override ActionResult<CategoryDTO> Update(CategoryDTO categoryDTO)
        {
            try
            {
                return base.Update(categoryDTO);
            }
            catch (InvalidImageException)
            {
                _logger.LogInformation("Invalid image inserting category with {categoryDTO.Id} name", categoryDTO.Id);
                return BadRequest();
            }
        }
    }
}
