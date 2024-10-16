var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Task/Error"); // Redirect to a relevant error page.
    app.UseHsts();  // Enforce HSTS for security in production.
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();  // Keep for future authorization if needed.

// Update the default route to point to TaskController's Index method.
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Task}/{action=Index}/{id?}"); // Default to TaskController

app.Run();
