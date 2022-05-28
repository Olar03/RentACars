using RentACars.Common;
using RentACars.Models;

namespace RentACars.Helpers
{
    public interface IReserveHelper
    {

        Task<Response> ProcessReserveAsync(ReserveViewModel model);

        Task<Response> CancelReserveAsync(int id);
    }
}
