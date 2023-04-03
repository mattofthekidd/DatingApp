using System.ComponentModel.DataAnnotations;

namespace API.Entities
{
    public class AppUser {
        // went away from this while troubleshooting to more closely align with the training code
        // public AppUser(string Username, byte[] PasswordHash, byte[] PasswordSalt) {
        //     //note: the parameter names need to be the same as the class's variable names
        //     // because EF Core is a bit of a b*tch I guess.
        //     this.Username = Username.ToLower();
        //     this.PasswordHash = PasswordHash;
        //     this.PasswordSalt = PasswordSalt;
        // }
        //tells EF that this is the primary key
        //needed if the Id had a special name like "ThingId"
        //added for future self
        [Key]
        public int Id { get; set; }
        public string Username { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }

    }
}