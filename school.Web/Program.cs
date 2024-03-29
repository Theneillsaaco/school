using Microsoft.EntityFrameworkCore;
using School.DAL.Context;
using School.DAL.Dao;
using School.DAL.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

#region "Registro del contexto"
builder.Services.AddDbContext<SchoolContext>(options =>
                           options.UseSqlServer(builder.Configuration.GetConnectionString("SchoolContext")));

#endregion

#region "Registro de Componentes Daos"

builder.Services.AddTransient<IDaoDepartment, DaoDepartment>();
builder.Services.AddTransient<IDaoCourse, DaoCourse>();
builder.Services.AddTransient<IDaoOnlineCourse, DaoOnlineCourse>();
builder.Services.AddTransient<IDaoStudent, DaoStudent>();
builder.Services.AddTransient<IDaoInstructor, DaoInstructor>();

#endregion


builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();