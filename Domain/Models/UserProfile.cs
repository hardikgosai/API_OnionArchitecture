namespace Domain.Models
{
    public class UserProfile : BaseEntity
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Address { get; set; }

        public string ContactNo { get; set; }

        public User User { get; set; } //Foreign Key
    }
}
