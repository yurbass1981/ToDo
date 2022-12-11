using ToDo.Repositories;
using ToDo.Repositories.Implemention;
using ToDo.Services;
using ToDo.Services.Implemention;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var storageType = builder.Configuration.GetSection("StorageType").Value;
if (storageType == "InMemory")
{
    builder.Services.AddSingleton<IToDoRepository, InMemoryToDoRepository>();
}

if (storageType == "InFile")
{
    builder.Services.AddScoped<IToDoRepository, InFileToDoRepository>();
}


builder.Services.AddScoped<IToDoService, ToDoService>();

var app = builder.Build();




app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=ToDo}/{action=List}/{id?}");

app.Run();
