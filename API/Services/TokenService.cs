using API.Entities;

namespace API.Services
{
    public interface ITokenService
    {
        string CreateToken(AppUser user);
    }

    public class TokenService : ITokenService
    {
        public string CreateToken(AppUser user)
        {
            throw new NotImplementedException();
        }
    }
}