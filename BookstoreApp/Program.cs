
using Microsoft.EntityFrameworkCore;
using BookstoreApp.Data;
using Microsoft.Extensions.DependencyInjection;
using BookstoreApp.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<BookstoreAppContext>(options =>

    options.UseSqlite(builder.Configuration.GetConnectionString("BookstoreAppContext") ?? throw new InvalidOperationException("Connection string 'BookstoreAppContext' not found.")));

// Add services to the container.
builder.Services.AddControllersWithViews();

//Register BookstoreContext with SQLite
builder.Services.AddDbContext<BookstoreContext>(options =>
options.UseSqlite(builder.Configuration.GetConnectionString("BookstoreConnection")));

builder.Services.AddSingleton<IUserAuthenticationService, SimpleAuthenticationService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();


app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");


app.Run();

