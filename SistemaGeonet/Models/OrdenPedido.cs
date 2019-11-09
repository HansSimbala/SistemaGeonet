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

        public string numero_tarjeta { get; set; }

        public string password_tarjeta { get; set; }

        public string cvv { get; set; }

        public string email { get; set; }

        public Carrito carrito { get; set; }
    }
}
