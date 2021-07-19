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
    public class VacunaController : ControllerBase
    {

        public IConfiguration Configuration { get; set; }

        public VacunaController(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // GET: api/<CitaController>
        //ESTO PUEDE QUE DE PROBLEMAS PORQUE SI CAMBIO EL SP HAY QUE CAMBIAR LA PAGINA WEB PORQUE
        //ESE MISMO SP LO USAMOS EN LA WEB DE MOMENTO NO ESTOY USANDO ESTE ENTONCES SE QUEDARA ASI
        [HttpGet]
        public List<VacunaModel> Get()
        {

            List<VacunaModel> listaVacunas = new List<VacunaModel>();
            if (ModelState.IsValid)
            {
                string connectionString = Configuration["ConnectionStrings:DB_Connection_Turrialba"];

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string sqlQuery = $"exec sp_getAllVacunas";
                    using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                    {
                        command.CommandType = CommandType.Text;
                        connection.Open();
                        SqlDataReader sqlDataReader = command.ExecuteReader();
                        while (sqlDataReader.Read())
                        {
                            VacunaModel vacuna = new VacunaModel();
                            vacuna.IDVacuna = Int32.Parse(sqlDataReader["ID"].ToString());
                            vacuna.CedulaPaciente = sqlDataReader["CEDULA_PACIENTE"].ToString();
                            vacuna.NombreVacuna = sqlDataReader["NOMBRE_VACUNA"].ToString();
                            vacuna.Descripcion = sqlDataReader["DESCRIPCION"].ToString();
                            vacuna.FechaAplicacion = sqlDataReader["FECHA_APLICACION"].ToString();
                            vacuna.FechaProxima = sqlDataReader["FECHA_PROXIMA"].ToString();
                            listaVacunas.Add(vacuna);
                        }
                        connection.Close();
                    }
                }

            }
            return listaVacunas;
        }

        // GET api/<CitaController>/5
        [HttpGet("{cedula}")]
        public List<VacunaModel> Get(string cedula)
        {
            List<VacunaModel> listaVacunas = new List<VacunaModel>();
            if (ModelState.IsValid)
            {
                string connectionString = Configuration["ConnectionStrings:DB_Connection_Turrialba"];

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string sqlQuery = $"exec sp_buscarVacunasCedula @param_CEDULA_PACIENTE = {cedula}";
                    using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                    {
                        command.CommandType = CommandType.Text;
                        connection.Open();
                        SqlDataReader sqlDataReader = command.ExecuteReader();
                        while (sqlDataReader.Read())
                        {
                            VacunaModel vacuna = new VacunaModel();
                            vacuna.IDVacuna = Int32.Parse(sqlDataReader["ID"].ToString());
                            vacuna.CedulaPaciente = sqlDataReader["CEDULA_PACIENTE"].ToString();
                            vacuna.NombreVacuna = sqlDataReader["NOMBRE_VACUNA"].ToString();
                            vacuna.Descripcion = sqlDataReader["DESCRIPCION"].ToString();
                            vacuna.FechaAplicacion = sqlDataReader["FECHA_APLICACION"].ToString();
                            vacuna.FechaProxima = sqlDataReader["FECHA_PROXIMA"].ToString();
                            vacuna.CentroSalud = sqlDataReader["ID_CENTRO_SALUD"].ToString();
                            listaVacunas.Add(vacuna);
                        }
                        connection.Close();
                    }
                }

            }
            return listaVacunas;
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
