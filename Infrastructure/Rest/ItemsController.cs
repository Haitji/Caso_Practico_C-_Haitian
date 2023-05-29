using Bootcamp_store_backend.Application;
using Bootcamp_store_backend.Application.Dtos;
using Bootcamp_store_backend.Application.Services;
using Bootcamp_store_backend.Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace Bootcamp_store_backend.Infrastructure.Rest
{
    [Route("store/[controller]")]
    [ApiController]
    public class ItemsController : GenericController<ItemDTO>
    {
        private IItemService _itemService;
        private readonly ILogger _logger;

        public ItemsController(IItemService service, ILogger logger) : base(service)
        {
            _itemService = service;
            _logger = logger;
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

        public override ActionResult<ItemDTO> Insert(ItemDTO dto)
        {
            try
            {
                return base.Insert(dto);
            }
            catch (InvalidImageException)
            {
                _logger.LogInformation("Invalid image inserting category with {dto.Name} name", dto.Name);
                return BadRequest();
            }
        }

        public override ActionResult<ItemDTO> Update(ItemDTO dto)
        {
            try
            {
                return base.Update(dto);
            }
            catch (InvalidImageException)
            {
                _logger.LogInformation("Invalid image inserting category with {dto.Id} name", dto.Id);
                return BadRequest();
            }
        }
    }
}
