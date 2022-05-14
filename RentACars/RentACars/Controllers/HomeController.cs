using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RentACars.Data;
using RentACars.Data.Entities;
using RentACars.Helpers;
using RentACars.Models;
using System.Diagnostics;

namespace RentACars.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUserHelper _userHelper;
        private readonly DataContext _context;

        public HomeController(ILogger<HomeController> logger, IUserHelper userHelper, DataContext context)
        {
            _logger = logger;
            _userHelper = userHelper;
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            List<Vehicle> vehicles = await _context.Vehicles
                .Include(i => i.ImageVehicles)
                .Include(c => c.VehicleCategories)
                .OrderBy(v => v.Plaque)
                .ToListAsync();

            HomeViewModel model = new() { Vehicles = vehicles };
            User user = await _userHelper.GetUserAsync(User.Identity.Name);
            //if (user != null)
            //{
            //    model.Quantity = await _context.TemporalSales
            //        .Where(ts => ts.User.Id == user.Id)
            //        .SumAsync(ts => ts.Quantity);
            //}

            return View(model);
        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [Route("error/404")]
        public IActionResult Error404()
        {
            return View();
        }

        public async Task<IActionResult> Add(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "Account");
            }

            Vehicle vehicle = await _context.Vehicles.FindAsync(id);
            if (vehicle == null)
            {
                return NotFound();
            }

            User user = await _userHelper.GetUserAsync(User.Identity.Name);
            if (user == null)
            {
                return NotFound();
            }

            //TemporalSale temporalSale = new()
            //{
            //    Product = vehicle,
            //    Quantity = 1,
            //    User = user
            //};

            //_context.TemporalSales.Add(temporalSale);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        //public async Task<IActionResult> Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    Vehicle vehicle = await _context.Vehicles
        //        .Include(i => i.ImageVehicles)
        //        .Include(c => c.VehicleCategories)
        //        .ThenInclude(vc => vc.Category)
        //        .FirstOrDefaultAsync(v => v.Id == id);
        //    if (vehicle == null)
        //    {
        //        return NotFound();
        //    }

        //    string categories = string.Empty;
        //    foreach (VehicleCategory? category in vehicle.VehicleCategories)
        //    {
        //        categories += $"{category.Category.Name}, ";
        //    }
        //    categories = categories.Substring(0, categories.Length - 2);

        //    AddProductToCartViewModel model = new()
        //    {
        //        Categories = categories,
        //        Description = vehicle.Description,
        //        Id = vehicle.Id,
        //        Name = vehicle.Name,
        //        Price = vehicle.Price,
        //        ProductImages = vehicle.ProductImages,
        //        Quantity = 1,
        //        Stock = vehicle.Stock,
        //    };

        //    return View(model);
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Details(AddProductToCartViewModel model)
        //{
        //    if (!User.Identity.IsAuthenticated)
        //    {
        //        return RedirectToAction("Login", "Account");
        //    }

        //    Product product = await _context.Products.FindAsync(model.Id);
        //    if (product == null)
        //    {
        //        return NotFound();
        //    }

        //    User user = await _userHelper.GetUserAsync(User.Identity.Name);
        //    if (user == null)
        //    {
        //        return NotFound();
        //    }

        //    TemporalSale temporalSale = new()
        //    {
        //        Product = product,
        //        Quantity = model.Quantity,
        //        Remarks = model.Remarks,
        //        User = user
        //    };

        //    _context.TemporalSales.Add(temporalSale);
        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}


    }
}