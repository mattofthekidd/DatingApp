using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers {
    public class BuggyController : BaseApiController {
        private readonly DataContext _context;
        
        public BuggyController(DataContext context) {
            _context = context;       
        }

        [Authorize]
        [HttpGet("auth")]
        public ActionResult<string> GetSecret() {
            return "secret text";
        }

        [HttpGet("not-found")]
        public ActionResult<AppUser> GetNotFound(int id = -1) {
            var user = _context.Users.Find(id);
            if(user == null) return NotFound();
            return user;
        }

        [HttpGet("server-error")]
        public ActionResult<string> GetServerError(int id = -1) {
            var user = _context.Users.Find(id);
            var res = user.ToString();
            return res;
        }        
        [HttpGet("bad-request")]
        public ActionResult<string> GetBadRequest() {
            return BadRequest("Not a good request");
        }        

    }
}