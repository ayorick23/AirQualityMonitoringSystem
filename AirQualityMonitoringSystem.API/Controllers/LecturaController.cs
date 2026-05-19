using AirQualityMonitoringSystem.Application.DTOs.LecturaDTOs;
using AirQualityMonitoringSystem.Application.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace AirQualityMonitoringSystem.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class LecturaController : ControllerBase
    {
        private readonly LecturaService _lecturaService;

        public LecturaController(LecturaService lecturaService)
        {
            _lecturaService = lecturaService;
        }

        // POST: api/lectura
        [HttpPost]
        public async Task<IActionResult> RegistrarLectura(
            CreateLecturaDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                await _lecturaService.RegistrarLecturaAsync(dto);

                return Ok(new
                {
                    mensaje = "Lectura registrada correctamente."
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    error = ex.Message
                });
            }
        }

        // GET: api/lectura/filtro
        [HttpGet("filtro")]
        public async Task<IActionResult> FiltrarLecturas(
            [FromQuery] DateTime? fechaInicio,
            [FromQuery] DateTime? fechaFin,
            [FromQuery] string? contaminante)
        {
            var lecturas = await _lecturaService.GetFilteredAsync(
                fechaInicio,
                fechaFin,
                contaminante);

            return Ok(lecturas);
        }
    }
}