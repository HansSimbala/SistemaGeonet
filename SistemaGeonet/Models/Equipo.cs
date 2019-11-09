using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace SistemaGeonet.Models
{
    public class Equipo
    {
        [Key]
        public int idEquipo { get; set; }

        public int idCategoria { get; set; }

        public string nombre { get; set; }

        public string marca { get; set; }

        public string numero_serie { get; set; }

        public string descripcion { get; set; }

        public string foto { get; set; }

        public decimal? precio { get; set; }

        public string modelo { get; set; }

        public Categoria categoria { get; set; }

        public ICollection<Inventario> inventarios { get; set; }
        public ICollection<DetalleCarrito> detalleCarritos { get; set; }
    }
}
