using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using WebApplication3.Models;    // ������������ ���� ������ ApplicationContext

var builder = WebApplication.CreateBuilder(args);

// �������� ������ ����������� �� ����� ������������
string connection = builder.Configuration.GetConnectionString("DefaultConnection");
string connection2 = builder.Configuration.GetConnectionString("DefaultConnection2");
string connection3 = builder.Configuration.GetConnectionString("DefaultConnection3");



// ��������� �������� ApplicationContext � �������� ������� � ����������
//���������� ��������� ���� ������ ApplicationContext ��� ������� � ����������,
//��������� ������ ����������� connection.

builder.Services.AddDbContext<ApplicationContext>(options => options.UseSqlServer(connection));
builder.Services.AddDbContext<ApplicationContext2>(options => options.UseSqlServer(connection2));
builder.Services.AddDbContext<ApplicationContext3>(options => options.UseSqlServer(connection3));

builder.Services.AddRazorPages();
//���������� ��������� Razor Pages ��� ������� � ����������.

var app = builder.Build();


app.UseStaticFiles();// ���������� ����������� ����������� ������ � ����������.

app.MapRazorPages();//� ���������� ���������� ��������� �������������,
                    //������� ��������� ������������ ������� � ��������� Razor Pages.

app.Run();