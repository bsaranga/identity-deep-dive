using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

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
            var grannyClaims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name, "Bob"),
                new Claim(ClaimTypes.Email, "bob@gmail.com"),
                new Claim("Description", "Very good child."),
            };

            var governmentClaims = new List<Claim>()
            {
                new Claim("LicenseNumber", "5sd6f5s6d5f6sfd"),
                new Claim("IdentityNumber", "6548-546-454-4545")
            };

            var grannyIdentity = new ClaimsIdentity(grannyClaims, "Granny Identity");
            var governmentIdentity = new ClaimsIdentity(governmentClaims, "Government Identity");

            var userPrincipal = new ClaimsPrincipal(new [] { grannyIdentity, governmentIdentity });
            
            HttpContext.SignInAsync(userPrincipal);

            return RedirectToAction("Index");
        }
    }
}