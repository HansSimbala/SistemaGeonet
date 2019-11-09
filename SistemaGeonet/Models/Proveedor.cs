using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace SistemaGeonet.Models
{
    public class Proveedor
    {
        [Key]
        public int idProveedor { get; set; }
        public string nombre { get; set; }
        public string contacto { get; set; }
        public string pais { get; set; }
        public string direccion { get; set; }
    }
}
