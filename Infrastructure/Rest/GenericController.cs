using Bootcamp_store_backend.Application.Dtos;
using Bootcamp_store_backend.Application.Services;
using Bootcamp_store_backend.Domain.Persistence;
using Microsoft.AspNetCore.Mvc;

namespace Bootcamp_store_backend.Infrastructure.Rest
{
    public class GenericController<D>: ControllerBase
        where D : class
    {
        private IGenericService<D> _service;

        public GenericController(IGenericService<D> service) {
            _service=service;
        }
        [HttpGet]
        [Produces("application/json")]
        public ActionResult<IEnumerable<D>> Get()
        {
            var dto = _service.GetAll();
            return Ok(dto);
        }

        [HttpGet("{id}")]
        [Produces("application/json")]
        public ActionResult<D> Get(long id)
        {
            try
            {
                D dto = _service.Get(id);
                return Ok(dto);
            }
            catch (ElementNotFoundException)
            {
                return NotFound();
            }

        }

        [HttpPost]
        [Produces("application/json")]
        [Consumes("application/json")]
        public ActionResult<D> Insertar(D dto)
        {
            if (dto == null)
                return BadRequest();
            dto = _service.Insert(dto);
            return CreatedAtAction(nameof(Get), new { id = ((IDto)dto).Id }, dto);
        }

        [HttpPut]
        [Produces("application/json")]
        [Consumes("application/json")]
        public ActionResult<D> Update(D dto)
        {
            if (dto == null)
                return BadRequest();
            dto = _service.Update(dto);
            return Ok(dto);
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(long id)
        {
            try
            {
                _service.Delete(id);
                return NoContent();
            }
            catch (ElementNotFoundException)
            {
                return NotFound();
            }
        }
    }
}
