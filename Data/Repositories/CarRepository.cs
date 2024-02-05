using FribergsBilar_RazorPages.Data.Models;
using System.Linq.Expressions;

namespace FribergsBilar_RazorPages.Data.Repositories
{
    public class CarRepository : ICar
    {
        private readonly ApplicationDbContext applicationDbContext;

        public CarRepository(ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }
        IEnumerable<Car> ICar.GetAll()
        {
            return applicationDbContext.Cars.OrderBy(x => x.Brand);
        }
        public Car GetById(int id)
        {
            return applicationDbContext.Cars.FirstOrDefault(c => c.CarId == id);
        }
        public Car Add(Car car)
        {
            var addedEntity = applicationDbContext.Add(car).Entity;
            return addedEntity;
        }

        public IEnumerable<Customer> Find(Expression<Func<Customer, bool>> predicate)
        {
            var result = applicationDbContext.Set<Customer>().AsQueryable().Where(predicate).ToList();
            return result;
        }

        public void Remove(Car car)
        {
            applicationDbContext.Remove(car);
        }

        public void SaveChanges()
        {
            applicationDbContext.SaveChanges();
        }

        public void Update(Car car)
        {
            applicationDbContext.Update(car);
        }


    }
}
