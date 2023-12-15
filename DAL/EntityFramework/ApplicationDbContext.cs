using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace DAL.EntityFramework
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions opt) : base(opt) { }



        public DbSet<User> Users { get; set; }
        public DbSet<UserProfile> UserProfiles { get; set; }

        protected override void OnModelCreating(ModelBuilder oModelBuilder)
        {
            //base.OnModelCreating(modelBuilder);
            //From this function we can do the association for User to UserMap and UserProfile to UserProfileMap 
            new UserMap(oModelBuilder.Entity<User>());
            new UserProfileMap(oModelBuilder.Entity<UserProfile>());
        }
    }
}
