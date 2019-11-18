﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace SistemaGeonet.Models
{
    public class Carrito
    {
        [Key]
        public int IdCarrito { get; set; }

        public string IdUsuario { get; set; }

        public string nombres { get; set; }

        public decimal? subTotal { get; set; }

        public string estado { get; set; }
    }

}