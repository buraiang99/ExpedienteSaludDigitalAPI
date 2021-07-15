﻿using ExpedienteSaludDigitalAPI.Models;
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
    public class PacienteController : Controller
    {
        public IConfiguration Configuration { get; }
        public PacienteController(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        [HttpGet("{cedula}")]
        public PacienteModel Get(String cedula)
        {
            PacienteModel temp = new PacienteModel();
            if (ModelState.IsValid)
            {
                string connectionString = Configuration["ConnectionStrings:DB_Connection_Turrialba"];

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string sqlQuery = $"exec sp_getPaciente @param_CEDULA = {cedula}";
                    using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                    {
                        command.CommandType = CommandType.Text;
                        connection.Open();
                        SqlDataReader sqlDataReader = command.ExecuteReader();
                        while (sqlDataReader.Read())
                        {
                            temp.Cedula = sqlDataReader["CEDULA"].ToString();
                            temp.Nombre = sqlDataReader["NOMBRE"].ToString();
                            temp.Edad = Int32.Parse(sqlDataReader["EDAD"].ToString());
                            temp.TipoSangre = sqlDataReader["TIPO_SANGRE"].ToString();
                            temp.EstadoCivil = sqlDataReader["ESTADO_CIVIL"].ToString();
                            temp.Domicilio = sqlDataReader["DOMICILIO"].ToString();
                        }
                    }
                }

            }
            return temp;
        }

        [HttpPost]
        public void Post([FromBody] string cedula, [FromBody] string estadoCivil)
        {
            if (ModelState.IsValid)
            {
                string connectionString = Configuration["ConnectionStrings:DB_Connection_Turrialba"];

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string sqlQuery = $"exec sp_updatePacienteEstadoCivil @param_CEDULA = {cedula}'," +
                    $"@param_ESTADO_CIVIL = '{estadoCivil}', ";
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
