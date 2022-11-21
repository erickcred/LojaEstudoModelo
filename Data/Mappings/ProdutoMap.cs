using AspNetInicio.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AspNetInicio.Data.Mappings
{
    public class ProdutoMap : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.ToTable("Produto");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder.Property(x => x.Name)
                .HasColumnName("Name")
                .HasColumnType("VARCHAR")
                .HasMaxLength(255);

            builder.Property(x => x.Price)
            .HasColumnName("Price")
            .HasColumnType("DOUBLE")
            .HasPrecision(9,2);

            builder.Property(x => x.QuantityInStok)
                .HasColumnName("QuantityInStok")
                .HasColumnType("INT");

            builder.Property(x => x.Description)
                .HasColumnName("Description")
                .HasColumnType("TEXT");

            builder.Property(x => x.Image)
                .HasColumnName("Image")
                .HasColumnType("VARCHAR")
                .HasMaxLength(255);

            builder.Property(x => x.Ativo)
                .HasColumnName("Ativo")
                .HasColumnType("TINYINT")
                .HasMaxLength(1);
        }
    }
}