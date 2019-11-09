using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace SistemaGeonet.Models
{
    public class Inventario
    {
        [Key]
        public int IdInventario { get; set; }

        public int IdEquipo { get; set; }

        public string titulo { get; set; }

        public DateTime fecha { get; set; }

        public int cantidadReal { get; set; }

        public int cantidadVirtual { get; set; }

        public Equipo Equipo { get; set; }

    }
}
