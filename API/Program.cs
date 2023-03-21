//main entry point into our application

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    // builder.Services.AddEndpointsApiExplorer();
    // builder.Services.AddSwaggerGen();


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
