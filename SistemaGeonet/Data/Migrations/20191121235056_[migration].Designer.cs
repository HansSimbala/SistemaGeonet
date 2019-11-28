﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using SistemaGeonet.Data;
using System;

namespace SistemaGeonet.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20191121235056_[migration]")]
    partial class migration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.3-rtm-10026")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("SistemaGeonet.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ApellidoMaterno");

                    b.Property<string>("ApellidoPaterno");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<long>("Documento");

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<int?>("IdDireccion");

                    b.Property<int>("IdTipoDocumento");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("Nombres");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<int>("Telefono");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("SistemaGeonet.Models.Carrito", b =>
                {
                    b.Property<int>("IdCarrito")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("IdUsuario");

                    b.Property<string>("estado");

                    b.Property<string>("nombres");

                    b.Property<decimal?>("subTotal");

                    b.HasKey("IdCarrito");

                    b.ToTable("Carrito");
                });

            modelBuilder.Entity("SistemaGeonet.Models.CarritoOrden", b =>
                {
                    b.Property<int>("IdCarritoOrden")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("IdUsuario");

                    b.Property<string>("estado");

                    b.Property<decimal?>("precioTotal");

                    b.HasKey("IdCarritoOrden");

                    b.ToTable("CarritoOrden");
                });

            modelBuilder.Entity("SistemaGeonet.Models.Categoria", b =>
                {
                    b.Property<int>("IdCategoria")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("descripcion");

                    b.Property<string>("nombre");

                    b.HasKey("IdCategoria");

                    b.ToTable("Categoria");
                });

            modelBuilder.Entity("SistemaGeonet.Models.DetalleCarrito", b =>
                {
                    b.Property<int>("IdDetalleCarrito")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("IdCarrito");

                    b.Property<int>("IdEquipo");

                    b.Property<int>("cantidad");

                    b.Property<int>("hasOrden");

                    b.HasKey("IdDetalleCarrito");

                    b.HasIndex("IdEquipo");

                    b.ToTable("DetalleCarrito");
                });

            modelBuilder.Entity("SistemaGeonet.Models.Equipo", b =>
                {
                    b.Property<int>("idEquipo")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("calificacion");

                    b.Property<string>("descripcion");

                    b.Property<int>("idCategoria");

                    b.Property<string>("imagen_catalogo");

                    b.Property<string>("imagen_detalle1");

                    b.Property<string>("imagen_detalle2");

                    b.Property<string>("imagen_detalle3");

                    b.Property<string>("marca");

                    b.Property<string>("modelo");

                    b.Property<string>("nombre");

                    b.Property<string>("numero_serie");

                    b.Property<decimal?>("precio");

                    b.HasKey("idEquipo");

                    b.HasIndex("idCategoria");

                    b.ToTable("Equipo");
                });

            modelBuilder.Entity("SistemaGeonet.Models.Inventario", b =>
                {
                    b.Property<int>("IdInventario")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("IdEquipo");

                    b.Property<int>("cantidadReal");

                    b.Property<int>("cantidadVirtual");

                    b.Property<DateTime?>("fecha");

                    b.Property<string>("titulo");

                    b.HasKey("IdInventario");

                    b.HasIndex("IdEquipo");

                    b.ToTable("Inventario");
                });

            modelBuilder.Entity("SistemaGeonet.Models.MetodoPago", b =>
                {
                    b.Property<int>("IdMetodoPago")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("descripcion");

                    b.Property<string>("metodoPago");

                    b.HasKey("IdMetodoPago");

                    b.ToTable("MetodoPago");
                });

            modelBuilder.Entity("SistemaGeonet.Models.OrdenPedido", b =>
                {
                    b.Property<int>("IdOrdenPedido")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("IdCarritoOrden");

                    b.Property<int>("IdMetodoPago");

                    b.Property<int>("IdPago");

                    b.Property<string>("direccion");

                    b.Property<string>("email");

                    b.Property<DateTime>("fechapedido");

                    b.Property<string>("telefono");

                    b.HasKey("IdOrdenPedido");

                    b.HasIndex("IdCarritoOrden");

                    b.HasIndex("IdMetodoPago");

                    b.ToTable("OrdenPedido");
                });

            modelBuilder.Entity("SistemaGeonet.Models.Proveedor", b =>
                {
                    b.Property<int>("idProveedor")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("contacto");

                    b.Property<string>("direccion");

                    b.Property<string>("nombre");

                    b.Property<string>("pais");

                    b.HasKey("idProveedor");

                    b.ToTable("Proveedor");
                });

            modelBuilder.Entity("SistemaGeonet.Models.Resena", b =>
                {
                    b.Property<int>("idResena")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("comentario");

                    b.Property<int>("idEquipo");

                    b.Property<string>("idUsuario");

                    b.Property<int>("puntuacion");

                    b.HasKey("idResena");

                    b.HasIndex("idEquipo");

                    b.ToTable("Resena");
                });

            modelBuilder.Entity("SistemaGeonet.Models.Tarjeta", b =>
                {
                    b.Property<int>("IdTarjeta")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("FechaVencimiento");

                    b.Property<int>("cvv");

                    b.Property<string>("numeroTarjeta");

                    b.HasKey("IdTarjeta");

                    b.ToTable("Tarjeta");
                });

            modelBuilder.Entity("SistemaGeonet.Models.Voucher", b =>
                {
                    b.Property<int>("IdVoucher")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("foto");

                    b.HasKey("IdVoucher");

                    b.ToTable("Voucher");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("SistemaGeonet.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("SistemaGeonet.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("SistemaGeonet.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("SistemaGeonet.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SistemaGeonet.Models.DetalleCarrito", b =>
                {
                    b.HasOne("SistemaGeonet.Models.Equipo", "equipo")
                        .WithMany("detalleCarritos")
                        .HasForeignKey("IdEquipo")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SistemaGeonet.Models.Equipo", b =>
                {
                    b.HasOne("SistemaGeonet.Models.Categoria", "categoria")
                        .WithMany("equipos")
                        .HasForeignKey("idCategoria")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SistemaGeonet.Models.Inventario", b =>
                {
                    b.HasOne("SistemaGeonet.Models.Equipo", "Equipo")
                        .WithMany("inventarios")
                        .HasForeignKey("IdEquipo")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SistemaGeonet.Models.OrdenPedido", b =>
                {
                    b.HasOne("SistemaGeonet.Models.CarritoOrden", "carritoOrden")
                        .WithMany("ordenPedidos")
                        .HasForeignKey("IdCarritoOrden")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("SistemaGeonet.Models.MetodoPago", "metodoPago")
                        .WithMany("ordenPedidos")
                        .HasForeignKey("IdMetodoPago")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SistemaGeonet.Models.Resena", b =>
                {
                    b.HasOne("SistemaGeonet.Models.Equipo", "equipo")
                        .WithMany("resenas")
                        .HasForeignKey("idEquipo")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
