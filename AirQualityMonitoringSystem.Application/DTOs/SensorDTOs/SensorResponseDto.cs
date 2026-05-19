namespace AirQualityMonitoringSystem.Application.DTOs.SensorDTOs
{
    public class SensorResponseDto
    {
        public int Id { get; set; }

        public string Ubicacion { get; set; } = string.Empty;

        public string TipoGas { get; set; } = string.Empty;

        public string Estado { get; set; } = string.Empty;
    }
}