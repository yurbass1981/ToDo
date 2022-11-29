using Microsoft.DotNet.Scaffolding.Shared.ProjectModel;
using ToDo.Services;
using ToDo.Services.Implemention;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IToDoService, ToDoService>();

var app = builder.Build();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=ToDo}/{action=List}/{id?}");

app.Run();
