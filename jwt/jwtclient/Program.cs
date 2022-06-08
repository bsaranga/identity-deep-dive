var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAuthentication(config => {
    config.DefaultAuthenticateScheme = "ClientCookie";
    config.DefaultSignInScheme = "ClientCookier";
    config.DefaultChallengeScheme = "OurServer";
})
                .AddCookie("ClientCookie")
                .AddOAuth("OurServer", config => {
                    config.ClientId = "my-client";
                    config.ClientSecret = "d566f5sd6f-54df35wf-545df4s";
                    config.AuthorizationEndpoint = "http://localhost:5001/oauth/authorize";
                    config.TokenEndpoint = "http://localhost:5001/oauth/token";
                    config.CallbackPath = "oauth/callback";
                });

builder.Services.AddControllersWithViews();

var app = builder.Build();

app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();

app.UseEndpoints(endpoints => endpoints.MapDefaultControllerRoute());

app.Run();