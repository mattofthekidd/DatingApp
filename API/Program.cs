using API.Data;
using API.Extensions;
using API.Middleware;
using Microsoft.EntityFrameworkCore;
//main entry point into our application

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddApplicationServices(builder.Configuration);
builder.Services.AddIdentityServices(builder.Configuration);

//end of services container

var app = builder.Build();

// if(builder.Environment.IsDevelopment()) {
//     app.UseDeveloperExceptionPage();
// }

//These are middleware

// Configure the HTTP request pipeline.
app.UseMiddleware<ExceptionMiddleware>();
app.UseCors(x => x.AllowAnyHeader().AllowAnyMethod().WithOrigins("http://localhost:4200")); //sets a CORS policy for our frontend endpoint requests

//this must happen here and in this order, section 4.44
app.UseAuthentication(); //is the token valid?
app.UseAuthorization(); //if token is valid, what does the token allow you to do?

app.MapControllers(); //This tells a request seeking an api end-point where to go

//This must occur after MapControllers
//but before Run
using var scope = app.Services.CreateScope(); //gives us access to all the services in Program.cs
var services = scope.ServiceProvider;
try {
    var context = services.GetRequiredService<DataContext>();
    await context.Database.MigrateAsync();
    //If we have an empty DB this will run the migrations
    await Seed.SeedUsers(context);
    // obviously running the user seeder
}
catch(Exception ex) {
    var logger = services.GetService<ILogger<Program>>();
    logger.LogError(ex, "An error occured during migration");
}

app.Run();
