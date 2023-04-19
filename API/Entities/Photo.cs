using System.ComponentModel.DataAnnotations.Schema;

namespace API.Entities
{
    [Table("Photos")]
    //tells EF that we want the table name to be Photos and not Photo
    public class Photo
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public bool IsMain { get; set; }
        public string PublicId { get; set; }
        //The blow two props tells EF when it makes a migration
        // that a photo must have a User tied to it
        public int AppUserId { get; set; }
        public AppUser AppUser { get; set; }
    }
}