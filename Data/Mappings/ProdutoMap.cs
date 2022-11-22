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

            builder.Property(x => x.Nome)
                .HasColumnName("Nome")
                .HasColumnType("VARCHAR")
                .HasMaxLength(255);

            builder.Property(x => x.Preco)
            .HasColumnName("Preco")
            .HasColumnType("DOUBLE")
            .HasPrecision(9,2);

            builder.Property(x => x.Estoque)
                .HasColumnName("Estoque")
                .HasColumnType("INT");

            builder.Property(x => x.Descricao)
                .HasColumnName("Descricao")
                .HasColumnType("TEXT");

            builder.Property(x => x.Imagem)
                .HasColumnName("Imagem")
                .HasColumnType("VARCHAR")
                .HasMaxLength(255);

            builder.Property(x => x.Ativo)
                .HasColumnName("Ativo")
                .HasColumnType("TINYINT")
                .HasMaxLength(1);
        }
    }
}