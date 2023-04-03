using System.Security.Cryptography;
using System.Text;
using API.Data;
using API.DTOS;
using API.Entities;
using API.Interfaces;
using API.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    public class AccountController : BaseApiController {
        private readonly DataContext _context;
        private readonly ITokenService _tokenService;
        public AccountController(DataContext context, ITokenService tokenService) {
            _context = context;
            _tokenService = tokenService;
        }

        [HttpPost("register")] //POST: api/accounts/register
        public async Task<ActionResult<UserDto>> Register(RegisterDto registerDto) {
            if(await IsUserUnique(registerDto.Username)) return BadRequest("Username must be unique.");
        
            // This is rendered pointless because of the [Required] tag on the RegisterDto model.
            // if(IsNewUserEmpty(registerDto.Username, registerDto.Password)) return BadRequest("Username and password cannot be null.");

            using var hmac = new HMACSHA512(); //"using" will garbage collect this automatically

            var user = new AppUser {
                Username = registerDto.Username.ToLower(),
                PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(registerDto.Password)),
                PasswordSalt = hmac.Key
            };
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return new UserDto {
                Username = user.Username,
                Token = _tokenService.CreateToken(user)
            };
        }

        [HttpPost("login")]
        public async Task<ActionResult<UserDto>> Login(LoginDto loginDto) {
            var user = await _context.Users.SingleOrDefaultAsync(x => x.Username.ToLower() == loginDto.Username.ToLower());
            if(user == null) return Unauthorized("invalid username");

            using var hmac = new HMACSHA512(user.PasswordSalt);

            var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(loginDto.Password));

            for (var i = 0; i < computedHash.Length; i++) {
                if(computedHash[i] != user.PasswordHash[i]) return Unauthorized("invalid password");
            }

            return new UserDto {
                Username = user.Username,
                Token = _tokenService.CreateToken(user)
            };
        }

        private async Task<bool> IsUserUnique(string username) {
            return await _context.Users.AnyAsync(x => x.Username.ToLower() == username.ToLower());
        }
        
    }
}