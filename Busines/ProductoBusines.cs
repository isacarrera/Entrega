using Data;
using Entity.DTOs;
using Entity.Model;

namespace Busines
{
    public class ProductoBusines
    {
        private readonly ProductoData _data;

        public ProductoBusines(ProductoData data)
        {
            _data = data;
        }

        public async Task<List<ProductoDTO>> GetAllAsync()
        {
            var list = await _data.GetAllAsync();
            return list.Select(p => new ProductoDTO
            {
                Id = p.Id,
                Nombre = p.Nombre,
                Descripcion = p.Descripcion,
                Active = p.Active
            }).ToList();
        }

        public async Task<ProductoDTO?> GetByIdAsync(int id)
        {
            var p = await _data.GetByIdAsync(id);
            if (p == null) return null;

            return new ProductoDTO
            {
                Id = p.Id,
                Nombre = p.Nombre,
                Descripcion = p.Descripcion,
                Active = p.Active
            };
        }

        public async Task CreateAsync(ProductoDTO dto)
        {
            var entity = new Producto
            {
                Id = dto.Id,
                Nombre = dto.Nombre,
                Descripcion = dto.Descripcion,
                Active = dto.Active
            };
            await _data.CreateAsync(entity);
        }

        public async Task UpdateAsync(ProductoDTO dto)
        {
            var entity = new Producto
            {
                Id = dto.Id,
                Nombre = dto.Nombre,
                Descripcion = dto.Descripcion,
                Active = dto.Active
            };
            await _data.UpdateAsync(entity);
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
