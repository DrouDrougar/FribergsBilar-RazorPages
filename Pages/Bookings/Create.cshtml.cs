using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using FribergsBilar_RazorPages.Data;
using FribergsBilar_RazorPages.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace FribergsBilar_RazorPages.Pages.Bookings
{
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public CreateModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["AdminCookies"] = Request.Cookies["AdminCookies"];
            ViewData["UserCookies"] = Request.Cookies["UserCookies"];
            int usersId = Convert.ToInt32(ViewData["UserCookies"] = Request.Cookies["UserCookies"]);
            if (ViewData["UserCookies"] != null)
            {
                ViewData["CarId"] = new SelectList(_context.Cars.Where(x => x.IsBooked == false), "CarId", "Model");
                ViewData["CustomerId"] = new SelectList(_context.Customers.Where(c => c.CustomerId == usersId), "CustomerId", "Email");
                return Page();
            }
            ViewData["CarId"] = new SelectList(_context.Cars.Where(x => x.IsBooked == false), "CarId", "Model");
            ViewData["CustomerId"] = new SelectList(_context.Customers, "CustomerId", "Email");
            return Page();
        }

        [BindProperty]
        public Booking Booking { get; set; } = default!;
        [BindProperty]
        public Customer Customer { get; set; } = default!;
        [BindProperty]
        public Car Car { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            try
            {
                _context.Bookings.Add(Booking);
                await _context.SaveChangesAsync();
                return RedirectToPage("./index");
            }
            catch (Exception)
            {

                throw;
            }

        }
    }
}
