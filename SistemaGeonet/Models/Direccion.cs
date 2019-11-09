using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SistemaGeonet.Models
{
    public class Direccion
    {
        [Key]
        public int IdDireccion { get; set; }
        public string direccion { get; set; }
        public string IdUsuario { get; set; }
    }
}
