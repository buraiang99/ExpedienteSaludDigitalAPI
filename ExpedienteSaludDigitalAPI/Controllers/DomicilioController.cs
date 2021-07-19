using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace ExpedienteSaludDigitalAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DomicilioController : ControllerBase
    {
        public IConfiguration Configuration { get; set; }

        public DomicilioController(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        [HttpPost]
        public void Post([FromBody] int idProvincia, int idCanton, int idDistrito, string detalles)
        {
            if (ModelState.IsValid)
            {
                string connectionString = Configuration["ConnectionStrings:DB_Connection_Turrialba"];

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string sqlQuery = $"exec sp_insertarDomicilio " +
                        $"@param_ID_PROVINCIA = '{idProvincia}'" +
                        $"@param_ID_CANTON = '{idCanton}'" +
                        $"@param_ID_DISTRITO = '{idDistrito}'" +
                        $"@param_DETALLES = '{detalles}'";
                    using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                    {
                        command.CommandType = CommandType.Text;
                        connection.Open();
                        command.ExecuteReader();
                        connection.Close();
                    }
                }
            }
        }
    }
}
