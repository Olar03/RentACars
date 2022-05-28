using System.ComponentModel.DataAnnotations;

namespace RentACars.Data.Entities
{
    public class LicenceType
    {
        public int Id { get; set; }

        [Display(Name = "Tipo licencia")]
        [MaxLength(20, ErrorMessage = "El campo {0} debe tener maximo {1} caracteres")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string Name { get; set; }

    }
}
