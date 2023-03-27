using API.Data;
using Microsoft.EntityFrameworkCore;
//main entry point into our application

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<DataContext>(options => {
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")); //Looks in the "appsettings" file
});

builder.Services.AddCors();

//end of services container

var app = builder.Build();
    
//These are middleware

// Configure the HTTP request pipeline.
app.UseCors(x => x.AllowAnyHeader().AllowAnyMethod().WithOrigins("http://localhost:4200")); //sets a CORS policy for our front-end end-point requests

app.MapControllers(); //This tells a request seeking an api end-point where to go

app.Run();
