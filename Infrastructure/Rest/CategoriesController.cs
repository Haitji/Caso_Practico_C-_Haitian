using Bootcamp_store_backend.Application.Dtos;
using Bootcamp_store_backend.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace Bootcamp_store_backend.Infrastructure.Rest
{
    [Route("stroe/[controller]")]
    [ApiController]
    public class CategoriesController:ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            this._categoryService = categoryService;
        }

        [HttpGet]
        public ActionResult<CategoryDTO> GetCategories()
        {
            var categories = _categoryService.GetAllCategories();
            return Ok(categories);
        }
    }
}
