using System.Text.Json;
using Microsoft.EntityFrameworkCore;
using Npgsql;
using src.Entity;
using src.Database;
using src.Utils;
using src.Services.category;
using src.Services.review;
using src.Services.cart;
using src.Repository;
using src.Services.User;
using src.Services.Address;

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

// add DI services for category
builder.Services
     .AddScoped<ICategoryService, CategoryService>()
     .AddScoped<CategoryRepository, CategoryRepository>();

// add DI services for review
builder.Services
     .AddScoped<IReviewService, ReviewService>()
     .AddScoped<ReviewRepository, ReviewRepository>();

// add DI services for cart
builder.Services
     .AddScoped<ICartService, CartService>()
     .AddScoped<CartRepository, CartRepository>();

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
