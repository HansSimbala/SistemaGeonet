using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SistemaGeonet.Models
{
    public class Resena
    {
        [Key]
        public int idResena { get; set; }

        public string comentario { get; set; }

        public int puntuacion { get; set; }

        public int idEquipo { get; set; }

        public int idUsuario { get; set; }

        public Equipo equipo { get; set; }
    }
}
