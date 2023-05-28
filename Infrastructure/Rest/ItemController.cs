using Bootcamp_store_backend.Application;
using Bootcamp_store_backend.Application.Dtos;
using Bootcamp_store_backend.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace Bootcamp_store_backend.Infrastructure.Rest
{
    [Route("stroe/[controller]")]
    [ApiController]
    public class ItemController : GenericController<ItemDTO>
    {
        private IItemService _itemService;

        public ItemController(IItemService service) : base(service)
        {
            _itemService= service;
        }

        [NonAction]
        public override ActionResult<IEnumerable<ItemDTO>> Get()
        {
            throw new NotImplementedException();
        }


        [HttpGet]
        [Produces("application/json")]
        public ActionResult<PagedResponse<ItemDTO>> Get([FromQuery] string? filter, [FromQuery] PaginationParameters paginationParameters)
        {
            try
            {
                PagedList<ItemDTO> page = _itemService.GetItemsByCriteriaPaged(filter, paginationParameters);
                var respose = new PagedResponse<ItemDTO>
                {
                    CurrentPage = page.CurrentPage,
                    TotalPages = page.TotalPages,
                    PageSize = page.PageSize,
                    TotalCount = page.TotalCount,
                    Data = page
                };
                return Ok(respose);
            }catch (MalfomedFilterException) {
                return BadRequest();
            }
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
