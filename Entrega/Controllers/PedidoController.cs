using Busines;
using Entity.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace Entrega.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PedidoController : ControllerBase
    {
        private readonly PedidoBusines _business;

        public PedidoController(PedidoBusines business)
        {
            _business = business;
        }

        [HttpGet]
        public async Task<ActionResult<List<PedidoDTO>>> GetAll()
        {
            var result = await _business.GetAllAsync();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PedidoDTO>> GetById(int id)
        {
            var pedido = await _business.GetByIdAsync(id);
            if (pedido == null) return NotFound();
            return Ok(pedido);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] PedidoDTO pedidoDto)
        {
            await _business.CreateAsync(pedidoDto); 
            return CreatedAtAction(nameof(GetById), new { id = pedidoDto.PedidoId }, pedidoDto); 
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] PedidoDTO pedidoDto)
        {
            if (id != pedidoDto.PedidoId) return BadRequest("IDs no coinciden");
            await _business.UpdateAsync(pedidoDto);
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
