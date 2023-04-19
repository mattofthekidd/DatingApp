
using API.Entities;
using Microsoft.EntityFrameworkCore;

namespace API.Data {
    public class DataContext : DbContext {
        public DataContext(DbContextOptions options) : base(options) {
        //when this class is instantiated we'll send it our option string
        }

        //DB sets, these are our tables
        public DbSet<AppUser> Users {get; set;}
        //not creating DbSet<Photo> because we want Photos to be tied to a specific user
        //we will always get a Photo through a specific User
        //we won't be querying for a specifc photo for a specific photo
    }
}