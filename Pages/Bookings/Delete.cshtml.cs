using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using FribergsBilar_RazorPages.Data;
using FribergsBilar_RazorPages.Data.Models;

namespace FribergsBilar_RazorPages.Pages.Bookings
{
    public class DeleteModel : PageModel
    {
        private readonly FribergsBilar_RazorPages.Data.ApplicationDbContext _context;

        public DeleteModel(FribergsBilar_RazorPages.Data.ApplicationDbContext context)
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var booking = await _context.Bookings.FindAsync(id);
            if (booking != null)
            {
                Booking = booking;
                _context.Bookings.Remove(Booking);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
