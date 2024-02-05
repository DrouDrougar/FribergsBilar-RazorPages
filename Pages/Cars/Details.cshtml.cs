using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using FribergsBilar_RazorPages.Data;
using FribergsBilar_RazorPages.Data.Models;

namespace FribergsBilar_RazorPages.Pages.Cars
{
    public class DetailsModel : PageModel
    {
        private readonly FribergsBilar_RazorPages.Data.ApplicationDbContext _context;

        public DetailsModel(FribergsBilar_RazorPages.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public Car Car { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            ViewData["AdminCookies"] = Request.Cookies["AdminCookies"];
            ViewData["UserCookies"] = Request.Cookies["UserCookies"];
            if (id == null)
            {
                return NotFound();
            }

            var car = await _context.Cars.FirstOrDefaultAsync(m => m.CarId == id);
            if (car == null)
            {
                return NotFound();
            }
            else
            {
                Car = car;
            }
            return Page();
        }
    }
}
