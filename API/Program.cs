using API.Data;
using API.Interfaces;
using API.Services;
using Microsoft.EntityFrameworkCore;
//main entry point into our application

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<DataContext>(options => {
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")); //Looks in the "appsettings" file
});

builder.Services.AddCors();
//section 4.41 udemy
builder.Services.AddScoped<ITokenService, TokenService>(); //usually what you want, can cache data
    // builder.Services.AddTransient() very short lived
    // builder.Services.AddSingleton() is run at startup and persists until the app is closed

//end of services container

var app = builder.Build();
    
//These are middleware

// Configure the HTTP request pipeline.
app.UseCors(x => x.AllowAnyHeader().AllowAnyMethod().WithOrigins("http://localhost:4200")); //sets a CORS policy for our front-end end-point requests

app.MapControllers(); //This tells a request seeking an api end-point where to go

app.Run();
