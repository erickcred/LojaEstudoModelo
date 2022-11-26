using Microsoft.EntityFrameworkCore;
using ECommerce.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECommerce.Data.Mappings
{
    public class ClienteMap : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.ToTable("Cliente");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder.Property(x => x.Nome)
                .HasColumnName("Nome")
                .HasColumnType("VARCHAR")
                .HasMaxLength(200);

            builder.Property(x => x.Email)
                .HasColumnName("Email")
                .HasColumnType("VARCHAR")
                .HasMaxLength(200);

            builder.Property(x => x.TipoUsuario)
                .HasColumnName("TipoUsuario")
                .HasColumnType("VARCHAR")
                .HasMaxLength(100);
            
            builder.Property(x => x.Senha)
                .HasColumnName("Senha")
                .HasColumnType("VARCHAR")
                .HasMaxLength(255);
        }
    }
}