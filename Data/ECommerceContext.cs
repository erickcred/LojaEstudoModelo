using Microsoft.EntityFrameworkCore;
using ECommerce.Models;
using ECommerce.Data.Mappings;

namespace ECommerce.Data
{
    public class ECommerceContext : DbContext
    {
        public ECommerceContext(DbContextOptions<ECommerceContext> options) : base(options) {}

        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Estoque> Estoques { get; set; }
        public DbSet<Cliente> Clientes { get; set; }

        // protected override void OnConfiguring(DbContextOptionsBuilder options)
        // {
        //     var connectionString = "Data Source=localhost;Database=cft;Uid=root;Pwd=root";
        //     options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
        // }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProdutoMap());
            modelBuilder.ApplyConfiguration(new EstoqueMap());
            modelBuilder.ApplyConfiguration(new ClienteMap());
        }
    }
}