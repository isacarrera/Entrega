using Data;
using Entity.DTOs;
using Entity.Model;

namespace Busines
{
    public class PedidoBusines
    {
        private readonly PedidoData _data;

        public PedidoBusines(PedidoData data)
        {
            _data = data;
        }

        public async Task<List<PedidoDTO>> GetAllAsync()
        {
            var pedidos = await _data.GetAllAsync();

            return pedidos.Select(p => new PedidoDTO
            {
                PedidoId = p.PedidoId,
                FechaPedido = p.FechaPedido,
                FechaEntrega = p.FechaEntrega,
                Active = p.Active,
                ClienteId = p.ClienteId,
                
            }).ToList();
        }

        public async Task<PedidoDTO?> GetByIdAsync(int id)
        {
            var p = await _data.GetByIdAsync(id);
            if (p == null) return null;

            return new PedidoDTO
            {
                PedidoId = p.PedidoId,
                FechaPedido = p.FechaPedido,
                FechaEntrega = p.FechaEntrega,
                Active = p.Active,
                ClienteId = p.ClienteId,
                
               
            };
        }

        public async Task CreateAsync(PedidoDTO dto)
        {
            var pedido = new Pedido
            {
                FechaPedido = dto.FechaPedido,
                FechaEntrega = dto.FechaEntrega,
                Active = dto.Active,
                ClienteId = dto.ClienteId,
               
            };

            await _data.CreateAsync(pedido);
            dto.PedidoId = pedido.PedidoId;
        }

        public async Task UpdateAsync(PedidoDTO dto)
        {
            var pedido = new Pedido
            {
                PedidoId = dto.PedidoId,
                FechaPedido = dto.FechaPedido,
                FechaEntrega = dto.FechaEntrega,
                Active = dto.Active,
                ClienteId = dto.ClienteId,
              
            };

            await _data.UpdateAsync(pedido);
        }

        public async Task DeleteLogicAsync(int id) => await _data.DeleteLogicAsync(id);

        public async Task DeletePermanentAsync(int id) => await _data.DeletePermanentAsync(id);
    }
}
