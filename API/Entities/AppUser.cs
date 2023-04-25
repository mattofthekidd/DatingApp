using API.Extensions;

namespace API.Entities
{
    public class AppUser {
        /*
            [Key]
            tells EF that this is the primary key
            needed if the Id had a special name like "ThingId"
        */
        public int Id { get; set; }
        public string Username { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public DateOnly DateOfBirth { get; set; } //using extension method to calculate Date of Birth (DOB)
        public string KnownAs { get; set; }
        public DateTime Created { get; set; } = DateTime.UtcNow; //Sets default value of DateTime.UtcNow
        public DateTime LastActive { get; set; } = DateTime.UtcNow;
        public string Introduction { get; set; }
        public string LookingFor { get; set; }
        public string Interests { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        //In EF terms, this is called a "navigation property" because we access it via Users.Photo
        public List<Photo> Photos { get; set; } = new(); //new() == new List<Photo>()

// because of this Auto Mapper has to get the full entity
//even though we created MemberDto with the intention of pulling less data
        // public int GetAge() {
        //     return DateOfBirth.CalculateAge(); //uses DateTimeExtensions
        // }

        
    }
}