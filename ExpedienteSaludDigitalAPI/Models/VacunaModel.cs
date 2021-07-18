using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ExpedienteSaludDigitalAPI.Models
{
    public class VacunaModel
    {
        [Key]
        public int IDVacuna { get; set; }
        public string CedulaPaciente { get; set; }
        public string NombreVacuna { get; set; }
        public string Descripcion { get; set; }
        public string FechaAplicacion { get; set; }
        public string FechaProxima { get; set; }

        public VacunaModel()
        {

        }// fin constructor
    }
}
