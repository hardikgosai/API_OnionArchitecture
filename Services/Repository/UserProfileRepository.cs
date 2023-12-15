using DAL.EntityFramework;
using Domain.Models;

namespace Services.Repository
{
    public class UserProfileRepository : IUserProfileRepository
    {
        private readonly ApplicationDbContext applicationDbContext;

        public UserProfileRepository(ApplicationDbContext _applicationDbContext)
        {
            applicationDbContext = _applicationDbContext;
        }
        
        public UserProfile GetUserProfile(long id)
        {
            return applicationDbContext.UserProfiles.FirstOrDefault(s => s.Id == id);
        }
    }
}
