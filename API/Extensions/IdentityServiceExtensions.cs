using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

namespace API.Extensions {
    public static class IdentityServiceExtensions {
        public static IServiceCollection AddIdentityServices(this IServiceCollection services, IConfiguration config) {
            //this IServiceCollection services, is the thing being extended
            //section 4.44
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(x => {
                    x.TokenValidationParameters = new TokenValidationParameters {
                        ValidateIssuerSigningKey = true, //server will check the token signing key is valid based on the issuer signing key
                        IssuerSigningKey = new SymmetricSecurityKey(
                            Encoding.UTF8.GetBytes(config["TokenKey"])
                        ),
                        ValidateIssuer = false, //issuer is the API server, this is not implemented so it is false
                        ValidateAudience = false //not configured so we make it false
                    };
                });
            return services;
        }
    }
}