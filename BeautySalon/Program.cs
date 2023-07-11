using BeautySalon.DataBase;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// us�ugi do kontenera.
builder.Services.AddControllersWithViews();

// konfiguracj� bazy danych
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<BeautySalonDbContext>(options =>
    options.UseSqlServer(connectionString));

var app = builder.Build();

// Konfiguruj potok ��dania HTTP.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // Warto�� HSTS domy�lnie wynosi 30 dni. Mo�esz to zmieni� w scenariuszach produkcyjnych, patrz https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "services",
    pattern: "Services",
    defaults: new { controller = "Services", action = "Services" }
);

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");


app.Run();