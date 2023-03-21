using System.ComponentModel.DataAnnotations;

namespace API.Entities
{
    public class AppUser {
        //tells EF that this is the primary key
        //needed if the Id had a special name like "ThingId"
        //added for future self
        [Key]
        public int Id { get; set; }

        public string UserName { get; set; }

    }
}