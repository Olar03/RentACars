using System.ComponentModel.DataAnnotations;

namespace RentACars.Data.Entities
{
    public class Vehicle
    {
        public int Id { get; set; }

        [Display(Name = "Marca")]
        [MaxLength(20, ErrorMessage = "El campo {0} debe tener maximo {1} caracteres")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string Brand { get; set; }

        [Display(Name = "Serie")]
        [MaxLength(50, ErrorMessage = "El campo {0} debe tener maximo {1} caracteres")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string Serie { get; set; }
        

        [Display(Name = "Placa")]
        [MaxLength(20, ErrorMessage = "El campo {0} debe tener maximo {1} caracteres")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string Plaque { get; set; }

        [Display(Name = "Observaciones")]
        [MaxLength(500, ErrorMessage = "El campo {0} debe tener máximo {1} caractéres.")]
        public string Remarks { get; set; }

        public ICollection<VehicleCategory> VehicleCategories { get; set; }

        [Display(Name = "Categorías")]
        public int CategoriesNumber => VehicleCategories == null ? 0 : VehicleCategories.Count;
        
        public ICollection<ImageVehicle> ImageVehicles { get; set; }

        [Display(Name = "Fotos")]
        public int ImagesNumber => ImageVehicles == null ? 0 : ImageVehicles.Count;

        //TODO: Pending to change to the correct path
        [Display(Name = "Foto")]
        public string ImageFullPath => ImageVehicles == null || ImageVehicles.Count == 0
            ? $"https://https://localhost:7203/images/noimage.png"
            : ImageVehicles.FirstOrDefault().ImageFullPath;

    }
}
