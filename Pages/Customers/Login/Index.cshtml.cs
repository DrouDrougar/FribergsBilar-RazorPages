 using FribergsBilar_RazorPages.Data;
using FribergsBilar_RazorPages.Data.Models;
using FribergsBilar_RazorPages.Data.Repositories;

using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.ComponentModel.DataAnnotations;
using System.Drawing.Imaging;
using System.Security.Claims;



namespace FribergsBilar_RazorPages.Pages.Login
{
    public class IndexModel : PageModel
    {
        [BindProperty]
        public Customer Customer { get; set; } = default;

       
        private readonly ICustomer _customerService;
        private readonly IHttpContextAccessor httpContextAccessor;

        public IndexModel( ICustomer customerService, IHttpContextAccessor httpContextAccessor)
        {

            _customerService = customerService;
            this.httpContextAccessor = httpContextAccessor;
        }

        public  IActionResult OnGet()
        {
            ViewData["AdminCookies"] = Request.Cookies["AdminCookies"];
            ViewData["UserCookies"] = Request.Cookies["UserCookies"];
            if (ViewData["UserCookies"] != null || ViewData["AdminCookies"] != null)
            {  
                Response.Cookies.Delete("UserCookies");
                Response.Cookies.Delete("AdminCookies");
                return RedirectToPage("/Index");
            }
            else
            {
                return Page();
            }
        }

        public async Task<IActionResult> OnPostAsync() 
        {
            try
            {
                var checkUser = _customerService.GetAll();
                var customerModel = new Customer();
                customerModel = checkUser.First(e => e.Email == Customer.Email);
                if (customerModel != null && customerModel.Email == Customer.Email && customerModel.Password == Customer.Password)
                {
                    CookieOptions options = new CookieOptions();
                    options.Expires = DateTimeOffset.Now.AddMinutes(15);
                    httpContextAccessor.HttpContext.Response.Cookies.Append("UserCookies", customerModel.CustomerId.ToString(), options);

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
