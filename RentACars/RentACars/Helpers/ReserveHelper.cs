using RentACars.Common;
using RentACars.Data;
using RentACars.Data.Entities;
using RentACars.Models;
using RentACars.Enums;
using Microsoft.EntityFrameworkCore;

namespace RentACars.Helpers
{
    public class ReserveHelper : IReserveHelper
    {
        private readonly DataContext _context;

        public ReserveHelper(DataContext context)
        {
            _context = context;
        }


        public async Task<Response> ProcessReserveAsync(ReserveViewModel model)
        {
            //Response response = await CheckVehicleStatusAsync(model);
            //if (!response.IsSuccess)
            //{
            //    return response;
            //}

            Reserve reserve = new()
            {
                Date = DateTime.UtcNow,
                User = model.User,
                Comments = model.Comments,
                ReserveDetails = new List<ReserveDetail>(),
                ReserveStatus = ReserveStatus.Nuevo
            };


           
                reserve.ReserveDetails.Add(new ReserveDetail
                {
                    Vehicle = model.Vehicle,
                    DeliveryDate = model.DeliveryDate,
                    ReturnDate = model.ReturnDate,
                    Comments = model.Comments
                });

                Vehicle vehicle = await _context.Vehicles.FindAsync(model.Vehicle.Id);
                if (vehicle != null)
                {
                    vehicle.VehicleStatus = VehicleStatus.Reservado;
                    _context.Vehicles.Update(vehicle);
                }


            
           

            _context.Reserves.Add(reserve);
            await _context.SaveChangesAsync();
            return new Response { IsSuccess = true};
        }

        public async Task<Response> CancelReserveAsync(int id)
        {
            Reserve reserve = await _context.Reserves
                .Include(rd =>rd.ReserveDetails)
                .ThenInclude(rv => rv.Vehicle)
                .FirstOrDefaultAsync(s => s.Id == id);

            foreach (ReserveDetail reserveDetail in reserve.ReserveDetails)
            {
                Vehicle vehicle = await _context.Vehicles.FindAsync(reserveDetail.Vehicle.Id);
                if (vehicle != null)
                {
                    vehicle.VehicleStatus = VehicleStatus.Diponible;
                }

            }
            reserve.ReserveStatus = ReserveStatus.Cancelada;
            await _context.SaveChangesAsync();
            return new Response { IsSuccess = true };
        }


        //private async Task<Response> CheckVehicleStatusAsync(ReserveViewModel model)
        //{
        //    Response response = new() { IsSuccess = true };
        //        Vehicle vehicle = await _context.Vehicles.FindAsync(model.Vehicle.Id);
        //        if (vehicle == null)
        //        {
        //            response.IsSuccess = false;
        //            response.Message = $"El Vehiculo {model.Vehicle.Plaque}, ya no está disponible";
        //            return response;
        //        }
        //        if (vehicle.VehicleStatus != VehicleStatus.Diponible)
        //        {
        //            response.IsSuccess = false;
        //            response.Message = $"Lo sentimos no tenemos disponible el Vehiculo {model.Vehicle.Plaque}, para tomar su pedido. Por favor disminuir la cantidad o sustituirlo por otro.";
        //            return response;
        //        }
            
        //    return response;
        //}

    }
}
