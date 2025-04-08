using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SmartBus.Models
{
    public class Tarifa
    {
        [Key]
        public int TarifaId { get; set; }
        public decimal Precio { get; set; }
        public int RutaId { get; set; }
        public virtual Ruta Ruta
        {
            get; set;
        }
    }
}