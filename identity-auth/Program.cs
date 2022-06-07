using Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(config => config.UseInMemoryDatabase("InMemDb"));

builder.Services.AddIdentity<IdentityUser, IdentityRole>(config => {
                    config.Password.RequiredLength = 4;
                    config.Password.RequireDigit = false;
                    config.Password.RequireUppercase = false;
                    config.Password.RequireNonAlphanumeric = false;
                })
                .AddEntityFrameworkStores<AppDbContext>()
                .AddDefaultTokenProviders();

builder.Services.ConfigureApplicationCookie(config => {
    config.Cookie.Name = "Identity.Cookie";
    config.LoginPath = "/Home/Login";
});

builder.Services.AddControllersWithViews();

var app = builder.Build();

app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();

app.UseEndpoints(endpoints => {
    endpoints.MapDefaultControllerRoute();
});

app.Run();
