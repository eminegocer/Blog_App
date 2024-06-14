using BlogApp.Data.Abstracts;
using BlogApp.Entity;

namespace BlogApp.Data.Concreate.EfCore
{
    public class EfUserRepository : IUserRapository
    {  //sınıf oluşturulduktan sonra program.cs içinde  tanıması lazım 
        private BlogContext _context;
        public EfUserRepository(BlogContext context)
        {
            _context = context;
        }

        public IQueryable<User> Users => _context.Users;

        public void CreateUser(User User)
        {
            _context.Users.Add(User);
            _context.SaveChanges();
        }
    }
}