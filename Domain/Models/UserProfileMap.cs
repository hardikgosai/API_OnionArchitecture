using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Domain.Models
{
    public class UserProfileMap
    {
        public UserProfileMap(EntityTypeBuilder<UserProfile> entityBuilder)
        {
            entityBuilder.HasKey(t => t.Id);
            entityBuilder.Property(t => t.FirstName).IsRequired();
            entityBuilder.Property(t => t.LastName).IsRequired();
            entityBuilder.Property(t => t.Address).IsRequired();
            entityBuilder.Property(t => t.ContactNo).IsRequired();
            entityBuilder.Property(t => t.Address).HasMaxLength(100);
            /*entityBuilder.Property(t => t.ModifiedDate).IsRequired();
             *entityBuilder.Property(t => t.IPAddress).IsRequired();*/
        }
    }
}
