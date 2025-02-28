using System.ComponentModel.DataAnnotations;

namespace TrainingDBase5ticg3.ViewModels
{
    public class ProfesionesVM
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="Este campo es requerido")]
        [RegularExpression(@"^[a-zA-ZáéíóúÁÉÍÓÚñÑ\s]+$", ErrorMessage = "Solo se permiten letras.")]
        public string strValor { get; set; }

        [MinLength(5,ErrorMessage ="Este campo debe contener minimo 5 caracteres")]
        public string strDescripcion { get; set; }
    }
}