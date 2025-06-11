using Microsoft.EntityFrameworkCore;
using Entity.Model;

namespace Entity.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Producto> Productos { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<PedidoProductos> PedidoProductos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PedidoProductos>()
                .HasKey(pp => new { pp.PedidoId, pp.ProductoId });

            modelBuilder.Entity<PedidoProductos>()
                .HasOne(pp => pp.Pedido)
                .WithMany(p => p.PedidoProductos)
                .HasForeignKey(pp => pp.PedidoId);

            modelBuilder.Entity<PedidoProductos>()
                .HasOne(pp => pp.Producto)
                .WithMany(p => p.PedidoProductos)
                .HasForeignKey(pp => pp.ProductoId);

            base.OnModelCreating(modelBuilder);
        }
    }
}
