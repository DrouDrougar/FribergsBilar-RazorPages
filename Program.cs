using Microsoft.EntityFrameworkCore;
using FribergsBilar_RazorPages.Data;
using FribergsBilar_RazorPages.Data.Repositories;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace FribergsBilar_RazorPages
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            //builder.Services.AddDbContext<ApplicationDbContext>
            //(options => options.UseSqlServer
            //("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=MVCCars;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False"));
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("FribergsBilar_RazorPagesContext") ??
                throw new InvalidOperationException("Connection string 'FribergsBilar_RazorPagesContext' not found.")));

            builder.Services.AddTransient(typeof(ICar), typeof(CarRepository));
            builder.Services.AddTransient(typeof(IBooking), typeof(BookingRepository));
            builder.Services.AddTransient(typeof(ICustomer), typeof(CustomerRepository));
            builder.Services.AddTransient(typeof(IAdmin), typeof(AdminRepository));
            

            builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            // Add services to the container.
            builder.Services.AddRazorPages();

            //var app = builder.Build();

            // Configure the HTTP request pipeline.

            builder.Services.AddDistributedMemoryCache();
            builder.Services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(15);
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });
            var app = builder.Build();
            app.UseRouting();

            app.UseAuthorization();
            app.UseSession();
            app.MapRazorPages();
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseStaticFiles();
            app.Run();
        }
    }
}
