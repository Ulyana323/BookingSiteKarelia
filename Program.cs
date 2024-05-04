using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using WebApplication3.Models;    // пространство имен класса ApplicationContext

var builder = WebApplication.CreateBuilder(args);

// получаем строку подключени€ из файла конфигурации
string connection = builder.Configuration.GetConnectionString("DefaultConnection");
string connection2 = builder.Configuration.GetConnectionString("DefaultConnection2");
string connection3 = builder.Configuration.GetConnectionString("DefaultConnection3");



// добавл€ем контекст ApplicationContext в качестве сервиса в приложение
//добавление контекста базы данных ApplicationContext как сервиса в приложение,
//использу€ строку подключени€ connection.

builder.Services.AddDbContext<ApplicationContext>(options => options.UseSqlServer(connection));
builder.Services.AddDbContext<ApplicationContext2>(options => options.UseSqlServer(connection2));
builder.Services.AddDbContext<ApplicationContext3>(options => options.UseSqlServer(connection3));

builder.Services.AddRazorPages();
//добавление поддержки Razor Pages как сервиса в приложение.

var app = builder.Build();


app.UseStaticFiles();// добавление обработчика статических файлов в приложение.

app.MapRazorPages();//в приложении происходит настройка маршрутизации,
                    //котора€ позвол€ет обрабатывать запросы к страницам Razor Pages.

app.Run();