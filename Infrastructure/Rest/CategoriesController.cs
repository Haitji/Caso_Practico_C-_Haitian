using Bootcamp_store_backend.Application.Dtos;
using Bootcamp_store_backend.Application.Services;
using Bootcamp_store_backend.Domain.Persistence;
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
        [Produces("application/json")]
        public ActionResult<IEnumerable<CategoryDTO>> GetCategories()
        {
            var categories = _categoryService.GetAllCategories();
            return Ok(categories);
        }

        [HttpGet("{id}")]
        [Produces("application/json")]
        public ActionResult<CategoryDTO> GetCategory(long id)
        {
            try
            {
                CategoryDTO categoryDTO = _categoryService.GetCategory(id);
                return Ok(categoryDTO);
            }catch(ElementNotFoundException)
            {
                return NotFound();
            }
            
        }

        [HttpPost]
        [Produces("application/json")]
        [Consumes("application/json")]
        public ActionResult<CategoryDTO> InsertarCategory(CategoryDTO categoryDTO)
        {
            if (categoryDTO == null)
                return BadRequest();
            categoryDTO = _categoryService.InsertCategory(categoryDTO);
            return CreatedAtAction(nameof(GetCategories), new { id = categoryDTO.Id}, categoryDTO);
        }

        [HttpPut]
        [Produces("application/json")]
        [Consumes("application/json")]
        public ActionResult<CategoryDTO> UpdateCategory(CategoryDTO categoryDTO)
        {
            if (categoryDTO == null)
                return BadRequest();
            categoryDTO = _categoryService.UpdateCategory(categoryDTO);
            return Ok(categoryDTO);
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteCategory(long id)
        {
            try { 
                _categoryService.DeleteCategory(id);
                return NoContent();
            }catch(ElementNotFoundException)
            {
                return NotFound();
            }
        }
    }
}
