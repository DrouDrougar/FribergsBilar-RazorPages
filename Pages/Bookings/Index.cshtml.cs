using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using FribergsBilar_RazorPages.Data.Models;
using Microsoft.AspNetCore.Mvc;
using FribergsBilar_RazorPages.Data.Repositories;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FribergsBilar_RazorPages.Pages.Bookings
{
    public class IndexModel : PageModel
    {
        private readonly Data.ApplicationDbContext _context;
        //private readonly IBooking _booking;
        public IndexModel(Data.ApplicationDbContext context /*IBooking booking*/)
        {
            _context = context;
            
        }

        public IList<Booking> Booking { get;set; } = default!;
        public IList<OldOrders> OldOrders { get; set; } = default!;  

        public async Task OnGetAsync()
        {
            ViewData["AdminCookies"] = Request.Cookies["AdminCookies"];
            ViewData["UserCookies"] = Request.Cookies["UserCookies"];
            if (ViewData["UserCookies"] != null)
            {
                int id = Convert.ToInt32(ViewData["UserCookies"]);
                Booking = await _context.Bookings.Where(x => x.CustomerId == id).Include(b => b.Car)
                    .Include(b => b.Customer).ToListAsync();

                OldOrders = await _context.OldOrders.Where(x => x.CustomerId == id).Include(x => x.Customer).Include(x => x.Car).ToListAsync();
            }
            else
            {
                Booking = await _context.Bookings
                    .Include(b => b.Car)
                    .Include(b => b.Customer).ToListAsync();
            }

        }
    }
}
