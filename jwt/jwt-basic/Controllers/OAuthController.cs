using Microsoft.AspNetCore.Mvc;

namespace jwt_basic.Controllers
{
    public class OAuthController : Controller
    {
        [HttpGet]
        public IActionResult Authorize()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Authorize(string username)
        {
            return View();
        }

        public IActionResult Token()
        {
            return View();
        }
    }
}