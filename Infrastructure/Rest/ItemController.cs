using Bootcamp_store_backend.Application.Dtos;
using Bootcamp_store_backend.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace Bootcamp_store_backend.Infrastructure.Rest
{
    [Route("stroe/[controller]")]
    [ApiController]
    public class ItemController : GenericController<ItemDTO>
    {
        public ItemController(IItemService service) : base(service)
        {
        }

        [NonAction]
        public override ActionResult<IEnumerable<ItemDTO>> Get()
        {
            throw new NotImplementedException();
        }

        [HttpGet("/store/categories/{categoryId}/items")]
        [Produces("application/json")]
        public ActionResult<IEnumerable<ItemDTO>> GetAllFromCategory(long categoryId)
        {
            var categoriesDto = ((IItemService)_service).GetAllByCategoryId(categoryId);
            return Ok(categoriesDto);
        }
    }
}
