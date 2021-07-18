using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ExpedienteSaludDigitalAPI.Models
{
    public class CitaModel
    {
        [Key]
        public int ID_Cita { get; set; }
        public string CedulaPaciente { get; set; }
        public string CentroSalud { get; set; }
        public string Especialidad { get; set; }
        public string Fecha { get; set; }
        public string Hora { get; set; }
        public string Diagnostico { get; set; }
        public string NombreDoctor { get; set; }
        public string ApellidosDoctor { get; set; }

        public CitaModel()
        {

        }// fin constructor

        public CitaModel(int iD_Cita, string cedulaPaciente, string centroSalud, string especialidad, string fecha, string hora, string diagnostico)
        {
            ID_Cita = iD_Cita;
            CedulaPaciente = cedulaPaciente;
            CentroSalud = centroSalud;
            Especialidad = especialidad;
            Fecha = fecha;
            Hora = hora;
            Diagnostico = diagnostico;
        }// fin constructor
    }
}
