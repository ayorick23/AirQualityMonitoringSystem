using System.ComponentModel.DataAnnotations;

namespace AirQualityMonitoringSystem.Application.DTOs.LecturaDTOs
{
    public class CreateLecturaDto
    {
        [Required]
        public int SensorId { get; set; }

        [Range(0, double.MaxValue)]
        public decimal PM2_5 { get; set; }

        [Range(0, double.MaxValue)]
        public decimal PM10 { get; set; }

        [Range(0, double.MaxValue)]
        public decimal CO2 { get; set; }
    }
}