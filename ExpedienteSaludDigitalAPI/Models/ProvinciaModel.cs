using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ExpedienteSaludDigitalAPI.Models
{
    public class ProvinciaModel
    {
        [Key]
        public int ID { get; set; }
        public string Nombre { get; set; }

        public ProvinciaModel(int iD, string nombre)
        {
            ID = iD;
            Nombre = nombre;
        }
        public ProvinciaModel()
        {

        }
    }
}
