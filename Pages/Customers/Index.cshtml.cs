using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using FribergsBilar_RazorPages.Data;
using FribergsBilar_RazorPages.Data.Models;



namespace FribergsBilar_RazorPages.Pages.Customers
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        
        public IndexModel(ApplicationDbContext context)
        {
            _context = context;
            
        }

        public IList<Customer> Customer { get;set; } = default!;

        public async Task OnGetAsync()
        {
            ViewData["AdminCookies"] = Request.Cookies["AdminCookies"];
            ViewData["UserCookies"] = Request.Cookies["UserCookies"];
            Customer = await _context.Customers.ToListAsync();
        }
    }
}
