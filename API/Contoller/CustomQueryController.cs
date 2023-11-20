using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text.Json;
using System.Threading.Tasks;
using Application.Repository;
using Domain.Entities;
using Domain.Interfaces;
using iText.Signatures;
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

        [HttpPost]
        public IActionResult Post([FromBody] JsonDocument data)
        {
            try
            {
                string jsonstring = data.RootElement.ToString();
                Console.WriteLine(jsonstring);

                var selectedEntity = data.RootElement.GetProperty("selectedEntity").GetString();

                IQueryable<object> consulta;

                switch (selectedEntity)
                {
                    // case "Cliente":
                    //     ObtenerEntidadesPersonalizadas<Client>("Nombre", "igual", "Ejemplo");
                    //     break;

                    // case "Producto":
                    //     consulta = ObtenerEntidadesPersonalizadas<Producto>("Nombre", "igual", "Ejemplo");
                    //     break;

                    // Agregar más casos según las entidades disponibles

                    default:
                        return BadRequest(new { Mensaje = "Entidad no reconocida" });
                }
                // Ejemplo de uso
                // var consulta = CustomQueryController.ObtenerEntidadesPersonalizadas("Nombre", "igual", "Ejemplo");
                // var resultados = consulta.ToList();
                // Procesar los resultados según tus necesidades
                return Ok(new { Mensaje = "Operación exitosa" });

            }
            catch (Exception ex)
            {
                return BadRequest(new { Mensaje = $"Error: {ex.Message}" });
                //preparar manejo de errores por medio de tarjetas en js
            }
        }
    }
}