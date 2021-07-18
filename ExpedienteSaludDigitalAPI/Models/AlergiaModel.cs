using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ExpedienteSaludDigitalAPI.Models
{
    public class AlergiaModel
    {
        [Key]
        public int IDAlergia { get; set; }
        public string CedulaPaciente { get; set; }
        public string NombreAlergia { get; set; }
        public string Descripcion { get; set; }
        public string FechaDiagnostico { get; set; }
        public string Medicamentos { get; set; }

        public AlergiaModel()
        {

        }// fin constructor
    }
}
