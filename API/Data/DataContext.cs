
using API.Entities;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        //when this class is instantiated we'll send it our option string
        }

        //DB sets, these are our tables
        public DbSet<AppUser> Users {get; set;}
    }
}