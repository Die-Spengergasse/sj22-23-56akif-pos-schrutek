using MediatR;
using Microsoft.EntityFrameworkCore;
using Spg.Sayonara.Application.Servcies;
using Spg.Sayonara.Application.UseCases.Shop.Queries;
using Spg.Sayonara.DomainModel.Dtos;
using Spg.Sayonara.DomainModel.Interfaces;
using Spg.Sayonara.Infrastructure;
using Spg.Sayonara.Repository;
using System.Reflection;

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

builder.Services.AddTransient<IDateTimeService, DateTimeService>();

builder.Services.AddTransient<IReadOnlyShopService, ShopService>();
builder.Services.AddTransient<IReadOnlyProductService, ProductService>();
builder.Services.AddTransient<IWritableProductService, ProductService>();

builder.Services.AddTransient<IReadOnlyShopRepository, ShopRepository>();
builder.Services.AddTransient<IReadOnlyCategoryRepository, CategoryRepository>();
builder.Services.AddTransient<IReadOnlyProductRepository, ProductRepository>();
builder.Services.AddTransient<IWritableProductRepository, ProductRepository>();

builder.Services.AddTransient<IGuidService, GuidService>();

builder.Services.AddMediatR(o => o.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
builder.Services.AddTransient<IRequestHandler<GetShopsFilteredModel, IQueryable<ShopDto>>, GetShopsFilteredHandler>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
