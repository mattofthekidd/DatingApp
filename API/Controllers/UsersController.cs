using API.DTOS;
using API.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Authorize] //must pass a token to the endpoint to access
    public class UsersController : BaseApiController {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        public UsersController(IUserRepository userRepository, IMapper mapper) {
            _mapper = mapper;
            _userRepository = userRepository;
        }

        //[HttpGet] //Attribute telling the compiler what the method does
        //public async Task<AppUser> GetTest() { //the method is async which returns a Task
        //  return await _context.Users.linqAsync(); 
        // //we use EF Core to make our query async
        // //we must await on the db context while the query runs
        // //this is an Endpoint in the API controller
        //}

        [AllowAnonymous] //bypasses any authentication
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MemberDto>>> GetUsers() {
            var users = await _userRepository.GetMembersAsync();
            return Ok(users);
            // var usersToReturn = _mapper.Map<IEnumerable<MemberDto>>(users);
            // return Ok(usersToReturn);
        }

        [HttpGet("{username}")]
        public async Task<ActionResult<MemberDto>> GetUser(string username) {
            return await _userRepository.GetMemberAsync(username);
           
        }

    }
}