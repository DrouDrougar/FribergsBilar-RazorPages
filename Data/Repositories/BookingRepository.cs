
using FribergsBilar_RazorPages.Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Drawing.Text;
using System.Linq.Expressions;

namespace FribergsBilar_RazorPages.Data.Repositories
{
    public class BookingRepository : IBooking
    {

        private readonly ApplicationDbContext applicationDbContext;

        public BookingRepository(ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }
        public IEnumerable<Booking> GetAll()
        {
            return applicationDbContext.Bookings.OrderBy(x => x.BookingId);
        }

        public Booking GetById(int id)
        {
            return applicationDbContext.Bookings.FirstOrDefault(c => c.BookingId == id);
        }
        public Booking Add(Booking booking)
        {
            var addedEntity = applicationDbContext.Add(booking).Entity;
            return addedEntity;
        }

        public IEnumerable<Booking> Find(Expression<Func<Booking, bool>> predicate)
        {
            var result = applicationDbContext.Set<Booking>().AsQueryable().Where(predicate).ToList();
            return result;
        }

        public void Remove(Booking booking)
        {
            applicationDbContext.Remove(booking);
        }

        public void SaveChanges()
        {
            applicationDbContext.SaveChanges();
        }

        public void Update(Booking booking)
        {
            applicationDbContext.Update(booking);
        }
        private IList<Booking> _bookings = new List<Booking>();

         async IAsyncEnumerable<Task<IList<Booking>>> IBooking.GetAllList()
        {
            
            await this.applicationDbContext.Bookings
           .Include(x => x.Car)
           .Include(c => c.Customer).ToListAsync(); 
            yield return (Task<IList<Booking>>)_bookings;
        }
    }
}
