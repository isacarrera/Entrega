using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Entity.Model
{
    public class Cliente
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public bool Active { get; set; } = true;

        public List<Pedido> Pedidos { get; set; } = new List<Pedido>();
    }
}
