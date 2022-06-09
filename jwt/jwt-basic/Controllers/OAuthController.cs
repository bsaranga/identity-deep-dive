using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace jwt_basic.Controllers
{
    public class OAuthController : Controller
    {
        [HttpGet]
        public IActionResult Authorize(string response_type, string client_id, string redirect_uri, string scope, string state)
        {
            var query = new QueryBuilder();
            query.Add("redirectUri", redirect_uri);
            query.Add("state", state);

            return View(model: query.ToString());
        }

        [HttpPost]
        public IActionResult Authorize(string username, string redirect_uri, string state)
        {
            const string code = "65df65sd45s4a5sd45as4d5as21das5d";
            return Redirect($"{redirect_uri}");
        }

        public IActionResult Token()
        {
            return View();
        }
    }
}