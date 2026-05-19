using AirQualityMonitoringSystem.Application.DTOs.AlertaDTOs;
using AirQualityMonitoringSystem.Application.Interfaces;

namespace AirQualityMonitoringSystem.Application.Services
{
    public class AlertaService
    {
        private readonly IAlertaRepository _alertaRepository;

        public AlertaService(IAlertaRepository alertaRepository)
        {
            _alertaRepository = alertaRepository;
        }

        // Obtener alertas
        public async Task<IEnumerable<AlertaResponseDto>> GetAllAsync()
        {
            var alertas = await _alertaRepository.GetAllAsync();

            return alertas.Select(a => new AlertaResponseDto
            {
                Id = a.Id,
                SensorId = a.SensorId,
                Nivel = a.Nivel,
                Mensaje = a.Mensaje,
                FechaHora = a.FechaHora
            });
        }
    }
}