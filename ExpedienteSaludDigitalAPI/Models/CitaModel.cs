using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExpedienteSaludDigitalAPI.Models
{
    public class CitaModel
    {
        public int ID_Cita { get; set; }
        public string CedulaPaciente { get; set; }
        public int CentroSalud { get; set; }
        public int Especialidad { get; set; }
        public string Fecha { get; set; }
        public string Hora { get; set; }
        public string Diagnostico { get; set; }

        public CitaModel()
        {

        }// fin constructor

        public CitaModel(int iD_Cita, string cedulaPaciente, int centroSalud, int especialidad, string fecha, string hora, string diagnostico)
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
