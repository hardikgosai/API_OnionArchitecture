using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Identity.Client;

namespace Domain.Models
{
    public class UserMap
    {
        public UserMap(EntityTypeBuilder<User> entityBuilder)
        {
            entityBuilder.HasKey(t => t.Id);
            entityBuilder.Property(t => t.UserName).IsRequired();
            entityBuilder.Property(t => t.Password).IsRequired();
            entityBuilder.Property(t => t.Email).IsRequired();
            
            //Define Relationships
            entityBuilder.HasOne(t => t.Profile)
                .WithOne(u => u.User)
                .HasForeignKey<UserProfile>(b => b.Id);
            //One User can have one profile

            /*entityBuilder.Property(t => t.ModifiedDate).IsRequired();
            entityBuilder.Property(t => t.IPAddress).IsRequired();*/
        }
    }
}
