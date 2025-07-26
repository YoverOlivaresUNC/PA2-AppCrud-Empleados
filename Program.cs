using Microsoft.EntityFrameworkCore;
using AppCrud.Data;

var builder = WebApplication.CreateBuilder(args);

// Configurar Entity Framework
builder.Services.AddDbContext<AppDBcontext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Agregar servicios MVC
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configurar pipeline de requests
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Empleados}/{action=Index}/{id?}");

// Aplicar migraciones automáticamente al iniciar la aplicación
using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<AppDBcontext>();
    context.Database.EnsureCreated();
}

app.Run();