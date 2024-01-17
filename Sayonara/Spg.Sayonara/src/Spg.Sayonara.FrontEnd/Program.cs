using Bogus;
using Microsoft.EntityFrameworkCore;
using Spg.Sayonara.Infrastructure;
using Spg.Sayonara.Repository;

var builder = WebApplication.CreateBuilder(args);

string connectionString = builder.Configuration.GetConnectionString("sqlite")!;

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<SayonaraContext>(o =>
{
    o.UseSqlite(connectionString);
});

builder.Services.AddScoped(r => new ProductRepository(null!, 5));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
