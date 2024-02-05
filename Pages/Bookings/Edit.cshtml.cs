using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FribergsBilar_RazorPages.Data;
using FribergsBilar_RazorPages.Data.Models;

namespace FribergsBilar_RazorPages.Pages.Bookings
{
    public class EditModel : PageModel
    {
        private readonly FribergsBilar_RazorPages.Data.ApplicationDbContext _context;

        public EditModel(FribergsBilar_RazorPages.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Booking Booking { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            ViewData["AdminCookies"] = Request.Cookies["AdminCookies"];
            ViewData["UserCookies"] = Request.Cookies["UserCookies"];
            if (id == null)
            {
                return NotFound();
            }

            var booking =  await _context.Bookings.FirstOrDefaultAsync(m => m.BookingId == id);
            if (booking == null)
            {
                return NotFound();
            }
            Booking = booking;
           ViewData["CarId"] = new SelectList(_context.Cars, "CarId", "CarId");
           ViewData["CustomerId"] = new SelectList(_context.Customers, "CustomerId", "Email");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Booking).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BookingExists(Booking.BookingId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool BookingExists(int id)
        {
            return _context.Bookings.Any(e => e.BookingId == id);
        }
    }
}
