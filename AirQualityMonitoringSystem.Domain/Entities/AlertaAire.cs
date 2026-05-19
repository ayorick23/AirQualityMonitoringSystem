using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AirQualityMonitoringSystem.Domain.Entities
{
    public class AlertaAire
    {
        // Llave primaria
        public int Id { get; set; }

        // Llave foránea hacia Sensor
        public int SensorId { get; set; }

        // Nivel de alerta:
        // Leve
        // Moderada
        // Crítica
        // Extrema
        [Required]
        [MaxLength(50)]
        public string Nivel { get; set; } = string.Empty;

        // Mensaje descriptivo
        [Required]
        [MaxLength(500)]
        public string Mensaje { get; set; } = string.Empty;

        // Fecha y hora de generación
        public DateTime FechaHora { get; set; }

        // Propiedad de navegación
        [ForeignKey("SensorId")]
        public SensorCalidadAire Sensor { get; set; } = null!;
    }
}