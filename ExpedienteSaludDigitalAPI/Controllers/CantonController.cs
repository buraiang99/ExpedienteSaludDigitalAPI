using ExpedienteSaludDigitalAPI.Models;
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
    public class CantonController : ControllerBase
    {
        public IConfiguration Configuration { get; set; }

        public CantonController(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        [HttpGet]
        public List<CantonModel> Get()
        {
            List<CantonModel> cantonModelsList = new List<CantonModel>();

            if (ModelState.IsValid)
            {
                string connectionString = Configuration["ConnectionStrings:DB_Connection_Turrialba"];

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string sqlQuery = $"exec sp_getAllCanton";
                    using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                    {
                        command.CommandType = CommandType.Text;
                        connection.Open();
                        SqlDataReader sqlDataReader = command.ExecuteReader();
                        while (sqlDataReader.Read())
                        {
                            CantonModel cantonModel = new CantonModel();
                            cantonModel.ID = Int32.Parse(sqlDataReader["ID"].ToString());
                            cantonModel.Nombre = sqlDataReader["NOMBRE"].ToString();
                            cantonModelsList.Add(cantonModel);
                        }
                        connection.Close();
                    }
                }
            }

            return cantonModelsList;
        }

    }
}
