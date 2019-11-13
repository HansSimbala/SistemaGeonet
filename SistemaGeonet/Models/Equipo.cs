using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        public decimal? precio { get; set; }

        public string modelo { get; set; }

        public string imagen_catalogo { get; set; }

        public string imagen_detalle1 { get; set; }

        public string imagen_detalle2 { get; set; }

        public string imagen_detalle3 { get; set; }

        public int? calificacion { get; set; }

        public Categoria categoria { get; set; }

        public ICollection<Inventario> inventarios { get; set; }
        public ICollection<DetalleCarrito> detalleCarritos { get; set; }
        public ICollection<Resena> resenas { get; set; }
    }
}
