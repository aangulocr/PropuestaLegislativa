using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PropuestasLegislativas.Datos
{
    public class Propuesta
    {
        public string TipoId { get; set; }

        public double Cedula { get; set; }

        public string Nombre { get; set; }

        
        public string Apellido { get; set; }

        public int Telefono { get; set; }
      
        public string Correo { get; set; }

        public string Provincia { get; set; }

        public string Canton { get; set; }
        
        public string Descripcion { get; set; }
    }
}