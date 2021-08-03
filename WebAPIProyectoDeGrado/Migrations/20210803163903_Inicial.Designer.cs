﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using WebAPIProyectoDeGrado;

namespace WebAPIProyectoDeGrado.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20210803163903_Inicial")]
    partial class Inicial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "6.0.0-preview.6.21352.1")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("WebAPIProyectoDeGrado.Entitys.Direccion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Barrio")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("character varying(25)");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("character varying(25)");

                    b.Property<int>("PuntoDeRecoleccionId")
                        .HasColumnType("integer");

                    b.Property<int?>("ResidenteId")
                        .HasColumnType("integer");

                    b.Property<int>("TiendaId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("PuntoDeRecoleccionId")
                        .IsUnique();

                    b.HasIndex("ResidenteId");

                    b.HasIndex("TiendaId")
                        .IsUnique();

                    b.ToTable("Direcciones");
                });

            modelBuilder.Entity("WebAPIProyectoDeGrado.Entitys.PuntoDeRecoleccion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<bool>("Estado")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("FechaCreacion")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Imagen")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<string>("TipoDeMaterial")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("character varying(20)");

                    b.HasKey("Id");

                    b.ToTable("PuntoDeRecolecciones");
                });

            modelBuilder.Entity("WebAPIProyectoDeGrado.Entitys.Reciclador", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Apellido")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("character varying(25)");

                    b.Property<string>("Documento")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("character varying(10)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("character varying(25)");

                    b.Property<string>("Telefono")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("character varying(10)");

                    b.Property<int?>("UsuarioId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("UsuarioId");

                    b.ToTable("Recicladores");
                });

            modelBuilder.Entity("WebAPIProyectoDeGrado.Entitys.Residente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Apellido")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("character varying(25)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("character varying(25)");

                    b.Property<string>("Telefono")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("character varying(10)");

                    b.Property<int?>("UsuarioId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("UsuarioId");

                    b.ToTable("Residentes");
                });

            modelBuilder.Entity("WebAPIProyectoDeGrado.Entitys.Tienda", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("character varying(25)");

                    b.Property<string>("Telefono")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("character varying(10)");

                    b.Property<int?>("UsuarioId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("UsuarioId");

                    b.ToTable("Tiendas");
                });

            modelBuilder.Entity("WebAPIProyectoDeGrado.Entitys.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("character varying(25)");

                    b.Property<bool>("Estado")
                        .HasColumnType("boolean");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(12)
                        .HasColumnType("character varying(12)");

                    b.HasKey("Id");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("WebAPIProyectoDeGrado.Entitys.Direccion", b =>
                {
                    b.HasOne("WebAPIProyectoDeGrado.Entitys.PuntoDeRecoleccion", null)
                        .WithOne("Direccion")
                        .HasForeignKey("WebAPIProyectoDeGrado.Entitys.Direccion", "PuntoDeRecoleccionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebAPIProyectoDeGrado.Entitys.Residente", null)
                        .WithMany("ListaDirecciones")
                        .HasForeignKey("ResidenteId");

                    b.HasOne("WebAPIProyectoDeGrado.Entitys.Tienda", null)
                        .WithOne("Direccion")
                        .HasForeignKey("WebAPIProyectoDeGrado.Entitys.Direccion", "TiendaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("WebAPIProyectoDeGrado.Entitys.Reciclador", b =>
                {
                    b.HasOne("WebAPIProyectoDeGrado.Entitys.Usuario", "Usuario")
                        .WithMany()
                        .HasForeignKey("UsuarioId");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("WebAPIProyectoDeGrado.Entitys.Residente", b =>
                {
                    b.HasOne("WebAPIProyectoDeGrado.Entitys.Usuario", "Usuario")
                        .WithMany()
                        .HasForeignKey("UsuarioId");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("WebAPIProyectoDeGrado.Entitys.Tienda", b =>
                {
                    b.HasOne("WebAPIProyectoDeGrado.Entitys.Usuario", "Usuario")
                        .WithMany()
                        .HasForeignKey("UsuarioId");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("WebAPIProyectoDeGrado.Entitys.PuntoDeRecoleccion", b =>
                {
                    b.Navigation("Direccion")
                        .IsRequired();
                });

            modelBuilder.Entity("WebAPIProyectoDeGrado.Entitys.Residente", b =>
                {
                    b.Navigation("ListaDirecciones");
                });

            modelBuilder.Entity("WebAPIProyectoDeGrado.Entitys.Tienda", b =>
                {
                    b.Navigation("Direccion");
                });
#pragma warning restore 612, 618
        }
    }
}
