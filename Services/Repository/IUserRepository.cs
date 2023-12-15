using Domain.Models;

namespace Services.Repository
{
    public interface IUserRepository
    {
        IEnumerable<User> GetUsers();

        User Getuser(long id);
        
        void InsertUser(User user);

        void UpdateUser(User user);

        void DeleteUser(long id);
    }
}
