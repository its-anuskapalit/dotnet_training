using MiddlewareDemo.Middleware;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
var app = builder.Build();
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseMiddleware<QueryBlockMiddleware>();

app.UseRouting();
//Step-2
// Custom middleware: blocks a token in query parameter "q"

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();