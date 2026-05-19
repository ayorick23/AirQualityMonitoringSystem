using AirQualityMonitoringSystem.Application.DTOs.SensorDTOs;
using AirQualityMonitoringSystem.Application.Interfaces;
using AirQualityMonitoringSystem.Domain.Entities;

namespace AirQualityMonitoringSystem.Application.Services
{
    public class SensorService
    {
        private readonly ISensorRepository _sensorRepository;

        public SensorService(ISensorRepository sensorRepository)
        {
            _sensorRepository = sensorRepository;
        }

        // Obtener sensores
        public async Task<IEnumerable<SensorResponseDto>> GetAllAsync()
        {
            var sensores = await _sensorRepository.GetAllAsync();

            return sensores.Select(s => new SensorResponseDto
            {
                Id = s.Id,
                Ubicacion = s.Ubicacion,
                TipoGas = s.TipoGas,
                Estado = s.Estado
            });
        }

        // Crear sensor
        public async Task CreateAsync(CreateSensorDto dto)
        {
            var sensor = new SensorCalidadAire
            {
                Ubicacion = dto.Ubicacion,
                TipoGas = dto.TipoGas,
                Estado = dto.Estado
            };

            await _sensorRepository.AddAsync(sensor);
            await _sensorRepository.SaveChangesAsync();
        }
    }
}