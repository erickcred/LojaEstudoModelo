using Microsoft.EntityFrameworkCore;
using AspNetInicio.Models;
using AspNetInicio.Data.Mappings;

namespace AspNetInicio.Data
{
    public class AspNetInicioContext : DbContext
    {
        public AspNetInicioContext(DbContextOptions<AspNetInicioContext> options) : base(options) {}

        public DbSet<Produto> Produtos { get; set; }

        // protected override void OnConfiguring(DbContextOptionsBuilder options)
        // {
        //     var connectionString = "Data Source=localhost;Database=cft;Uid=root;Pwd=root";
        //     options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
        // }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProdutoMap());
        }
    }
}