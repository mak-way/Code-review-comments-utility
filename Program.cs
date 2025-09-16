using MySqlConnector;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddTransient<MySqlConnection>(_ =>
    new MySqlConnection(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();  // Add this to serve static assets like CSS, JS, images properly.

app.UseRouting();

app.UseAuthorization();

// Remove or adjust 'app.MapStaticAssets()' if it's custom or not needed.
// If this is a custom extension method, ensure it exists; otherwise remove it.

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Projects}/{action=SelectProject}/{id?}");

// Optional: Add fallback route or default app route if you want a default landing page for Home/Index
// app.MapControllerRoute(
//     name: "default-home",
//     pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
