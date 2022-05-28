using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RentACars.Data.Entities
{
    public class ReserveDetail
    {
        public int Id { get; set; }

        public Reserve Reserve { get; set; }
        public Vehicle Vehicle { get; set; }

        [DataType(DataType.MultilineText)]
        [Display(Name = "Comentarios")]
        public string Comments { get; set; }

        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd hh:mm tt}", ApplyFormatInEditMode = true)]
        [Display(Name = "Fecha inicio reserva")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [DataType(DataType.Date)]
        public DateTime DeliveryDate { get; set; }

        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd hh:mm tt}", ApplyFormatInEditMode = true)]
        [Display(Name = "Fecha final reserva")]
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public DateTime ReturnDate { get; set; }


        [DisplayFormat(DataFormatString = "{0:C2}")]
        [Display(Name = "Valor")]
        public decimal Value => Vehicle == null ? 0 : Vehicle.PriceDay * (decimal)ReturnDate.Day - (decimal)DeliveryDate.Day;

    }
}
