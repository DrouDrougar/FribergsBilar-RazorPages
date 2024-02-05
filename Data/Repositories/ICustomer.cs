using FribergsBilar_RazorPages.Data.Models;
using System.Linq.Expressions;

namespace FribergsBilar_RazorPages.Data.Repositories
{
    public interface ICustomer
    {
        Customer GetById(int id);
        Customer Add(Customer customer);
        void Remove(Customer customer);
        void SaveChanges();
        void Update(Customer customer);
        IEnumerable<Customer> GetAll();
        //IEnumerable<Customer> Update(Customer customer);
        IEnumerable<Customer> Find(Expression<Func<Customer, bool>> predicate);
    }
}
