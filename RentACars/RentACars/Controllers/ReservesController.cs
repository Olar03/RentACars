﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RentACars.Data;
using RentACars.Data.Entities;

namespace RentACars.Controllers
{
    public class ReservesController : Controller
    {
        private readonly DataContext _context;

        public ReservesController(DataContext context)
        {
            _context = context;
        }

        // GET: Reserves
        public async Task<IActionResult> Index()
        {
              return View(await _context.Reserves
                  .Include(r => r.User)
                  .Include(r => r.ReserveDetails)
                  .ThenInclude(rv => rv.Vehicle)                  
                  .ToListAsync());
        }

        // GET: Reserves/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Reserve reserve = await _context.Reserves
                  .Include(r => r.User)
                  .Include(r => r.ReserveDetails)
                  .ThenInclude(rv => rv.Vehicle)
                .ThenInclude(p => p.ImageVehicles)
                .FirstOrDefaultAsync(s => s.Id == id);
            if (reserve == null)
            {
                return NotFound();
            }

            return View(reserve);
        }

        // GET: Reserves/Create
       // public async Task<IActionResult> Create(int? id)
       // {

       //     public async Task<IActionResult> AddState(int id)
       //     {
       //         Country country = await _context.Countries.FindAsync(id);
       //         if (country == null)
       //         {
       //             return NotFound();
       //         }

       //         StateViewModel model = new()
       //         {
       //             CountryId = country.Id,
       //         };

       //         return View(model);
       //     }

       // }

       // POST: Reserves/Create
       // To protect from overposting attacks, enable the specific properties you want to bind to.
       // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.

       //[HttpPost]
       // [ValidateAntiForgeryToken]
       // public async Task<IActionResult> Create([Bind("Id,Date,Comments,ReserveStatus,DeliveryDate,ReturnDate")] Reserve reserve)
       // {
       //     if (ModelState.IsValid)
       //     {
       //         _context.Add(reserve);
       //         await _context.SaveChangesAsync();
       //         return RedirectToAction(nameof(Index));
       //     }
       //     return View(reserve);
       // }

        // GET: Reserves/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Reserves == null)
            {
                return NotFound();
            }

            var reserve = await _context.Reserves.FindAsync(id);
            if (reserve == null)
            {
                return NotFound();
            }
            return View(reserve);
        }

        // POST: Reserves/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Date,Comments,ReserveStatus,DeliveryDate,ReturnDate")] Reserve reserve)
        {
            if (id != reserve.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(reserve);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReserveExists(reserve.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(reserve);
        }

        // GET: Reserves/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Reserves == null)
            {
                return NotFound();
            }

            var reserve = await _context.Reserves
                .FirstOrDefaultAsync(m => m.Id == id);
            if (reserve == null)
            {
                return NotFound();
            }

            return View(reserve);
        }

        // POST: Reserves/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Reserves == null)
            {
                return Problem("Entity set 'DataContext.Reserves'  is null.");
            }
            var reserve = await _context.Reserves.FindAsync(id);
            if (reserve != null)
            {
                _context.Reserves.Remove(reserve);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ReserveExists(int id)
        {
          return _context.Reserves.Any(e => e.Id == id);
        }
    }
}