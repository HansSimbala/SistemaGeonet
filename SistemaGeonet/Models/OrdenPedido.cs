using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace SistemaGeonet.Models
{
    public class OrdenPedido
    {
        [Key]
        public int IdOrdenPedido { get; set; }

        public int IdCarrito { get; set; }

        public DateTime fechapedido { get; set; }

        public string direccion { get; set; }

        public string telefono { get; set; }

        public string email { get; set; }

        public int IdMetodoPago { get; set; }

        public int IdPago { get; set; }

        public MetodoPago metodoPago { get; set; }

        public CarritoOrden carritoOrden { get; set; }
    }
}
