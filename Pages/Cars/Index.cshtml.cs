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
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public IndexModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Car> Car { get;set; } = default!;

        public async Task OnGetAsync()
        {
            ViewData["AdminCookies"] = Request.Cookies["AdminCookies"];
            ViewData["UserCookies"] = Request.Cookies["UserCookies"];
            Car = await _context.Cars.ToListAsync();
        }
    }
}
