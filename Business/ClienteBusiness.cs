using System.Data;
using Entity.Model;



namespace Business
{
    public class ClienteBusiness
    {
        private readonly ClienteData _data;

        public ClienteBusiness(ClienteData data)
        {
            _data = data;
        }

        public async Task<List<Cliente>> GetAllAsync() => await _data.GetAllAsync();

        public async Task<Cliente?> GetByIdAsync(int id) => await _data.GetByIdAsync(id);

        public async Task CreateAsync(Cliente cliente)
        {
            // Aquí podés hacer validaciones si querés
            await _data.CreateAsync(cliente);
        }

        public async Task UpdateAsync(Cliente cliente)
        {
            // Validaciones de negocio si aplica
            await _data.UpdateAsync(cliente);
        }

        public async Task DeleteAsync(int id)
        {
            await _data.DeleteAsync(id);
        }
    }
}
