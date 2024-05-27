using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using COSTAS_DEMANDAS.Soluciones;
using COSTAS_DEMANDAS.Models;
using System.IO;
using Newtonsoft.Json;


namespace COSTAS_DEMANDAS.Controllers
{
    public class CostasController : Controller
    {

        RepositorioCosta _RepositorioCosta = new RepositorioCosta();

        public IActionResult Obtener(string obligacion)
        {
            var respuesta = _RepositorioCosta.Obtener(obligacion);

            return StatusCode(200, respuesta);
        }

        public IActionResult Guardar()
        {
            //metodo solo devuelve la vista
            return View();
        }

        [HttpPost]
        public IActionResult Guardar(CostaModel COSTA)
        {
            try
            {
                string jsonFilePath = Path.Combine(Directory.GetCurrentDirectory(), "datos.json");
                string json = System.IO.File.ReadAllText(jsonFilePath);

                // Deserializar el JSON en una lista de objetos CostaModel
                List<CostaModel> costas = JsonConvert.DeserializeObject<List<CostaModel>>(json);

                // Validar los modelos (opcional, dependiendo de los requisitos de validación)
                // Aquí puedes implementar la lógica de validación si es necesario

                // Guardar en la base de datos
                var respuesta = _RepositorioCosta.Guardar(costas);

                if (respuesta)
                    return Ok("Datos guardados correctamente.");
                else
                    return StatusCode(500, "Error al guardar los datos en la base de datos.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }

    }

}
