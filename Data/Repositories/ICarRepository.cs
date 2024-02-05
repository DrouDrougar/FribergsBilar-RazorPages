using FribergsBilar_RazorPages.Data.Models;
using System.Linq.Expressions;

namespace FribergsBilar_RazorPages.Data.Repositories
{
    public interface ICarRepository
    {
        Car Add(Car car);
        IEnumerable<Customer> Find(Expression<Func<Customer, bool>> predicate);
        Car GetById(int id);
        void Remove(Car car);
        void SaveChanges();
        void Update(Car car);
    }
}