using Microsoft.EntityFrameworkCore;
using OtoServis.Data;
using OtoServis.Data.Abstract;
using OtoServis.Entities.Models;
using OtoServis.Service.Abstract;
using OtoServis.Service.Concrete;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Reflection;
using System.Security.Claims;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<AppDbContext>();
builder.Services.AddTransient(typeof(IServiceRepository<>),typeof(ServiceRepository<>));
builder.Services.AddTransient<ICarService,CarService>();
builder.Services.AddTransient<IUserService,UserService>();
builder.Services.AddTransient<ICustomerService,CustomerService>();
builder.Services.AddTransient<ISalesService,SalesService>();

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(x =>
{
    x.LoginPath = "/Accounts/Login";
    x.LogoutPath = "/Accounts/Logout";
    x.AccessDeniedPath = "/AccessDenied";
    x.Cookie.Name = "Admin";
    x.Cookie.MaxAge = TimeSpan.FromDays(7);
    x.Cookie.IsEssential = true;
});

builder.Services.AddAuthorization(x =>
{
    x.AddPolicy("AdminPolicy", policy => policy.RequireClaim(ClaimTypes.Role, "Admin"));
    x.AddPolicy("UserPolicy", policy => policy.RequireClaim(ClaimTypes.Role,"Admin", "User"));
    x.AddPolicy("CustomerPolicy", policy => policy.RequireClaim(ClaimTypes.Role, "Admin", "User","Customer"));
});


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


app.UseStatusCodePagesWithReExecute("/ErrorPage/Error404", "?code={0}");
app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
            name: "admin",
            pattern: "{area:exists}/{controller=Main}/{action=Index}/{id?}");
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
