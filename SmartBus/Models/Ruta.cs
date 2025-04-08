using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SmartBus.Models
{
    public class Ruta
    {
        [Key]
        public int RutaId { get; set; }
        public string Origen { get; set; }
        public string Destino { get; set; }
    }
}