using AirQualityMonitoringSystem.Application.DTOs.SensorDTOs;
using AirQualityMonitoringSystem.Application.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace AirQualityMonitoringSystem.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class SensorController : ControllerBase
    {
        private readonly SensorService _sensorService;

        public SensorController(SensorService sensorService)
        {
            _sensorService = sensorService;
        }

        // GET: api/sensor
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var sensores = await _sensorService.GetAllAsync();

            return Ok(sensores);
        }

        // POST: api/sensor
        [HttpPost]
        public async Task<IActionResult> Create(CreateSensorDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _sensorService.CreateAsync(dto);

            return Ok(new
            {
                mensaje = "Sensor creado correctamente."
            });
        }
    }
}