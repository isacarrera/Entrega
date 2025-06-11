using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Model
{
    public class Pedido
    {
        public int PedidoId { get; set; }
        public DateTime FechaPedido { get; set; }
        public DateTime FechaEntrega { get; set; }
        public bool Active { get; set; } = true;

        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; }

        public List<PedidoProductos> PedidoProductos { get; set; } = new List<PedidoProductos>();
    }
}
