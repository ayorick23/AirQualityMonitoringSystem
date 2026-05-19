using System.ComponentModel.DataAnnotations;

namespace AirQualityMonitoringSystem.Domain.Entities
{
    public class SensorCalidadAire
    {
        // Llave primaria
        public int Id { get; set; }

        // Ubicación física del sensor
        [Required]
        [MaxLength(150)]
        public string Ubicacion { get; set; } = string.Empty;

        // Tipo de gas o contaminante monitoreado
        [Required]
        [MaxLength(100)]
        public string TipoGas { get; set; } = string.Empty;

        // Estado del sensor
        // Activo
        // Inactivo
        // Mantenimiento
        [Required]
        [MaxLength(50)]
        public string Estado { get; set; } = string.Empty;

        // Un sensor puede tener múltiples lecturas
        public ICollection<LecturaAire> Lecturas { get; set; }
            = new List<LecturaAire>();

        // Un sensor puede generar múltiples alertas
        public ICollection<AlertaAire> Alertas { get; set; }
            = new List<AlertaAire>();
    }
}