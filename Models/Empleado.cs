using System.ComponentModel.DataAnnotations;

namespace AppCrud.Models
{
    public class Empleado
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre es requerido")]
        [StringLength(100, ErrorMessage = "El nombre no puede exceder los 100 caracteres")]
        public string Nombre { get; set; } = string.Empty;

        [Required(ErrorMessage = "El apellido es requerido")]
        [StringLength(100, ErrorMessage = "El apellido no puede exceder los 100 caracteres")]
        public string Apellido { get; set; } = string.Empty;

        [Required(ErrorMessage = "El email es requerido")]
        [EmailAddress(ErrorMessage = "Formato de email inválido")]
        [StringLength(200, ErrorMessage = "El email no puede exceder los 200 caracteres")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "El teléfono es requerido")]
        [StringLength(20, ErrorMessage = "El teléfono no puede exceder los 20 caracteres")]
        public string Telefono { get; set; } = string.Empty;

        [Required(ErrorMessage = "El cargo es requerido")]
        [StringLength(100, ErrorMessage = "El cargo no puede exceder los 100 caracteres")]
        public string Cargo { get; set; } = string.Empty;

        [Required(ErrorMessage = "El salario es requerido")]
        [Range(0.01, double.MaxValue, ErrorMessage = "El salario debe ser mayor a cero")]
        public decimal Salario { get; set; }

        [Required(ErrorMessage = "La fecha de contratación es requerida")]
        [DataType(DataType.Date)]
        public DateTime FechaContratacion { get; set; }

        public bool Activo { get; set; } = true;
    }
}