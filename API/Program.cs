using System.Text;
using API.Data;
using API.Interfaces;
using API.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
//main entry point into our application

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")); //Looks in the "appsettings" file
});

builder.Services.AddCors();
//section 4.41 udemy
builder.Services.AddScoped<ITokenService, TokenService>(); //usually what you want, can cache data
// builder.Services.AddTransient() very short lived
// builder.Services.AddSingleton() is run at startup and persists until the app is closed

//section 4.44
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(x => {
        x.TokenValidationParameters = new TokenValidationParameters{
            ValidateIssuerSigningKey = true, //server will check the signing key is valid based on the issuer signing key
            IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(builder.Configuration["TokenKey"])
            ), 
            ValidateIssuer = false, //issuer is the API server, this is not implemented so it is false
            ValidateAudience = false //not configured so we make it false
        };
    });


//end of services container

var app = builder.Build();

//These are middleware

// Configure the HTTP request pipeline.
app.UseCors(x => x.AllowAnyHeader().AllowAnyMethod().WithOrigins("http://localhost:4200")); //sets a CORS policy for our front-end end-point requests

//this must happen here in this order, section 4.44
app.UseAuthentication(); //is the token valid?
app.UseAuthorization(); //what does the token allow you to do?

app.MapControllers(); //This tells a request seeking an api end-point where to go

app.Run();
