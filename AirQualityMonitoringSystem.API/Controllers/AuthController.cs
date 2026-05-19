using AirQualityMonitoringSystem.Application.DTOs.AuthDTOs;
using AirQualityMonitoringSystem.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace AirQualityMonitoringSystem.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly JwtService _jwtService;

        public AuthController(JwtService jwtService)
        {
            _jwtService = jwtService;
        }

        // POST: api/auth/login
        [HttpPost("login")]
        public IActionResult Login(LoginDto dto)
        {
            // Usuario temporal
            if (dto.Username != "admin"
                || dto.Password != "Admin123*")
            {
                return Unauthorized(new
                {
                    mensaje = "Credenciales inválidas."
                });
            }

            var token =
                _jwtService.GenerateToken(dto.Username);

            return Ok(new
            {
                token
            });
        }
    }
}