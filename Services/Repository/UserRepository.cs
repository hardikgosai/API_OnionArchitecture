using DAL.EntityFramework;
using Domain.Models;

namespace Services.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext applicationDbContext;

        public UserRepository(ApplicationDbContext _applicationDbContext)
        {
            applicationDbContext = _applicationDbContext;
        }

        public void DeleteUser(long id)
        {
            UserProfile userProfile = applicationDbContext.UserProfiles.Find(id);
            applicationDbContext.UserProfiles.Remove(userProfile);

            User user = applicationDbContext.Users.Find(id);
            applicationDbContext.Users.Remove(user);
            applicationDbContext.SaveChanges();
        }

        public User Getuser(long id)
        {
            return applicationDbContext.Users.Where(s => s.Id == id).FirstOrDefault();
        }

        public IEnumerable<User> GetUsers()
        {
            return applicationDbContext.Users.ToList();
        }

        public void InsertUser(User user)
        {
            applicationDbContext.Users.Add(user);
            applicationDbContext.SaveChanges();
        }

        public void UpdateUser(User user)
        {
            applicationDbContext.Update(user);
            applicationDbContext.SaveChanges();
        }
    }    
}
