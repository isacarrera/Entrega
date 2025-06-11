using Entity.Context;
using Entity.Model;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class ProductoData
    {
        private readonly ApplicationDbContext _context;

        public ProductoData(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Producto>> GetAllAsync()
        {
            return await _context.Productos.Where(p => p.Active).ToListAsync();
        }

        public async Task<Producto?> GetByIdAsync(int id)
        {
            return await _context.Productos.FirstOrDefaultAsync(p => p.Id == id && p.Active);
        }

        public async Task CreateAsync(Producto producto)
        {
            _context.Productos.Add(producto);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Producto producto)
        {
            _context.Productos.Update(producto);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteLogicAsync(int id)
        {
            var producto = await _context.Productos.FindAsync(id);
            if (producto != null)
            {
                producto.Active = false;
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeletePermanentAsync(int id)
        {
            var producto = await _context.Productos.FindAsync(id);
            if (producto != null)
            {
                _context.Productos.Remove(producto);
                await _context.SaveChangesAsync();
            }
        }
    }
}
