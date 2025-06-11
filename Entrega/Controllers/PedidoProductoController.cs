using Busines;
using Entity.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace Entrega.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PedidoProductoController : ControllerBase
    {
        private readonly PedidoProductoBusines _business;

        public PedidoProductoController(PedidoProductoBusines business)
        {
            _business = business;
        }

        [HttpGet]
        public async Task<ActionResult<List<PedidoProductoDTO>>> GetAll()
        {
            var result = await _business.GetAllAsync();
            return Ok(result);
        }

        [HttpGet("{pedidoId:int}/{productoId:int}")]
        public async Task<ActionResult<PedidoProductoDTO>> GetById(int pedidoId, int productoId)
        {
            var item = await _business.GetByIdAsync(pedidoId, productoId);
            if (item == null) return NotFound();
            return Ok(item);
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] PedidoProductoDTO dto)
        {
            await _business.CreateAsync(dto);
            return Ok();
        }

        [HttpPut]
        public async Task<ActionResult> Update([FromBody] PedidoProductoDTO dto)
        {
            await _business.UpdateAsync(dto);
            return Ok();
        }

        [HttpDelete("logic/{pedidoId:int}/{productoId:int}")]
        public async Task<ActionResult> DeleteLogic(int pedidoId, int productoId)
        {
            await _business.DeleteLogicAsync(pedidoId, productoId);
            return Ok();
        }

        [HttpDelete("permanent/{pedidoId:int}/{productoId:int}")]
        public async Task<ActionResult> DeletePermanent(int pedidoId, int productoId)
        {
            await _business.DeletePermanentAsync(pedidoId, productoId);
            return Ok();
        }
    }
}
