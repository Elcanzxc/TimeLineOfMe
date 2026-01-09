using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;
using TimeLineOfMe.DataAccess;

var builder = WebApplication.CreateBuilder(args);


WebApplication dwada;
builder.Services.AddControllers();

builder.Services.AddOpenApi();

builder.Services.AddDbContext<TimeLineOfMeDbContext>(
    options =>
    {
        var connectionString = builder.Configuration.GetConnectionString("TimeLineOfMeDbContext");
        options.UseSqlServer(connectionString);
    });


var app = builder.Build();





if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();

    app.MapScalarApiReference();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();



app.Run();
