using Domain;
using Domain.OwnerTypeD;
using Genius.Domain;
using Genius.Infraestructure;
using Infraestructure;
using Infraestructure.Context;
using Infraestructure.OwnerType;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Customizado
builder.Services.AddScoped<IDriverDomain, DriverDomain>();
builder.Services.AddScoped<IDriverInfraestructure, DriverInfraestructure>();

builder.Services.AddScoped<ICarDomain, CarDomain>();
builder.Services.AddScoped<ICarInfraestructure, CarInfraestructure>();




builder.Services.AddScoped<IOwnerInfraestructure, OwnerParkInfra>();
builder.Services.AddScoped<IOwnerDomain, OwnerDomain>();
builder.Services.AddScoped<IParkingInfraestructure, ParkingInfra>();
builder.Services.AddScoped<IParkingDomain, ParkingDomain>();
builder.Services.AddScoped<IRentInfraestructure, RentInfra>();
builder.Services.AddScoped<IRentDomain, RentDomain>();
builder.Services.AddScoped<IOwnerTypeInfra, OwnerTypeInfra>();
builder.Services.AddScoped<IOwnerTypeDomain, OwnerTypeDomain>();

//MySQL Connection
var connectionString = builder.Configuration.GetConnectionString("geniusConnection");
var serverVersion = new MySqlServerVersion(new Version(8, 0, 29));

builder.Services.AddDbContext<GeniusDBContext>(
    dbContextOptions =>
    {
        dbContextOptions.UseMySql(connectionString,
            ServerVersion.AutoDetect(connectionString),
            options => options.EnableRetryOnFailure(
                maxRetryCount: 5,
                maxRetryDelay: System.TimeSpan.FromSeconds(30),
                errorNumbersToAdd: null));
    }
    );

var app = builder.Build();

using (var scope = app.Services.CreateScope())
using (var context = scope.ServiceProvider.GetService<GeniusDBContext>())
{
    context.Database.EnsureCreated();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();