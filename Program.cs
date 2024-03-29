using Microsoft.EntityFrameworkCore;
using ToDo.DAL;
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
    builder.Services.AddSingleton<ITodoRepository, InMemoryTodoRepository>();
if (storageType == DataStorageTypeEnum.InXmlFile.ToString())
    builder.Services.AddScoped<ITodoRepository, InXmlFileTodoRepository>();
if (storageType == DataStorageTypeEnum.InJsonFile.ToString())
    builder.Services.AddScoped<ITodoRepository, InJsonFileTodoRepository>();
if (storageType == DataStorageTypeEnum.InDb.ToString())
    builder.Services.AddScoped<ITodoRepository, InDbTodoRepository>();

builder.Services.AddScoped<ITodoService, TodoService>();

//db configuration
var connection = builder.Configuration.GetConnectionString("default");
builder.Services.AddDbContext<AppDBContext>(options => options
    .UseSqlServer(connection));

var app = builder.Build();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Todo}/{action=List}/{id?}");

app.Run();