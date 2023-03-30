using System.Reflection;
using FluentMigrator.Runner;
using ImportApp.Context;
using ImportApp.Extensions;
using ImportApp.Migrations;
using ImportApp.Repositories;
using ImportApp.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddSingleton<DapperContext>(); 
builder.Services.AddSingleton<Database>();
builder.Services.AddScoped<IUploadService, UploadService>();
builder.Services.AddScoped<IPersonnelRepository, PersonnelRepository>();

builder.Services.AddLogging(c => c.AddFluentMigratorConsole())
    .AddFluentMigratorCore()
    .ConfigureRunner(c => c.AddSqlServer2012()
        .WithGlobalConnectionString(builder.Configuration.GetConnectionString("SqlConnection"))
        .ScanIn(Assembly.GetExecutingAssembly()).For.Migrations());

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.MigrateDatabase();
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    "default",
    "{controller=Upload}/{action=Index}");
app.Run();