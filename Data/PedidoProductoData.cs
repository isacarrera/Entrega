using Entity.Context;
using Entity.Model;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class PedidoProductoData
    {
        private readonly ApplicationDbContext _context;

        public PedidoProductoData(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<PedidoProductos>> GetAllAsync()
        {
            return await _context.PedidoProductos
                .Include(pp => pp.Pedido)
                .Include(pp => pp.Producto)
                .ToListAsync();
        }

        public async Task<PedidoProductos?> GetByIdAsync(int pedidoId, int productoId)
        {
            return await _context.PedidoProductos
                .Include(pp => pp.Pedido)
                .Include(pp => pp.Producto)
                .FirstOrDefaultAsync(p => p.PedidoId == pedidoId && p.ProductoId == productoId);
        }

        public async Task CreateAsync(PedidoProductos pedidoProducto)
        {
            _context.PedidoProductos.Add(pedidoProducto);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(PedidoProductos pedidoProducto)
        {
            _context.PedidoProductos.Update(pedidoProducto);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteLogicAsync(int pedidoId, int productoId)
        {
            var entity = await GetByIdAsync(pedidoId, productoId);
            if (entity != null)
            {
                entity.Producto.Active = false; // o el campo que represente el estado
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeletePermanentAsync(int pedidoId, int productoId)
        {
            var entity = await GetByIdAsync(pedidoId, productoId);
            if (entity != null)
            {
                _context.PedidoProductos.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }
    }
}
