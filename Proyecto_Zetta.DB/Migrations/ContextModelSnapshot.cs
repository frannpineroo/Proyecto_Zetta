﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Proyecto_Zetta.DB.Data;

#nullable disable

namespace Proyecto_Zetta.DB.Migrations
{
    [DbContext(typeof(Context))]
    partial class ContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Proyecto_Zetta.DB.Data.Entity.Cliente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Apellido")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<int>("Codigo")
                        .HasColumnType("int");

                    b.Property<string>("Descripcion")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Direccion")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<string>("Localidad")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<string>("Mail")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<long>("Telefono")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "Codigo" }, "Cliente_Cod")
                        .IsUnique();

                    b.ToTable("Clientes");
                });

            modelBuilder.Entity("Proyecto_Zetta.DB.Data.Entity.Forma_de_Pago", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("Id");

                    b.ToTable("Formas_De_Pago");
                });

            modelBuilder.Entity("Proyecto_Zetta.DB.Data.Entity.Instalador", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Actividad")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<bool>("Activo")
                        .HasColumnType("bit");

                    b.Property<string>("Apellido")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<string>("Descripcion")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("Dni")
                        .HasMaxLength(12)
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<long>("Telefono")
                        .HasMaxLength(15)
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "Apellido", "Nombre" }, "Instalador_Apellido_Nombre");

                    b.ToTable("Instaladores");
                });

            modelBuilder.Entity("Proyecto_Zetta.DB.Data.Entity.Mantenimiento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Descripcion")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Estado")
                        .IsRequired()
                        .HasMaxLength(12)
                        .HasColumnType("nvarchar(12)");

                    b.Property<DateTime?>("FechaVisita")
                        .HasColumnType("datetime2");

                    b.Property<int>("PresupuestoId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PresupuestoId");

                    b.ToTable("Mantenimientos");
                });

            modelBuilder.Entity("Proyecto_Zetta.DB.Data.Entity.Obra", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("AnexarServicio")
                        .HasMaxLength(45)
                        .HasColumnType("nvarchar(45)");

                    b.Property<string>("Descripcion")
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("Estado")
                        .IsRequired()
                        .HasMaxLength(12)
                        .HasColumnType("nvarchar(12)");

                    b.Property<DateTime>("FechaAlta")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("FechaBaja")
                        .HasColumnType("datetime2");

                    b.Property<int>("InstaladorId")
                        .HasColumnType("int");

                    b.Property<string>("Materiales")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("Tipo")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.HasKey("Id");

                    b.HasIndex("InstaladorId");

                    b.ToTable("Obras");
                });

            modelBuilder.Entity("Proyecto_Zetta.DB.Data.Entity.Presupuesto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ClienteId")
                        .HasColumnType("int");

                    b.Property<string>("Estado")
                        .IsRequired()
                        .HasMaxLength(12)
                        .HasColumnType("nvarchar(12)");

                    b.Property<int>("Forma_de_PagoId")
                        .HasColumnType("int");

                    b.Property<long>("Insumos")
                        .HasMaxLength(30)
                        .HasColumnType("bigint");

                    b.Property<long>("ManodeObra")
                        .HasMaxLength(30)
                        .HasColumnType("bigint");

                    b.Property<int>("ObraId")
                        .HasColumnType("int");

                    b.Property<long>("PrecioFinal")
                        .HasMaxLength(30)
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("ClienteId");

                    b.HasIndex("Forma_de_PagoId");

                    b.HasIndex("ObraId");

                    b.ToTable("Presupuestos");
                });

            modelBuilder.Entity("Proyecto_Zetta.DB.Data.Entity.Seguimiento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Descripcion")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Estado")
                        .IsRequired()
                        .HasMaxLength(12)
                        .HasColumnType("nvarchar(12)");

                    b.Property<int>("MantenimientoId")
                        .HasColumnType("int");

                    b.Property<bool>("Mantenimiento_SN")
                        .HasColumnType("bit");

                    b.Property<int>("ObraId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("MantenimientoId");

                    b.HasIndex("ObraId");

                    b.ToTable("Seguimientos");
                });

            modelBuilder.Entity("Proyecto_Zetta.DB.Data.Entity.Mantenimiento", b =>
                {
                    b.HasOne("Proyecto_Zetta.DB.Data.Entity.Presupuesto", "Presupuesto")
                        .WithMany()
                        .HasForeignKey("PresupuestoId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Presupuesto");
                });

            modelBuilder.Entity("Proyecto_Zetta.DB.Data.Entity.Obra", b =>
                {
                    b.HasOne("Proyecto_Zetta.DB.Data.Entity.Instalador", "Instalador")
                        .WithMany()
                        .HasForeignKey("InstaladorId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Instalador");
                });

            modelBuilder.Entity("Proyecto_Zetta.DB.Data.Entity.Presupuesto", b =>
                {
                    b.HasOne("Proyecto_Zetta.DB.Data.Entity.Cliente", "Cliente")
                        .WithMany()
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Proyecto_Zetta.DB.Data.Entity.Forma_de_Pago", "Forma_de_Pago")
                        .WithMany()
                        .HasForeignKey("Forma_de_PagoId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Proyecto_Zetta.DB.Data.Entity.Obra", "Obra")
                        .WithMany()
                        .HasForeignKey("ObraId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Cliente");

                    b.Navigation("Forma_de_Pago");

                    b.Navigation("Obra");
                });

            modelBuilder.Entity("Proyecto_Zetta.DB.Data.Entity.Seguimiento", b =>
                {
                    b.HasOne("Proyecto_Zetta.DB.Data.Entity.Mantenimiento", "Mantenimiento")
                        .WithMany()
                        .HasForeignKey("MantenimientoId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Proyecto_Zetta.DB.Data.Entity.Obra", "Obra")
                        .WithMany()
                        .HasForeignKey("ObraId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Mantenimiento");

                    b.Navigation("Obra");
                });
#pragma warning restore 612, 618
        }
    }
}
