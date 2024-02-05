
using FribergsBilar_RazorPages.Data.Models;

namespace FribergsBilar_RazorPages.Data.Repositories
{
    public interface ICar
    {
        Car GetById(int id);
        //void Add(Car car);
        IEnumerable<Car> GetAll();
        Car Add(Car car);
        void Remove(Car car);
        void SaveChanges();
        void Update(Car car);

    }
}
