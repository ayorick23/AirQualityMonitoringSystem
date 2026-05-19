using AirQualityMonitoringSystem.Application.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace AirQualityMonitoringSystem.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class AlertaController : ControllerBase
    {
        private readonly AlertaService _alertaService;

        public AlertaController(AlertaService alertaService)
        {
            _alertaService = alertaService;
        }

        // GET: api/alerta
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var alertas = await _alertaService.GetAllAsync();

            return Ok(alertas);
        }
    }
}