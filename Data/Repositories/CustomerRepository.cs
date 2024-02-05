using FribergsBilar_RazorPages.Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace FribergsBilar_RazorPages.Data.Repositories
{
    public class CustomerRepository : ICustomer
    {
        protected readonly ApplicationDbContext applicationDbContext;
        public CustomerRepository(ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }
        public IEnumerable<Customer> GetAll()
        {
            return applicationDbContext.Customers.OrderBy(x => x.FirstName);
        }

        public Customer GetById(int id)
        {
            return applicationDbContext.Customers.FirstOrDefault(c => c.CustomerId == id);
        }

        public Customer Add(Customer customer)
        {
            var addedEntity = applicationDbContext.Add(customer).Entity;
            return addedEntity;
        }

        public IEnumerable<Customer> Find(Expression<Func<Customer, bool>> predicate)
        {
            var result = applicationDbContext.Set<Customer>().AsQueryable().Where(predicate).ToList();
            return result;
        }

        public void Remove(Customer customer)
        {
            applicationDbContext.Remove(customer);
        }

        public void SaveChanges()
        {
            applicationDbContext.SaveChanges();
        }

        public void Update(Customer customer)
        {
            applicationDbContext.Update(customer);
        }


    }
}
