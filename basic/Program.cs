var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.AddAuthentication("Cookie Authentication")
                .AddCookie("Cookie Authentication", c => {
                    c.LoginPath = "/Home/Authenticate";
                    c.Cookie.Name = "Granny.Cookie";
                });

var app = builder.Build();

app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();

app.UseEndpoints(endpoints => {
    endpoints.MapDefaultControllerRoute();
});

app.Run();
