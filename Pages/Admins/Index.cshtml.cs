using Azure.Core;
using FribergsBilar_RazorPages.Data.Models;
using FribergsBilar_RazorPages.Data.Repositories;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace FribergsBilar_RazorPages.Pages.Admins
{
    public class IndexModel : PageModel
    {
        [BindProperty]
        public Admin Admin { get; set; }

        private readonly IAdmin _adminService;
        private readonly IHttpContextAccessor httpContextAccessor;
        public IndexModel(IAdmin adminService, IHttpContextAccessor httpContextAccessor)
        {

            _adminService = adminService;
            this.httpContextAccessor = httpContextAccessor;
        }

        public void OnGet()
        {

        }

        public async Task<IActionResult> OnPostAsync()
        {
            try
            {
                var checkUser = _adminService.GetAll();
                var customerModel = new Admin();
                customerModel = checkUser.First(e => e.Email == Admin.Email);
                if (customerModel != null && customerModel.Email == Admin.Email && customerModel.Password == Admin.Password)
                {
                    CookieOptions options = new CookieOptions();
                    options.Expires = DateTimeOffset.Now.AddMinutes(15);
                    httpContextAccessor.HttpContext.Response.Cookies.Append("AdminCookies", customerModel.AdminId.ToString(), options);

                };
                return RedirectToPage("/Index");
            }
            catch (Exception)
            {

                return Page();
            }
        }
    }
}

//ViewData["AdminCookies"] = Request.Cookies["AdminCookies"];
//ViewData["UserCookies"] = Request.Cookies["UserCookies"];
//int usersId = Convert.ToInt32(ViewData["UserCookies"] = Request.Cookies["UserCookies"]);
//if (id == null)
//{
//    return NotFound();
//}

//var booking = await _context.Bookings.Include(x => x.Customer.Bookings).Include(c => c.Car).FirstOrDefaultAsync(m => m.BookingId == id);