using MassTransit;
using Microsoft.EntityFrameworkCore;
using Spg.RabbitMqDemo.Application;
using Spg.RabbitMqDemo.DomainModel.Interfaces;
using Spg.RabbitMqDemo.DomainModel.Model.Settings;
using Spg.RabbitMqDemo.Infrastructure.FlightApi;
using Spg.RabbitMqDemo.Repository;
using Spg.RabbitMqDemo.Repository.FlightApi;

Console.WriteLine("F L I G H T S - D A T A B A S E");
Console.WriteLine("===============================");

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configure DB-Context
builder.Services.AddDbContext<FlightDatabase>(options => {
    if (!options.IsConfigured)
    {
        options.UseSqlite("Data Source = .\\..\\..\\Flights.db");
    }
});

// Configure Services
builder.Services.AddTransient<IDestinationLookupRepository, DestinationLookupRepository>();
builder.Services.AddTransient<IFlightRepository, FlightRepository>();
builder.Services.AddTransient<IRabbitMqRepository, RabbitMqRepository>();
builder.Services.AddTransient<IIdentifierService, IdentifierService>();

// Configure Rabbit-MQ-Broker
var serviceSettings = builder.Configuration.GetSection(nameof(ServiceSettings)).Get<ServiceSettings>();
var rabbitMQ = builder.Configuration.GetSection("RabbitMqSettings");
builder.Services.AddMassTransit(options => {
    options.UsingRabbitMq((context, configurator) =>
    {
        var rabbitMqSettings = builder.Configuration.GetSection(nameof(RabbitMqSettings)).Get<RabbitMqSettings>();
        configurator.Host(rabbitMqSettings?.Host, host =>
        {
            host.Username(builder.Configuration.GetValue("RabbitMqSettings:Username", "admin"));
            host.Password(builder.Configuration.GetValue("RabbitMqSettings:Password", "admin"));
        });
        configurator.ConfigureEndpoints(context, 
            new KebabCaseEndpointNameFormatter(serviceSettings?.ServiceName ?? "", false));
    });
});

var app = builder.Build();


// ** DB Seeding Hard Coded (Bad Code) **
DbContextOptionsBuilder dbContextOptionsBuilder = new DbContextOptionsBuilder();
dbContextOptionsBuilder.UseSqlite("Data Source = .\\..\\..\\Flights.db");
FlightDatabase _db = new FlightDatabase(dbContextOptionsBuilder.Options);
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
app.MapControllers();

app.Run();
