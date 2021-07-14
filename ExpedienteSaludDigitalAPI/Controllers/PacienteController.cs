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
        //metodo para guirse
        /*[HttpPost]
        public IActionResult Registrar(DoctorModel doctorModel)
        {
            if (ModelState.IsValid)
            {
                string conexionString = Configuration["ConnectionStrings:DB_Connection_Turrialba"];
                var connection = new SqlConnection(conexionString);

                string sqlQuery = $"exec sp_insertarDoctor @param_CEDULA = '{doctorModel.Cedula}', " +
                    $"@param_CODIGO_MEDICO = '{doctorModel.CodigoMedico}', " +
                    $"@param_PASS = '{doctorModel.Pass}', " +
                    $"@param_NOMBRE = '{doctorModel.Nombre}', @param_APELLIDOS = '{doctorModel.Apellidos}'";
                using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                {
                    command.CommandType = CommandType.Text;
                    connection.Open();
                    command.ExecuteReader();
                    connection.Close();
                };
            }
            return View("Index");

            [HttpGet]
            public object Get()
            {
                string conexionString = Configuration["ConnectionStrings:DB_Connection_Turrialba"];
                var connection = new SqlConnection(conexionString);
                string sqlQuery = $"exec sp_getAllPacientes";
                using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                {
                    command.CommandType = CommandType.Text;
                    connection.Open();
                    SqlDataReader productosReader = command.ExecuteReader();
                    while (productosReader.Read())
                    {
                        ProductoModel productoTemp = new ProductoModel();
                        productoTemp.Id = Int32.Parse(productosReader["id"].ToString());
                        productoTemp.Nombre = productosReader["nombre"].ToString();
                        productos.Add(productoTemp);
                    }
                    connection.Close();
                };
            }
        }*/
    }
}
