using Domain.Models;

namespace Services.Repository
{
    public interface IUserProfileRepository
    {
        //IEnumerable<UserProfile> GetUserProfiles();

        UserProfile GetUserProfile(long id);

        /*void InsertUserProfile(UserProfile userProfile);

        void UpdateUserProfile(UserProfile userProfile);

        void DeleteUserProfile(long id);*/
    }
}
