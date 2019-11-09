using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace SistemaGeonet.Models
{
    public class DetalleCarrito
    {
        [Key]
        public int IdDetalleCarrito { get; set; }

        public int IdCarrito { get; set; }

        public int IdEquipo { get; set; }

        public int cantidad { get; set; }

        public Equipo equipo { get; set; }

        public Carrito carrito { get; set; }
    }
}
