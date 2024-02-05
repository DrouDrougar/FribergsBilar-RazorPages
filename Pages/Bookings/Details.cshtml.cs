using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using FribergsBilar_RazorPages.Data;
using FribergsBilar_RazorPages.Data.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FribergsBilar_RazorPages.Pages.Bookings
{
    public class DetailsModel : PageModel
    {
        private readonly FribergsBilar_RazorPages.Data.ApplicationDbContext _context;

        public DetailsModel(FribergsBilar_RazorPages.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public Booking Booking { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            ViewData["CarId"] = new SelectList(_context.Cars.Where(x => x.IsBooked == false), "CarId", "Model");
            ViewData["CustomerId"] = new SelectList(_context.Customers, "CustomerId", "Email");
            ViewData["AdminCookies"] = Request.Cookies["AdminCookies"];
            ViewData["UserCookies"] = Request.Cookies["UserCookies"];
            if (id == null)
            {
                return NotFound();
            }

            var booking = await _context.Bookings.FirstOrDefaultAsync(m => m.BookingId == id);
            if (booking == null)
            {
                return NotFound();
            }
            else
            {
                Booking = booking;
            }
            return Page();
        }
    }
}
