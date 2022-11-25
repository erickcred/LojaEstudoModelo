using Microsoft.EntityFrameworkCore;
using ECommerce.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECommerce.Data.Mappings
{
    public class EstoqueMap : IEntityTypeConfiguration<Estoque>
    {
        public void Configure(EntityTypeBuilder<Estoque> builder)
        {
            builder.ToTable("Estoque");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder.Property(x => x.ProdutoId)
                .HasColumnName("ProdutoId")
                .HasColumnType("INT");

            builder.Property(x => x.Quantidade)
                .HasColumnName("Quantidade")
                .HasColumnType("INT");

            builder.Property(x => x.DataAtualizacao)
                .HasColumnName("DataAtualizacao")
                .HasColumnType("DateTime")
                .HasDefaultValue(DateTime.Now);
        }
    }
}