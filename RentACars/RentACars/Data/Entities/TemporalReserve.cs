using System.ComponentModel.DataAnnotations;

namespace RentACars.Data.Entities
{
    public class TemporalReserve
    {
        public int Id { get; set; }

        public User User { get; set; }

        public Vehicle Vehicle { get; set; }

        [DataType(DataType.MultilineText)]
        [Display(Name = "Comentarios")]
        public string Remarks { get; set; }

        //[DisplayFormat(DataFormatString = "{0:C2}")]
        //[Display(Name = "Valor")]
        //public decimal Value => Product == null ? 0 : * Product.Price;

    }
}
