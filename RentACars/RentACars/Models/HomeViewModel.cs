using RentACars.Data.Entities;

namespace RentACars.Models
{
    public class HomeViewModel
    {
        public ICollection<Vehicle> Vehicles { get; set; }

        public float Quantity { get; set; }

    }
}
