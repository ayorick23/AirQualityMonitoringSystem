using System.ComponentModel.DataAnnotations;

namespace AirQualityMonitoringSystem.Application.DTOs.SensorDTOs
{
    public class CreateSensorDto
    {
        [Required]
        [MaxLength(150)]
        public string Ubicacion { get; set; } = string.Empty;

        [Required]
        [MaxLength(100)]
        public string TipoGas { get; set; } = string.Empty;

        [Required]
        [MaxLength(50)]
        public string Estado { get; set; } = string.Empty;
    }
}