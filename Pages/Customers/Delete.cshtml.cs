using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using FribergsBilar_RazorPages.Data;
using FribergsBilar_RazorPages.Data.Models;

namespace FribergsBilar_RazorPages.Pages.Customers
{
    public class DeleteModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public DeleteModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Customer Customer { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            ViewData["AdminCookies"] = Request.Cookies["AdminCookies"];
            ViewData["UserCookies"] = Request.Cookies["UserCookies"];
            if (id == null)
            {
                return NotFound();
            }

            var customer = await _context.Customers.FirstOrDefaultAsync(m => m.CustomerId == id);

            if (customer == null)
            {
                return NotFound();
            }
            else
            {
                Customer = customer;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customer = await _context.Customers.FindAsync(id);
            if (customer != null)
            {
                Customer = customer;
                _context.Customers.Remove(Customer);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
