using Microsoft.DotNet.Scaffolding.Shared.ProjectModel;
using ToDo.Repositories;
using ToDo.Repositories.Implemention;
using ToDo.Services;
using ToDo.Services.Implemention;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IToDoService, ToDoService>();


var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    builder.Services.AddScoped<IToDoRepository, InMemoryToDoRepository>();
}
else 
{
    builder.Services.AddScoped<IToDoRepository, InFileToDoRepository>();
}

app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=ToDo}/{action=List}/{id?}");

app.Run();
