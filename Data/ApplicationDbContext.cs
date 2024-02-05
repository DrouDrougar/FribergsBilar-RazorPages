using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using FribergsBilar_RazorPages.Data.Models;

namespace FribergsBilar_RazorPages.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext (DbContextOptions<ApplicationDbContext> options): base(options)
        {
        }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Car> Cars { get; set; } = default!;
        public DbSet<Customer> Customers { get; set; } = default!;
        public DbSet<Booking> Bookings { get; set; } = default!;
        public DbSet<OldOrders> OldOrders { get; set; } = default!;
        
    }
}
