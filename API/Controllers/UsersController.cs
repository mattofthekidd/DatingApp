using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")] //"controller" defaults to the name of the controller
    // address/api/users
    public class UsersController :  ControllerBase
    {
        private readonly DataContext _context;
        public UsersController(DataContext context)
        {
            //This is dependancy injection boy-o
            _context = context;

        }

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