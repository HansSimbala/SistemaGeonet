using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SistemaGeonet.Models
{
    public class CarritoOrden
    {
        [Key]
        public int IdCarritoOrden { get; set; }

        public string IdUsuario { get; set; }

        public decimal? precioTotal { get; set; }

        public string estado { get; set; }

        public ICollection<OrdenPedido> ordenPedidos { get; set; }

    }
}
