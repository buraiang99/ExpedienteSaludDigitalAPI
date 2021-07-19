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
    public class DistritoController : ControllerBase
    {
        public IConfiguration Configuration { get; set; }

        public DistritoController(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        [HttpGet]
        public List<DistritoModel> Get()
        {
            List<DistritoModel> distritoModelList = new List<DistritoModel>();

            if (ModelState.IsValid)
            {
                string connectionString = Configuration["ConnectionStrings:DB_Connection_Turrialba"];

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string sqlQuery = $"exec sp_getAllDistrito";
                    using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                    {
                        command.CommandType = CommandType.Text;
                        connection.Open();
                        SqlDataReader sqlDataReader = command.ExecuteReader();
                        while (sqlDataReader.Read())
                        {
                            DistritoModel distritoModel = new DistritoModel();
                            distritoModel.ID = Int32.Parse(sqlDataReader["ID"].ToString());
                            distritoModel.Nombre = sqlDataReader["NOMBRE"].ToString();
                            distritoModelList.Add(distritoModel);
                        }
                        
                        connection.Close();
                    }
                }
            }
            return distritoModelList;
        }
    }
}
