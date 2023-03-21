using API.Data;
using Microsoft.EntityFrameworkCore;
//main entry point into our application

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<DataContext>(options => {
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"));
});

//end of services container

var app = builder.Build();
    
//These are middleware
// you can put things here like authorization
    // // Configure the HTTP request pipeline.
    // if (app.Environment.IsDevelopment())
    // {
    //     app.UseSwagger();
    //     app.UseSwaggerUI();
    // }

    // app.UseHttpsRedirection();
    // app.UseAuthorization();

//This tells a request seeking an api end-point where to go
app.MapControllers();

app.Run();
