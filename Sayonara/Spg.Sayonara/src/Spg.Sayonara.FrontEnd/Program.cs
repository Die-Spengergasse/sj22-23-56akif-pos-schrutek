using Bogus;
using Microsoft.AspNetCore.Localization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Spg.Sayonara.Application.Servcies;
using Spg.Sayonara.Infrastructure;
using Spg.Sayonara.Repository;
using System.Globalization;

var builder = WebApplication.CreateBuilder(args);

string connectionString = builder.Configuration.GetConnectionString("sqlite")!;

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<SayonaraContext>(o =>
{
    o.UseSqlite(connectionString);
});

builder.Services.AddTransient<ShopRepository>();
builder.Services.AddTransient<ShopService>();

builder.Services.AddTransient(r => new ProductRepository(null!, 5));

// I18n / L10n
// https://code-maze.com/aspnetcore-localization/
builder.Services.AddLocalization(options => options.ResourcesPath = "Resources");
const string defaultCulture = "en-GB";
var supportedCultures = new[]
{
    new CultureInfo(defaultCulture),
    new CultureInfo("de")
};
builder.Services.Configure<RequestLocalizationOptions>(options => {
    options.DefaultRequestCulture = new RequestCulture(defaultCulture);
    options.SupportedCultures = supportedCultures;
    options.SupportedUICultures = supportedCultures;
});
// --

WebApplication app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

// I18n / L10n
app.UseRequestLocalization(app.Services.GetRequiredService<IOptions<RequestLocalizationOptions>>().Value);
// --

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
