using AirQualityMonitoringSystem.Application.DTOs.LecturaDTOs;
using AirQualityMonitoringSystem.Application.Interfaces;
using AirQualityMonitoringSystem.Domain.Entities;

namespace AirQualityMonitoringSystem.Application.Services
{
    public class LecturaService
    {
        private readonly ILecturaRepository _lecturaRepository;
        private readonly ISensorRepository _sensorRepository;
        private readonly IAlertaRepository _alertaRepository;

        public LecturaService(
            ILecturaRepository lecturaRepository,
            ISensorRepository sensorRepository,
            IAlertaRepository alertaRepository)
        {
            _lecturaRepository = lecturaRepository;
            _sensorRepository = sensorRepository;
            _alertaRepository = alertaRepository;
        }

        // Registrar lectura
        public async Task RegistrarLecturaAsync(CreateLecturaDto dto)
        {
            // Validar sensor existente
            var sensor = await _sensorRepository.GetByIdAsync(dto.SensorId);

            if (sensor == null)
            {
                throw new Exception("El sensor no existe.");
            }

            // Crear lectura
            var lectura = new LecturaAire
            {
                SensorId = dto.SensorId,
                PM2_5 = dto.PM2_5,
                PM10 = dto.PM10,
                CO2 = dto.CO2,
                FechaHora = DateTime.UtcNow
            };

            await _lecturaRepository.AddAsync(lectura);
            await _lecturaRepository.SaveChangesAsync();

            // Generar alerta automática
            var alerta = GenerarAlerta(dto);

            if (alerta != null)
            {
                alerta.SensorId = dto.SensorId;
                alerta.FechaHora = DateTime.UtcNow;

                await _alertaRepository.AddAsync(alerta);
                await _alertaRepository.SaveChangesAsync();
            }
        }

        // Obtener lecturas filtradas
        public async Task<IEnumerable<LecturaResponseDto>> GetFilteredAsync(
            DateTime? fechaInicio,
            DateTime? fechaFin,
            string? contaminante)
        {
            var lecturas = await _lecturaRepository.GetFilteredAsync(
                fechaInicio,
                fechaFin,
                contaminante);

            return lecturas.Select(l => new LecturaResponseDto
            {
                Id = l.Id,
                SensorId = l.SensorId,
                PM2_5 = l.PM2_5,
                PM10 = l.PM10,
                CO2 = l.CO2,
                FechaHora = l.FechaHora
            });
        }

        // Lógica OMS alertas
        private AlertaAire? GenerarAlerta(CreateLecturaDto dto)
        {
            // ALERTA EXTREMA
            if (dto.CO2 > 5000 || dto.PM2_5 > 250)
            {
                return new AlertaAire
                {
                    Nivel = "Extrema",
                    Mensaje = "Nivel de contaminación extremadamente alto. Riesgo severo para la salud."
                };
            }

            // ALERTA CRÍTICA
            if (dto.PM2_5 > 150 || dto.PM10 > 200)
            {
                return new AlertaAire
                {
                    Nivel = "Crítica",
                    Mensaje = "La calidad del aire es peligrosa. Se recomienda permanecer en interiores y usar mascarilla."
                };
            }

            // ALERTA MODERADA
            if ((dto.PM2_5 >= 51 && dto.PM2_5 <= 100)
                || dto.CO2 > 1000)
            {
                return new AlertaAire
                {
                    Nivel = "Moderada",
                    Mensaje = "La calidad del aire es poco saludable para grupos sensibles."
                };
            }

            // ALERTA LEVE
            if (dto.PM2_5 >= 25 && dto.PM2_5 <= 50)
            {
                return new AlertaAire
                {
                    Nivel = "Leve",
                    Mensaje = "La calidad del aire es moderada."
                };
            }

            return null;
        }
    }
}