using API.Extensions;

namespace API.Entities
{
    public class AppUser {
        // went away from this while troubleshooting to more closely align with the training code
        // public AppUser(string Username, byte[] PasswordHash, byte[] PasswordSalt) {
        //     //note: the parameter names need to be the same as the classes variable names
        //     // because EF Core is a bit of a b*tch I guess.
        //     this.Username = Username.ToLower();
        //     this.PasswordHash = PasswordHash;
        //     this.PasswordSalt = PasswordSalt;
        // }
        //tells EF that this is the primary key
        //needed if the Id had a special name like "ThingId"
        // [Key]
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
        public List<Photo> Photos { get; set; } = new(); //new() == new () == new List<Photo>()

        public int GetAge() {
            return DateOfBirth.CalculateAge(); //uses DateTimeExtensions
        }
    }
}