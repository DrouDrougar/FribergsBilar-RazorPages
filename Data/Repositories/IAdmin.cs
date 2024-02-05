using FribergsBilar_RazorPages.Data.Models;

namespace FribergsBilar_RazorPages.Data.Repositories
{
    public interface IAdmin
    {
        Admin GetById(int id);
        IEnumerable<Admin> GetAll();
        Admin Add(Admin admin);
        void Remove(Admin admin);
        void SaveChanges();
        void Update(Admin admin);
    }
}
