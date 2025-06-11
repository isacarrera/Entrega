using Data;
using Entity.DTOs;
using Entity.Model;

namespace Busines
{
    public class PedidoProductoBusines
    {
        private readonly PedidoProductoData _data;

        public PedidoProductoBusines(PedidoProductoData data)
        {
            _data = data;
        }

        public async Task<List<PedidoProductoDTO>> GetAllAsync()
        {
            var entities = await _data.GetAllAsync();
            return entities.Select(pp => new PedidoProductoDTO
            {
                PedidoId = pp.PedidoId,
                ProductoId = pp.ProductoId,
                Cantidad = pp.Cantidad,
              
            }).ToList();
        }

        public async Task<PedidoProductoDTO?> GetByIdAsync(int pedidoId, int productoId)
        {
            var pp = await _data.GetByIdAsync(pedidoId, productoId);
            if (pp == null) return null;

            return new PedidoProductoDTO
            {
                PedidoId = pp.PedidoId,
                ProductoId = pp.ProductoId,
                Cantidad = pp.Cantidad,
               
            };
        }

        public async Task CreateAsync(PedidoProductoDTO dto)
        {
            var entity = new PedidoProductos
            {
                PedidoId = dto.PedidoId,
                ProductoId = dto.ProductoId,
                Cantidad = dto.Cantidad,
                Active = true
            };
            await _data.CreateAsync(entity);
        }

        public async Task UpdateAsync(PedidoProductoDTO dto)
        {
            var entity = new PedidoProductos
            {
                PedidoId = dto.PedidoId,
                ProductoId = dto.ProductoId,
                Cantidad = dto.Cantidad,
                Active = true
            };
            await _data.UpdateAsync(entity);
        }

        public async Task DeleteLogicAsync(int pedidoId, int productoId)
        {
            await _data.DeleteLogicAsync(pedidoId, productoId);
        }

        public async Task DeletePermanentAsync(int pedidoId, int productoId)
        {
            await _data.DeletePermanentAsync(pedidoId, productoId);
        }
    }
}
