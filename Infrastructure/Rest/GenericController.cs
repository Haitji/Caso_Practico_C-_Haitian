using Bootcamp_store_backend.Application.Dtos;
using Bootcamp_store_backend.Application.Services;
using Bootcamp_store_backend.Domain.Persistence;
using Microsoft.AspNetCore.Mvc;

namespace Bootcamp_store_backend.Infrastructure.Rest
{
    public class GenericController<D>: ControllerBase
        where D : class
    {
        protected IGenericService<D> _service;

        public GenericController(IGenericService<D> service) {
            _service=service;
        }
        [HttpGet]
        [Produces("application/json")]
        public virtual ActionResult<IEnumerable<D>> Get()
        {
            var dto = _service.GetAll();
            return Ok(dto);
        }

        [HttpGet("{id}")]
        [Produces("application/json")]
        public virtual ActionResult<D> Get(long id)
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
        public virtual ActionResult<D> Insertar(D dto)
        {
            if (dto == null)
                return BadRequest();
            dto = _service.Insert(dto);
            return CreatedAtAction(nameof(Get), new { id = ((IDto)dto).Id }, dto);
        }

        [HttpPut]
        [Produces("application/json")]
        [Consumes("application/json")]
        public virtual ActionResult<D> Update(D dto)
        {
            if (dto == null)
                return BadRequest();
            dto = _service.Update(dto);
            return Ok(dto);
        }

        [HttpDelete("{id}")]
        public virtual ActionResult Delete(long id)
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
