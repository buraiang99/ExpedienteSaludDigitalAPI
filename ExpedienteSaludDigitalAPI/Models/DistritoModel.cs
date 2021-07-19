using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExpedienteSaludDigitalAPI.Models
{
    public class DistritoModel
    {
        public int ID { get; set; }
        public string Nombre { get; set; }
        public DistritoModel()
        {

        }
        public DistritoModel(int iD, string nombre)
        {
            ID = iD;
            Nombre = nombre;
        }
    }
}
