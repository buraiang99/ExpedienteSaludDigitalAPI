using ExpedienteSaludDigitalAPI.Models;
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
    public class ProvinciaController : ControllerBase
    {
        public IConfiguration Configuration { get; set; }

        public ProvinciaController(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // GET: api/<ProvinciaController>
        [HttpGet]
        public List<ProvinciaModel> Get()
        {
            List<ProvinciaModel> listaProvincia = new List<ProvinciaModel>();

            if (ModelState.IsValid)
            {
                string connectionString = Configuration["ConnectionStrings:DB_Connection_Turrialba"];

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string sqlQuery = $"exec sp_getAllProvincia";

                    using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                    {
                        command.CommandType = CommandType.Text;
                        connection.Open();
                        SqlDataReader sqlDataReader = command.ExecuteReader();
                        while (sqlDataReader.Read())
                        {
                            ProvinciaModel provinciaModel = new ProvinciaModel();
                            provinciaModel.ID = Int32.Parse(sqlDataReader["ID"].ToString());
                            provinciaModel.Nombre = sqlDataReader["NOMBRE"].ToString();
                            listaProvincia.Add(provinciaModel);
                        }
                        connection.Close();
                    }
                }
            }

            return listaProvincia;
        }

        /*// GET api/<ProvinciaController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ProvinciaController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ProvinciaController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ProvinciaController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }*/
    }
}
