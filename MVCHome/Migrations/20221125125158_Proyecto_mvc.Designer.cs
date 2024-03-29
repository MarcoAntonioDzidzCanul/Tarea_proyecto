﻿// <auto-generated />
using System;
using MVCHome.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace MVCHome.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20221125125158_Proyecto_mvc")]
    partial class Proyecto_mvc
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MVCHome.Models.Articulo", b =>
                {
                    b.Property<int>("PkArticulo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Descripcion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UrlImg")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PkArticulo");

                    b.ToTable("ArticuloDb");
                });

            modelBuilder.Entity("MVCHome.Models.Roles", b =>
                {
                    b.Property<int>("PkRol")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PkRol");

                    b.ToTable("RolDb");
                });

            modelBuilder.Entity("MVCHome.Models.Usuario", b =>
                {
                    b.Property<int>("PkUser")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("FkRol")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("User")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PkUser");

                    b.HasIndex("FkRol");

                    b.ToTable("UsuarioDb");
                });

            modelBuilder.Entity("MVCHome.Models.Usuario", b =>
                {
                    b.HasOne("MVCHome.Models.Roles", "Rol")
                        .WithMany()
                        .HasForeignKey("FkRol");

                    b.Navigation("Rol");
                });
#pragma warning restore 612, 618
        }
    }
}
