using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExpedienteSaludDigitalAPI.Models
{
    public class PacienteModel
    {
        public int Cedula { get; set; }
        public string Nombre { get; set; }
        public string Edad { get; set; }
        public string TipoSangre { get; set; }
        public string EstadoCivil { get; set; }
        public string Domicilio { get; set; }

    } // fin clase
} // fin namespace
