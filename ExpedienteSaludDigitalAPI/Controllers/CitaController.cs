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
    public class CitaController : ControllerBase
    {

        public IConfiguration Configuration { get; set; }

        public CitaController(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // GET: api/<CitaController>
        [HttpGet]
        public List<CitaModel> Get()
        {

            List<CitaModel> listaCitas = new List<CitaModel>();
            if (ModelState.IsValid)
            {
                string connectionString = Configuration["ConnectionStrings:DB_Connection_Turrialba"];

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string sqlQuery = $"exec sp_getAllCitas";
                    using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                    {
                        command.CommandType = CommandType.Text;
                        connection.Open();
                        SqlDataReader sqlDataReader = command.ExecuteReader();
                        while (sqlDataReader.Read())
                        {
                            CitaModel citas = new CitaModel();
                            citas.ID_Cita = Int32.Parse(sqlDataReader["ID"].ToString());
                            citas.CedulaPaciente = sqlDataReader["CEDULA_PACIENTE"].ToString();
                            citas.Fecha = sqlDataReader["FECHA"].ToString();
                            citas.Hora = sqlDataReader["HORA"].ToString();
                            citas.CentroSalud = Int32.Parse(sqlDataReader["ID_CENTRO_SALUD"].ToString());
                            citas.Especialidad = Int32.Parse(sqlDataReader["ESPECIALIDAD"].ToString());
                            citas.Diagnostico = sqlDataReader["DESCRIPCION_DETALLADA"].ToString();
                            citas.NombreDoctor = " ";
                            citas.ApellidosDoctor = " ";
                            listaCitas.Add(citas);
                        }
                        connection.Close();
                    }
                }

            }
            return listaCitas;
        }

        // GET api/<CitaController>/5
        [HttpGet("{cedula}")]
        public CitaModel Get(string cedula)
        {
            CitaModel citasModel = new CitaModel();
            if (ModelState.IsValid)
            {
                string connectionString = Configuration["ConnectionStrings:DB_Connection_Turrialba"];

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string sqlQuery = $"exec sp_buscarCitasCedula @param_CEDULA_PACIENTE = {cedula}";
                    using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                    {
                        command.CommandType = CommandType.Text;
                        connection.Open();
                        SqlDataReader sqlDataReader = command.ExecuteReader();
                        CitaModel citas = new CitaModel();
                        if (sqlDataReader.Read())
                        {
                            citas.ID_Cita = Int32.Parse(sqlDataReader["ID"].ToString());
                            citas.CedulaPaciente = sqlDataReader["CEDULA_PACIENTE"].ToString();
                            citas.Fecha = sqlDataReader["FECHA"].ToString();
                            //Console.WriteLine("----------------"+sqlDataReader["FECHA"].ToString());
                            citas.Hora = sqlDataReader["HORA"].ToString();
                            citas.CentroSalud = Int32.Parse(sqlDataReader["ID_CENTRO_SALUD"].ToString());
                            citas.Especialidad= Int32.Parse(sqlDataReader["ESPECIALIDAD"].ToString());
                            citas.Diagnostico = sqlDataReader["DESCRIPCION_DETALLADA"].ToString();
                            citas.NombreDoctor = sqlDataReader["NOMBRE_DOCTOR"].ToString();
                            citas.ApellidosDoctor = sqlDataReader["APELLIDOS_DOCTOR"].ToString();
                            citasModel = citas;
                        }
                        connection.Close();
                    }
                }

            }
            return citasModel;
        }
        [HttpGet("{cedula}")]
        public List<CitaModel> Get(string cedula)
        {
            List<CitaModel> listaCitas = new List<CitaModel>();
            if (ModelState.IsValid)
            {
                string connectionString = Configuration["ConnectionStrings:DB_Connection_Turrialba"];

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string sqlQuery = $"exec sp_bucarCitasCedula @param_CEDULA_PACIENTE = {cedula}";
                    using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                    {
                        command.CommandType = CommandType.Text;
                        connection.Open();
                        SqlDataReader sqlDataReader = command.ExecuteReader();
                        while (sqlDataReader.Read())
                        {
                            CitaModel citas = new CitaModel();
                            citas.ID_Cita = Int32.Parse(sqlDataReader["ID"].ToString());
                            citas.CedulaPaciente = sqlDataReader["CEDULA_PACIENTE"].ToString();
                            citas.Fecha = sqlDataReader["FECHA"].ToString();
                            //Console.WriteLine("----------------"+sqlDataReader["FECHA"].ToString());
                            citas.Hora = sqlDataReader["HORA"].ToString();
                            citas.CentroSalud = Int32.Parse(sqlDataReader["ID_CENTRO_SALUD"].ToString());
                            citas.Especialidad = Int32.Parse(sqlDataReader["ESPECIALIDAD"].ToString());
                            citas.Diagnostico = sqlDataReader["DESCRIPCION_DETALLADA"].ToString();
                            citas.NombreDoctor = sqlDataReader["NOMBRE_DOCTOR"].ToString();
                            citas.ApellidosDoctor = sqlDataReader["APELLIDOS_DOCTOR"].ToString();
                            listaCitas.Add(citas);
                        }
                        connection.Close();
                    }
                }

            }
            return listaCitas;
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
