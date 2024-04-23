using MassTransit;
using Microsoft.EntityFrameworkCore;
using Spg.RabbitMqDemo.Application;
using Spg.RabbitMqDemo.Application.BookingApi;
using Spg.RabbitMqDemo.DomainModel.Interfaces;
using Spg.RabbitMqDemo.DomainModel.Model.Settings;
using Spg.RabbitMqDemo.Infrastructure.BookingApi;
using Spg.RabbitMqDemo.Repository.BookingApi;
using System.Reflection;

Console.WriteLine("B O O K I N G S - D A T A B A S E");
Console.WriteLine("=================================");

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configure DB-Context
builder.Services.AddDbContext<BookingDatabase>(options => {
    if (!options.IsConfigured)
    {
        options.UseSqlite("Data Source = .\\..\\..\\Bookings.db");
    }
});

// Configure Services
builder.Services.AddTransient<IAvailableFlightService, AvailableFlightService>();
builder.Services.AddTransient<IAvailableFlightRepository, AvailableFlightRepository>();
builder.Services.AddTransient<IIdentifierService, IdentifierService>();

// Configure Rabbit-MQ-Client
var serviceSettings = builder.Configuration.GetSection(nameof(ServiceSettings)).Get<ServiceSettings>();
var rabbitMQ = builder.Configuration.GetSection("RabbitMqSettings");
builder.Services.AddMassTransit(busConfigurator =>
{
    var entryAssembly = Assembly.GetExecutingAssembly();
    busConfigurator.AddConsumers(entryAssembly);
    busConfigurator.UsingRabbitMq((context, busFactoryConfigurator) =>
    {
        var rabbitMqSettings = builder.Configuration.GetSection(nameof(RabbitMqSettings)).Get<RabbitMqSettings>();
        busFactoryConfigurator.Host(rabbitMqSettings?.Host, "/", h => { });
        busFactoryConfigurator.ConfigureEndpoints(context, 
            new KebabCaseEndpointNameFormatter(serviceSettings?.ServiceName ?? "", false));
    });
});

var app = builder.Build();


// ** DB Seeding Hard Coded (Bad Code) **
DbContextOptionsBuilder dbContextOptionsBuilder = new DbContextOptionsBuilder();
dbContextOptionsBuilder.UseSqlite("Data Source = .\\..\\..\\Bookings.db");
BookingDatabase _db = new BookingDatabase(dbContextOptionsBuilder.Options);
_db.Database.EnsureDeleted();
_db.Database.EnsureCreated();
// ** DB Seeding Hard Coded **


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
