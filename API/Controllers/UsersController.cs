using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers {
    public class UsersController : BaseApiController {
        private readonly DataContext _context;
        public UsersController(DataContext context)
        {
            //This is dependancy injection boy-o
            _context = context;

        }

        //[HttpGet] //Attribute telling the compiler what the method does
        //public async Task<AppUser> GetTest() { //the method is async which returns a Task
        //  return await _context.Users.linqAsync(); 
        // //we use EF Core to make our query async
        // //we must await on the db context while the query runs
        // //this is an Endpoint in the API controller
        //}


        [HttpGet]
        public async Task<ActionResult<IEnumerable<AppUser>>> GetUsers() {
            var users = await _context.Users.ToListAsync();
            return users;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AppUser>> GetUserAsync(int Id) {
            var user = await _context.Users.FindAsync(Id);
            return user;
        }

    }
}