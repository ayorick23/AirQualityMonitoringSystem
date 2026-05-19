namespace AirQualityMonitoringSystem.Application.DTOs.AlertaDTOs
{
    public class AlertaResponseDto
    {
        public int Id { get; set; }

        public int SensorId { get; set; }

        public string Nivel { get; set; } = string.Empty;

        public string Mensaje { get; set; } = string.Empty;

        public DateTime FechaHora { get; set; }
    }
}