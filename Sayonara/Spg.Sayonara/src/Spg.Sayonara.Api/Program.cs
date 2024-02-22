using Microsoft.EntityFrameworkCore;
using Spg.Sayonara.Application.Servcies;
using Spg.Sayonara.Infrastructure;
using Spg.Sayonara.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

string? connectionString = builder.Configuration.GetConnectionString("sqlite");

builder.Services.AddDbContext<SayonaraContext>(options => 
{
    if (!options.IsConfigured)
    {
        options.UseSqlite(connectionString);
    }
});

builder.Services.AddTransient<ShopService>();
builder.Services.AddTransient<ShopRepository>();

var app = builder.Build();

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
