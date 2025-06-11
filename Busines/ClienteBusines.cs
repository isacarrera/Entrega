using Data;
using Entity.DTOs;
using Entity.Model;

namespace Busines
{
    public class ClienteBusines
    {
        private readonly ClienteData _data;

        public ClienteBusines(ClienteData data)
        {
            _data = data;
        }

        public async Task<List<ClienteDTO>> GetAllAsync()
        {
            var list = await _data.GetAllAsync();
            return list.Select(c => new ClienteDTO
            {
                Id = c.Id,
                Nombre = c.Nombre,
                Descripcion = c.Descripcion,
                Active = c.Active
            }).ToList();
        }

        public async Task<ClienteDTO?> GetByIdAsync(int id)
        {
            var c = await _data.GetByIdAsync(id);
            if (c == null) return null;

            return new ClienteDTO
            {
                Id = c.Id,
                Nombre = c.Nombre,
                Descripcion = c.Descripcion,
                Active = c.Active
            };
        }

        public async Task CreateAsync(ClienteDTO dto)
        {
            var cliente = new Cliente
            {
                Id = dto.Id,
                Nombre = dto.Nombre,
                Descripcion = dto.Descripcion,
                Active = dto.Active
            };
            await _data.CreateAsync(cliente);
        }

        public async Task UpdateAsync(ClienteDTO dto)
        {
            var cliente = new Cliente
            {
                Id = dto.Id,
                Nombre = dto.Nombre,
                Descripcion = dto.Descripcion,
                Active = dto.Active
            };
            await _data.UpdateAsync(cliente);
        }

        public async Task DeleteLogicAsync(int id)
        {
            await _data.DeleteLogicAsync(id);
        }

        public async Task DeletePermanentAsync(int id)
        {
            await _data.DeletePermanentAsync(id);
        }
    }
}
