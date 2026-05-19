using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AirQualityMonitoringSystem.Domain.Entities
{
    public class LecturaAire
    {
        // Llave primaria
        public int Id { get; set; }

        // Llave foránea hacia SensorCalidadAire
        public int SensorId { get; set; }

        // Material particulado fino
        // No puede ser negativo
        [Range(0, double.MaxValue)]
        public decimal PM2_5 { get; set; }

        // Material particulado grueso
        [Range(0, double.MaxValue)]
        public decimal PM10 { get; set; }

        // Concentración de dióxido de carbono
        [Range(0, double.MaxValue)]
        public decimal CO2 { get; set; }

        // Fecha y hora de la lectura
        public DateTime FechaHora { get; set; }

        // Propiedad de navegación
        [ForeignKey("SensorId")]
        public SensorCalidadAire Sensor { get; set; } = null!;
    }
}