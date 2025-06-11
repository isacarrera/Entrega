using Entity.Context;
using Entity.Model;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class PedidoData
    {
        private readonly ApplicationDbContext _context;

        public PedidoData(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Pedido>> GetAllAsync()
        {
            return await _context.Pedidos
                .Where(p => p.Active)
                .Include(p => p.PedidoProductos)
                    .ThenInclude(pp => pp.Producto)
                .ToListAsync();
        }

        public async Task<Pedido?> GetByIdAsync(int id)
        {
            return await _context.Pedidos
                .Include(p => p.PedidoProductos)
                    .ThenInclude(pp => pp.Producto)
                .FirstOrDefaultAsync(p => p.PedidoId == id && p.Active);
        }

        public async Task CreateAsync(Pedido pedido)
        {
            _context.Pedidos.Add(pedido);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Pedido pedido)
        {
            _context.Pedidos.Update(pedido);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteLogicAsync(int id)
        {
            var pedido = await _context.Pedidos.FindAsync(id);
            if (pedido != null)
            {
                pedido.Active = false;
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeletePermanentAsync(int id)
        {
            var pedido = await _context.Pedidos.FindAsync(id);
            if (pedido != null)
            {
                _context.Pedidos.Remove(pedido);
                await _context.SaveChangesAsync();
            }
        }
    }
}
