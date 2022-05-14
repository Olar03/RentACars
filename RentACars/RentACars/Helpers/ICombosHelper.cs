using Microsoft.AspNetCore.Mvc.Rendering;
using RentACars.Data.Entities;

namespace RentACars.Helpers
{
    public interface ICombosHelper
    {

        Task<IEnumerable<SelectListItem>> GetComboCategoriesAsync();

        Task<IEnumerable<SelectListItem>> GetComboCategoriesAsync(IEnumerable<Category> filter);

        Task<IEnumerable<SelectListItem>> GetComboLicenceTypesAsync();
        Task<IEnumerable<SelectListItem>> GetComboDocumenTypeAsync();



    }
}
