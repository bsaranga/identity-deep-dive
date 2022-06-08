using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using jwt_basic;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [Authorize]
        public IActionResult Secret()
        {
            return View();
        }

        public IActionResult Authenticate()
        {
            var claims = new[] {
                new Claim(JwtRegisteredClaimNames.Sub, "45sdf4-f5s6df4s-f45sdf"),
                new Claim(JwtRegisteredClaimNames.Gender, "Male")
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Constants.Secret));
            var algorithm = SecurityAlgorithms.HmacSha256;

            var signingCredentials = new SigningCredentials(key, algorithm);

            var token = new JwtSecurityToken(Constants.Issuer, Constants.Issuer, claims, DateTime.Now, DateTime.Now.AddDays(1), signingCredentials);

            var tokenJson = new JwtSecurityTokenHandler().WriteToken(token);

            return Ok(new { access_token = tokenJson });
        }

        public IActionResult DecodeJwt(string jwt)
        {
            var jwtComponents = jwt.Split('.');
            
            var header = Encoding.UTF8.GetString(Convert.FromBase64String(jwtComponents[0]));
            var body = Encoding.UTF8.GetString(Convert.FromBase64String(jwtComponents[1]));

            return Ok(new {
                Header = header,
                Payload = body
            });
        }
    }
}