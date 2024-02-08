using FribergsBilar_RazorPages.Data.Models;
using System.Linq.Expressions;

namespace FribergsBilar_RazorPages.Data.Repositories
{

    //kept the repos and interfaces even though they are not really used at all in the project since the razor pages transision.
    public class AdminRepository : IAdmin
    {
        private readonly ApplicationDbContext applicationDbContext;

        public AdminRepository(ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }
        public IEnumerable<Admin> GetAll()
        {
            return applicationDbContext.Admins.OrderBy(x => x.AdminId);
        }

        public Admin GetById(int id)
        {
            return applicationDbContext.Admins.FirstOrDefault(c => c.AdminId == id);
        }
        public Admin Add(Admin admin)
        {
            var addedEntity = applicationDbContext.Add(admin).Entity;
            return addedEntity;
        }

        public IEnumerable<Admin> Find(Expression<Func<Admin, bool>> predicate)
        {
            var result = applicationDbContext.Set<Admin>().AsQueryable().Where(predicate).ToList();
            return result;
        }

        public void Remove(Admin admin)
        {
            applicationDbContext.Remove(admin);
        }

        public void SaveChanges()
        {
            applicationDbContext.SaveChanges();
        }

        public void Update(Admin admin)
        {
            applicationDbContext.Update(admin);
        }


    }
}
