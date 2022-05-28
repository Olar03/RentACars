using RentACars.Common;
using RentACars.Data.Entities;

namespace RentACars.Models
{
    public class HomeViewModel
    {
        public PaginatedList<Vehicle> Vehicles { get; set; }

        public ICollection<Category> Categories { get; set; }

        public float Quantity { get; set; }

    }
}
