using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace SistemaGeonet.Data.Migrations
{
    public partial class mgeonet : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ApellidoMaterno",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ApellidoPaterno",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "Documento",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<int>(
                name: "IdDireccion",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IdTipoDocumento",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Nombres",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Telefono",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Carrito",
                columns: table => new
                {
                    IdCarrito = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IdUsuario = table.Column<string>(nullable: true),
                    estado = table.Column<string>(nullable: true),
                    nombres = table.Column<string>(nullable: true),
                    subTotal = table.Column<decimal>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carrito", x => x.IdCarrito);
                });

            migrationBuilder.CreateTable(
                name: "CarritoOrden",
                columns: table => new
                {
                    IdCarritoOrden = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IdUsuario = table.Column<string>(nullable: true),
                    estado = table.Column<string>(nullable: true),
                    precioTotal = table.Column<decimal>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarritoOrden", x => x.IdCarritoOrden);
                });

            migrationBuilder.CreateTable(
                name: "Categoria",
                columns: table => new
                {
                    IdCategoria = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    descripcion = table.Column<string>(nullable: true),
                    nombre = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categoria", x => x.IdCategoria);
                });

            migrationBuilder.CreateTable(
                name: "MetodoPago",
                columns: table => new
                {
                    IdMetodoPago = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    descripcion = table.Column<string>(nullable: true),
                    metodoPago = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MetodoPago", x => x.IdMetodoPago);
                });

            migrationBuilder.CreateTable(
                name: "Proveedor",
                columns: table => new
                {
                    idProveedor = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    contacto = table.Column<string>(nullable: true),
                    direccion = table.Column<string>(nullable: true),
                    nombre = table.Column<string>(nullable: true),
                    pais = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Proveedor", x => x.idProveedor);
                });

            migrationBuilder.CreateTable(
                name: "Tarjeta",
                columns: table => new
                {
                    IdTarjeta = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FechaVencimiento = table.Column<string>(nullable: true),
                    cvv = table.Column<int>(nullable: false),
                    numeroTarjeta = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tarjeta", x => x.IdTarjeta);
                });

            migrationBuilder.CreateTable(
                name: "Voucher",
                columns: table => new
                {
                    IdVoucher = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    foto = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Voucher", x => x.IdVoucher);
                });

            migrationBuilder.CreateTable(
                name: "Equipo",
                columns: table => new
                {
                    idEquipo = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    calificacion = table.Column<int>(nullable: true),
                    descripcion = table.Column<string>(nullable: true),
                    idCategoria = table.Column<int>(nullable: false),
                    imagen_catalogo = table.Column<string>(nullable: true),
                    imagen_detalle1 = table.Column<string>(nullable: true),
                    imagen_detalle2 = table.Column<string>(nullable: true),
                    imagen_detalle3 = table.Column<string>(nullable: true),
                    marca = table.Column<string>(nullable: true),
                    modelo = table.Column<string>(nullable: true),
                    nombre = table.Column<string>(nullable: true),
                    numero_serie = table.Column<string>(nullable: true),
                    precio = table.Column<decimal>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Equipo", x => x.idEquipo);
                    table.ForeignKey(
                        name: "FK_Equipo_Categoria_idCategoria",
                        column: x => x.idCategoria,
                        principalTable: "Categoria",
                        principalColumn: "IdCategoria",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrdenPedido",
                columns: table => new
                {
                    IdOrdenPedido = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IdCarritoOrden = table.Column<int>(nullable: false),
                    IdMetodoPago = table.Column<int>(nullable: false),
                    IdPago = table.Column<int>(nullable: false),
                    direccion = table.Column<string>(nullable: true),
                    email = table.Column<string>(nullable: true),
                    fechapedido = table.Column<DateTime>(nullable: false),
                    telefono = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrdenPedido", x => x.IdOrdenPedido);
                    table.ForeignKey(
                        name: "FK_OrdenPedido_CarritoOrden_IdCarritoOrden",
                        column: x => x.IdCarritoOrden,
                        principalTable: "CarritoOrden",
                        principalColumn: "IdCarritoOrden",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrdenPedido_MetodoPago_IdMetodoPago",
                        column: x => x.IdMetodoPago,
                        principalTable: "MetodoPago",
                        principalColumn: "IdMetodoPago",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DetalleCarrito",
                columns: table => new
                {
                    IdDetalleCarrito = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IdCarrito = table.Column<int>(nullable: false),
                    IdEquipo = table.Column<int>(nullable: false),
                    cantidad = table.Column<int>(nullable: false),
                    hasOrden = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetalleCarrito", x => x.IdDetalleCarrito);
                    table.ForeignKey(
                        name: "FK_DetalleCarrito_Equipo_IdEquipo",
                        column: x => x.IdEquipo,
                        principalTable: "Equipo",
                        principalColumn: "idEquipo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Inventario",
                columns: table => new
                {
                    IdInventario = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IdEquipo = table.Column<int>(nullable: false),
                    cantidadReal = table.Column<int>(nullable: false),
                    cantidadVirtual = table.Column<int>(nullable: false),
                    fecha = table.Column<DateTime>(nullable: true),
                    titulo = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inventario", x => x.IdInventario);
                    table.ForeignKey(
                        name: "FK_Inventario_Equipo_IdEquipo",
                        column: x => x.IdEquipo,
                        principalTable: "Equipo",
                        principalColumn: "idEquipo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Resena",
                columns: table => new
                {
                    idResena = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    comentario = table.Column<string>(nullable: true),
                    idEquipo = table.Column<int>(nullable: false),
                    idUsuario = table.Column<int>(nullable: false),
                    puntuacion = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Resena", x => x.idResena);
                    table.ForeignKey(
                        name: "FK_Resena_Equipo_idEquipo",
                        column: x => x.idEquipo,
                        principalTable: "Equipo",
                        principalColumn: "idEquipo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DetalleCarrito_IdEquipo",
                table: "DetalleCarrito",
                column: "IdEquipo");

            migrationBuilder.CreateIndex(
                name: "IX_Equipo_idCategoria",
                table: "Equipo",
                column: "idCategoria");

            migrationBuilder.CreateIndex(
                name: "IX_Inventario_IdEquipo",
                table: "Inventario",
                column: "IdEquipo");

            migrationBuilder.CreateIndex(
                name: "IX_OrdenPedido_IdCarritoOrden",
                table: "OrdenPedido",
                column: "IdCarritoOrden");

            migrationBuilder.CreateIndex(
                name: "IX_OrdenPedido_IdMetodoPago",
                table: "OrdenPedido",
                column: "IdMetodoPago");

            migrationBuilder.CreateIndex(
                name: "IX_Resena_idEquipo",
                table: "Resena",
                column: "idEquipo");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Carrito");

            migrationBuilder.DropTable(
                name: "DetalleCarrito");

            migrationBuilder.DropTable(
                name: "Inventario");

            migrationBuilder.DropTable(
                name: "OrdenPedido");

            migrationBuilder.DropTable(
                name: "Proveedor");

            migrationBuilder.DropTable(
                name: "Resena");

            migrationBuilder.DropTable(
                name: "Tarjeta");

            migrationBuilder.DropTable(
                name: "Voucher");

            migrationBuilder.DropTable(
                name: "CarritoOrden");

            migrationBuilder.DropTable(
                name: "MetodoPago");

            migrationBuilder.DropTable(
                name: "Equipo");

            migrationBuilder.DropTable(
                name: "Categoria");

            migrationBuilder.DropColumn(
                name: "ApellidoMaterno",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "ApellidoPaterno",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Documento",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "IdDireccion",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "IdTipoDocumento",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Nombres",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Telefono",
                table: "AspNetUsers");
        }
    }
}
