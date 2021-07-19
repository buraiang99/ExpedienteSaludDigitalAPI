using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExpedienteSaludDigitalAPI.Models
{
    public class DomicilioModel
    {
        public int IDProvincia { get; set; }
        public int IDCanton { get; set; }
        public int IDDistrito { get; set; }
        public string Detalles { get; set; }
        public DomicilioModel()
        {

        }
        public DomicilioModel(int iDProvincia, int iDCanton, int iDDistrito, string detalles)
        {
            IDProvincia = iDProvincia;
            IDCanton = iDCanton;
            IDDistrito = iDDistrito;
            Detalles = detalles;
        }
    }
}
