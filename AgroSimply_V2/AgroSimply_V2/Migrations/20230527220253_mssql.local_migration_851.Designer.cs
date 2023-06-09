﻿// <auto-generated />
using AgroSimply_V2.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AgroSimply_V2.Migrations
{
    [DbContext(typeof(AgroSimply_V2Context))]
    [Migration("20230527220253_mssql.local_migration_851")]
    partial class mssqllocal_migration_851
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("AgroSimply_V2.Produtor", b =>
                {
                    b.Property<int>("IdProdutor")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdProdutor"));

                    b.Property<string>("Atividade")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CNPJ")
                        .HasColumnType("int");

                    b.Property<int>("CPF")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdProdutor");

                    b.ToTable("Produtor");

                    b.HasData(
                        new
                        {
                            IdProdutor = 1,
                            Atividade = "Criador",
                            CNPJ = 0,
                            CPF = 0,
                            Email = "Jesus@ceu.wo",
                            Nome = "Jesus"
                        });
                });

            modelBuilder.Entity("AgroSimply_V2.Propriedade", b =>
                {
                    b.Property<int>("IdPropriedade")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdPropriedade"));

                    b.Property<string>("Cidade")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Cultura")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("Extensão")
                        .HasColumnType("real");

                    b.Property<string>("Localização")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdPropriedade");

                    b.ToTable("Propriedade");

                    b.HasData(
                        new
                        {
                            IdPropriedade = 1,
                            Cidade = "Mundo",
                            Cultura = "Arvore da Vida",
                            Extensão = 1E+19f,
                            Localização = "Paraiso",
                            Nome = "Jardim do Eden"
                        });
                });

            modelBuilder.Entity("AgroSimply_V2.Telefone", b =>
                {
                    b.Property<int>("IdTel")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdTel"));

                    b.Property<int>("Numero")
                        .HasColumnType("int");

                    b.Property<int>("ProdutorId")
                        .HasColumnType("int");

                    b.Property<string>("Tipo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdTel");

                    b.ToTable("Telefone");
                });

            modelBuilder.Entity("AgroSimply_V2.Usuario", b =>
                {
                    b.Property<string>("IdUsuario")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("CPF")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ProdutorId")
                        .HasColumnType("int");

                    b.Property<int>("Tipo")
                        .HasColumnType("int");

                    b.HasKey("IdUsuario");

                    b.ToTable("Usuario");
                });
#pragma warning restore 612, 618
        }
    }
}
