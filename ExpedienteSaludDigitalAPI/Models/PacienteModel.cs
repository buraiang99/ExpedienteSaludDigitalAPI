using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExpedienteSaludDigitalAPI.Models
{
    public class PacienteModel
    {
        public String Cedula { get; set; }
        public String Nombre { get; set; }
        public int Edad { get; set; }
        public String TipoSangre { get; set; }
        public String EstadoCivil { get; set; }
        public String Domicilio { get; set; }
        public String Pass { get; set; }

    } // fin clase
} // fin namespace
