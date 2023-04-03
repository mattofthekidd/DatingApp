using System.Text;
using API.Data;
using API.Extensions;
using API.Interfaces;
using API.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
//main entry point into our application

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddApplicationServices(builder.Configuration);
builder.Services.AddIdentityServices(builder.Configuration);

//end of services container

var app = builder.Build();

//These are middleware

// Configure the HTTP request pipeline.
app.UseCors(x => x.AllowAnyHeader().AllowAnyMethod().WithOrigins("http://localhost:4200")); //sets a CORS policy for our frontend endpoint requests

//this must happen here in this order, section 4.44
app.UseAuthentication(); //is the token valid?
app.UseAuthorization(); //if token is valid, what does the token allow you to do?

app.MapControllers(); //This tells a request seeking an api end-point where to go

app.Run();
