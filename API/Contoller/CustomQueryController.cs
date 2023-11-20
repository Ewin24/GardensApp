using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Text.Json;
using System.Threading.Tasks;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace API.Contoller
{
    [Route("[controller]")]
    public class CustomQueryController : Controller
    {
        private readonly ILogger<CustomQueryController> _logger;
        private readonly IUnitOfWork _unitOfWork;

        public CustomQueryController(ILogger<CustomQueryController> logger, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }

        [HttpPost]
        public IActionResult Post([FromBody] JsonDocument data)
        {
            try
            {
                string jsonstring = data.RootElement.ToString();
                Console.WriteLine(
        jsonstring
                );
                return Ok(new { Mensaje = "Operación exitosa" });

                // Ejemplo de uso
                // var consulta = contexto.ObtenerEntidadesPersonalizadas("Nombre", "igual", "Ejemplo");
                // var resultados = consulta.ToList();
                // Procesar los resultados según tus necesidades
            }
            catch (Exception ex)
            {
                return BadRequest(new { Mensaje = $"Error: {ex.Message}" });
            }
        }
    }
}