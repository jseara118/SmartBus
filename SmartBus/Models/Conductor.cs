using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SmartBus.Models
{
    public class Conductor
    {
        [Key]
        public int ConductorId { get; set; }
        public string Nombre { get; set; }
        public string Licencia { get; set; }
    }
}