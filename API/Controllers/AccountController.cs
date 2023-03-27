using System.Security.Cryptography;
using System.Text;
using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class AccountController : BaseApiController {
        private readonly DataContext _context;
        public AccountController(DataContext context) {
            _context = context;
        }

        [HttpPost("register")] //POST: api/accounts/register
        public async Task<ActionResult<AppUser>> Register(string username, string password) {
            if(String.IsNullOrEmpty(username) || String.IsNullOrEmpty(password)) return StatusCode(422, "Username and password cannot be null.");

            using var hmac = new HMACSHA512(); //"using" will garbage collect this automatically

            var user = new AppUser(
                username,
                hmac.ComputeHash(Encoding.UTF8.GetBytes(password)),
                hmac.Key
            );
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return user;
        }
        
    }
}