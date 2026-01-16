using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;
using TimeLineOfMe.Application.Services;
using TimeLineOfMe.DataAccess;
using TimeLineOfMe.DataAccess.Repositories;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddOpenApi();

builder.Services.AddDbContext<TimeLineOfMeDbContext>(
    options =>
    {
        var connectionString = builder.Configuration.GetConnectionString("TimeLineOfMeDbContext");
        options.UseSqlServer(connectionString);
    });


builder.Services.AddScoped<IBooksService, BooksService>();
builder.Services.AddScoped<IBooksRepoistory,BooksRepoistory>();

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader());
});



var app = builder.Build();



app.UseCors();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();

    app.MapScalarApiReference();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();



app.Run();
