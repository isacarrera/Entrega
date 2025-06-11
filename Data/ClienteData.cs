using Entity.Context;
using Entity.Model;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class ClienteData
    {
        private readonly ApplicationDbContext _context;

        public ClienteData(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Cliente>> GetAllAsync()
        {
            return await _context.Clientes
                .Where(c => c.Active)
                .Include(c => c.Pedidos)
                .ToListAsync();
        }

        public async Task<Cliente?> GetByIdAsync(int id)
        {
            return await _context.Clientes
                .Include(c => c.Pedidos)
                .FirstOrDefaultAsync(c => c.Id == id && c.Active);
        }

        public async Task CreateAsync(Cliente cliente)
        {
            _context.Clientes.Add(cliente);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Cliente cliente)
        {
            _context.Clientes.Update(cliente);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteLogicAsync(int id)
        {
            var cliente = await _context.Clientes.FindAsync(id);
            if (cliente != null)
            {
                cliente.Active = false;
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeletePermanentAsync(int id)
        {
            var cliente = await _context.Clientes.FindAsync(id);
            if (cliente != null)
            {
                _context.Clientes.Remove(cliente);
                await _context.SaveChangesAsync();
            }
        }
    }
}
