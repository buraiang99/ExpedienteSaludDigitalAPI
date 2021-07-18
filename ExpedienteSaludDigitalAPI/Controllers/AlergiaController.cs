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
    public class AlergiaController : ControllerBase
    {

        public IConfiguration Configuration { get; set; }

        public AlergiaController(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // GET: api/<CitaController>
        //ESTO PUEDE QUE DE PROBLEMAS PORQUE SI CAMBIO EL SP HAY QUE CAMBIAR LA PAGINA WEB PORQUE
        //ESE MISMO SP LO USAMOS EN LA WEB DE MOMENTO NO ESTOY USANDO ESTE ENTONCES SE QUEDARA ASI
        [HttpGet]
        public List<AlergiaModel> Get()
        {

            List<AlergiaModel> listaAlergias = new List<AlergiaModel>();
            if (ModelState.IsValid)
            {
                string connectionString = Configuration["ConnectionStrings:DB_Connection_Turrialba"];

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string sqlQuery = $"exec sp_getAllAlergias";
                    using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                    {
                        command.CommandType = CommandType.Text;
                        connection.Open();
                        SqlDataReader sqlDataReader = command.ExecuteReader();
                        while (sqlDataReader.Read())
                        {
                            AlergiaModel alergias = new AlergiaModel();
                            alergias.IDAlergia = Int32.Parse(sqlDataReader["ID"].ToString());
                            alergias.CedulaPaciente = sqlDataReader["CEDULA_PACIENTE"].ToString();
                            alergias.NombreAlergia = sqlDataReader["NOMBRE_ALERGIA"].ToString();
                            alergias.Descripcion= sqlDataReader["DESCRIPCION"].ToString();
                            alergias.FechaDiagnostico = sqlDataReader["FECHA_DIAGNOSTICO"].ToString();
                            alergias.Medicamentos = sqlDataReader["MEDICAMENTOS"].ToString();
                            listaAlergias.Add(alergias);
                        }
                        connection.Close();
                    }
                }

            }
            return listaAlergias;
        }

        // GET api/<CitaController>/5
        [HttpGet("{cedula}")]
        public List<AlergiaModel> Get(string cedula)
        {
            List<AlergiaModel> listaAlergias = new List<AlergiaModel>();
            if (ModelState.IsValid)
            {
                string connectionString = Configuration["ConnectionStrings:DB_Connection_Turrialba"];

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string sqlQuery = $"exec sp_buscarAlergiasCedula @param_CEDULA_PACIENTE = {cedula}";
                    using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                    {
                        command.CommandType = CommandType.Text;
                        connection.Open();
                        SqlDataReader sqlDataReader = command.ExecuteReader();
                        while (sqlDataReader.Read())
                        {
                            AlergiaModel temp = new AlergiaModel();
                            temp.IDAlergia = Int32.Parse(sqlDataReader["ID"].ToString());
                            temp.CedulaPaciente = sqlDataReader["CEDULA_PACIENTE"].ToString();
                            temp.NombreAlergia = sqlDataReader["NOMBRE_ALERGIA"].ToString();
                            temp.Descripcion = sqlDataReader["DESCRIPCION"].ToString();
                            temp.FechaDiagnostico = sqlDataReader["FECHA_DIAGNOSTICO"].ToString();
                            temp.Medicamentos = sqlDataReader["MEDICAMENTOS"].ToString();
                            listaAlergias.Add(temp);
                        }
                        connection.Close();
                    }
                }

            }
            return listaAlergias;
        }
        // POST api/<CitaController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<CitaController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {

        }

        // DELETE api/<CitaController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
