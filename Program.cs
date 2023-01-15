using ToDo.Enums;
using ToDo.Repositories;
using ToDo.Repositories.Implementation;
using ToDo.Services;
using ToDo.Services.Implementation;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var storageType = builder.Configuration.GetSection("StorageType").Value;

if (storageType == DataStorageTypeEnum.InMemory.ToString())
{
    builder.Services.AddSingleton<IToDoRepository, InMemoryToDoRepository>();
}

if (storageType == DataStorageTypeEnum.InXmlFile.ToString())
{
    builder.Services.AddScoped<IToDoRepository, InXmlFileToDoRepository>();
}

if (storageType == DataStorageTypeEnum.InJsonFile.ToString())
{
    builder.Services.AddScoped<IToDoRepository, InJsonFileToDoRepository>();
}


builder.Services.AddScoped<ITodoService, TodoService>();

var app = builder.Build();




app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Todo}/{action=List}/{id?}");

app.Run();
