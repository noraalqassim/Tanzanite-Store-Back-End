using System.Text.Json;
using Microsoft.EntityFrameworkCore;
using Npgsql;
using src.Database;
using src.Entity;
using src.Repository;
using src.Services.Address;
using src.Services.User;
using src.Utils;

var builder = WebApplication.CreateBuilder(args);

var dataSourceBuilder = new NpgsqlDataSourceBuilder(
    builder.Configuration.GetConnectionString("Local")
);

builder.Services.AddDbContext<DatabaseContext>(options =>
{
    options.UseNpgsql(dataSourceBuilder.Build());
});

builder.Services.AddAutoMapper(typeof(MapperProfile).Assembly);

///user
builder
    .Services.AddScoped<IUserService, UserService>()
    .AddScoped<UserRepository, UserRepository>();

///Address
builder
    .Services.AddScoped<IAddressService, AddressService>()
    .AddScoped<AddressRepository, AddressRepository>();

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<DatabaseContext>();

    try
    {
        // Check if the application can connect to the database
        if (dbContext.Database.CanConnect())
        {
            Console.WriteLine("Database is connected");
        }
        else
        {
            Console.WriteLine("Unable to connect to the database.");
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Database connection failed: {ex.Message}");
    }
}

app.MapControllers();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.Run();
