using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SistemaGeonet.Models
{
    public class Tarjeta
    {
        [Key]
        public int IdTarjeta { get; set; }

        public int numeroTarjeta { get; set; }

        public int cvv { get; set; }

        public string FechaVencimiento { get; set; }
    }
}
