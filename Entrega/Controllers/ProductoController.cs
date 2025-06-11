using Busines;
using Entity.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace Entrega.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductoController : ControllerBase
    {
        private readonly ProductoBusines _business;

        public ProductoController(ProductoBusines business)
        {
            _business = business;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var productos = await _business.GetAllAsync();
            return Ok(productos); // List<ProductoDTO>
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var producto = await _business.GetByIdAsync(id);
            if (producto == null)
                return NotFound();
            return Ok(producto); // ProductoDTO
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ProductoDTO productoDto)
        {
            await _business.CreateAsync(productoDto);
            return CreatedAtAction(nameof(GetById), new { id = productoDto.Id }, productoDto); 
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] ProductoDTO productoDto)
        {
            if (id != productoDto.Id)
                return BadRequest("ID mismatch");

            await _business.UpdateAsync(productoDto);
            return NoContent();
        }

        [HttpDelete("logic/{id}")]
        public async Task<IActionResult> DeleteLogic(int id)
        {
            await _business.DeleteLogicAsync(id);
            return NoContent();
        }

        [HttpDelete("permanent/{id}")]
        public async Task<IActionResult> DeletePermanent(int id)
        {
            await _business.DeletePermanentAsync(id);
            return NoContent();
        }
    }
}
