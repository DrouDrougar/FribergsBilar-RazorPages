using FribergsBilar_RazorPages.Data.Models;

namespace FribergsBilar_RazorPages.Data.Repositories
{
    public interface IBooking 
    {
        Booking GetById(int id);

        IEnumerable<Booking> GetAll();
        Booking Add(Booking Booking);
        void Remove(Booking booking);
        void SaveChanges();
        void Update(Booking booking);
        //IEnumerable<Task<IList<Booking>>> ToListAsync();
        IAsyncEnumerable<Task<IList<Booking>>> GetAllList();

    }
}
