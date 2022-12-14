// <auto-generated />
using ECommerce.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ECommerce.Migrations
{
    [DbContext(typeof(ECommerceContext))]
    [Migration("20221115183414_InsertStatusProduct")]
    partial class InsertStatusProduct
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("ECommerce.Models.Produto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<sbyte>("Ativo")
                        .HasMaxLength(1)
                        .HasColumnType("TINYINT")
                        .HasColumnName("Ativo");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("Description");

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("VARCHAR(255)")
                        .HasColumnName("Image");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("VARCHAR(255)")
                        .HasColumnName("Name");

                    b.Property<double>("Price")
                        .HasPrecision(9, 2)
                        .HasColumnType("DOUBLE")
                        .HasColumnName("Price");

                    b.Property<int>("QuantityInStok")
                        .HasColumnType("INT")
                        .HasColumnName("QuantityInStok");

                    b.HasKey("Id");

                    b.ToTable("Produto", (string)null);
                });
#pragma warning restore 612, 618
        }
    }
}
