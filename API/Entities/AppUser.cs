using System.ComponentModel.DataAnnotations;

namespace API.Entities
{
    public class AppUser {
        public AppUser(string UserName, byte[] PasswordHash, byte[] PasswordSalt) {
            //note: the parameter names need to be the same as the class's variable names
            // because EF Core is a bit of a b*tch I guess.
            this.UserName = UserName.ToLower();
            this.PasswordHash = PasswordHash;
            this.PasswordSalt = PasswordSalt;
        }
        //tells EF that this is the primary key
        //needed if the Id had a special name like "ThingId"
        //added for future self
        [Key]
        public int Id { get; set; }
        public string UserName { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }

    }
}