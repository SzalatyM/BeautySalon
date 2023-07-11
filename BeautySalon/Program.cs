using BeautySalon.DataBase;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// us³ugi do kontenera.
builder.Services.AddControllersWithViews();

// konfiguracjê bazy danych
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<BeautySalonDbContext>(options =>
    options.UseSqlServer(connectionString));

var app = builder.Build();

// Konfiguruj potok ¿¹dania HTTP.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // Wartoœæ HSTS domyœlnie wynosi 30 dni. Mo¿esz to zmieniæ w scenariuszach produkcyjnych, patrz https://aka.ms/aspnetcore-hsts.
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