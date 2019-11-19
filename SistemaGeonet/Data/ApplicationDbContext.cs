using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SistemaGeonet.Models;

namespace SistemaGeonet.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }

        public DbSet<SistemaGeonet.Models.Carrito> Carrito { get; set; }

        public DbSet<SistemaGeonet.Models.Categoria> Categoria { get; set; }

        public DbSet<SistemaGeonet.Models.DetalleCarrito> DetalleCarrito { get; set; }

        public DbSet<SistemaGeonet.Models.Inventario> Inventario { get; set; }

        public DbSet<SistemaGeonet.Models.Equipo> Equipo { get; set; }

        public DbSet<SistemaGeonet.Models.OrdenPedido> OrdenPedido { get; set; }

        public DbSet<SistemaGeonet.Models.Proveedor> Proveedor { get; set; }

        public DbSet<SistemaGeonet.Models.Resena> Resena { get; set; }

        public DbSet<SistemaGeonet.Models.MetodoPago> MetodoPago { get; set; }

        public DbSet<SistemaGeonet.Models.Tarjeta> Tarjeta { get; set; }

        public DbSet<SistemaGeonet.Models.Voucher> Voucher { get; set; }
    }
}
