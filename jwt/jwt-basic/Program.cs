using System.Text;
using jwt_basic;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAuthentication("OAuth")
                .AddJwtBearer("OAuth", config => {
                    config.TokenValidationParameters = new TokenValidationParameters()
                    {
                      IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Constants.Secret)),
                      ValidIssuer = Constants.Issuer,
                      ValidAudience = Constants.Audience
                    };
                });

builder.Services.AddControllersWithViews();

var app = builder.Build();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.UseEndpoints(endpoints => endpoints.MapDefaultControllerRoute());

app.Run();
