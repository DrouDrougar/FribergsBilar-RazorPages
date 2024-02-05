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
    public class DeleteModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public DeleteModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Booking Booking { get; set; } = default!;
        [BindProperty]
        public OldOrders OldOrders { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            int usersId = Convert.ToInt32(ViewData["UserCookies"] = Request.Cookies["UserCookies"]);
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
                OldOrders.CarId = booking.CarId;
                OldOrders.CustomerId = booking.CustomerId;
                OldOrders.ReturnDate = booking.ReturnDate;
                OldOrders.OrderDate = booking.OrderDate;
                _context.OldOrders.Add(OldOrders);
                await _context.SaveChangesAsync();
                Booking = booking;
                _context.Bookings.Remove(Booking);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
