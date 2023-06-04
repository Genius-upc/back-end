using Domain;
using Infraestructure;
using Infraestructure.Context;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Customizado
builder.Services.AddScoped<IOwnerInfraestructure, OwnerParkInfra>();
builder.Services.AddScoped<IOwnerDomain, OwnerDomain>();
builder.Services.AddScoped<IParkingInfraestructure, ParkingInfra>();
builder.Services.AddScoped<IParkingDomain, ParkingDomain>();
builder.Services.AddScoped<IRentInfraestructure, RentInfra>();
builder.Services.AddScoped<IRentDomain, RentDomain>();

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