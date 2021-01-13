using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using GastonCardenasBlogEngine.test.Web.Models.Login;

namespace GastonCardenasBlogEngine.test.Web.Controllers
{
    public class SecurityController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginInputModel model)
        {
            if (ModelState.IsValid)
            {
                switch (model.Username.ToLower())
                {
                    case "viewer":
                        await AuthenticateUser(model.Username, "User");
                        return RedirectToAction("Index", "Home");
                    case "editor":
                        await AuthenticateUser(model.Username, "Editor");
                        return RedirectToAction("Index", "Publish", new { Area = "PublishFlow" });
                    case "writer":
                        await AuthenticateUser(model.Username, "Writer");
                        return RedirectToAction("Index", "Publish", new { Area = "PublishFlow" });
                    default:
                        ModelState.AddModelError("Login", "Invalid user or password");
                        break;
                }
            }

            return View(model);
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();

            return Redirect("/");
        }

        private async Task AuthenticateUser(string user, string role)
        {
            var claims = new List<Claim>
                        {
                            new Claim(ClaimTypes.Name, user)
                        };

            claims.Add(new Claim(ClaimTypes.Role, role));

            var claimsIdentity = new ClaimsIdentity(
                            claims, CookieAuthenticationDefaults.AuthenticationScheme);

            var authProperties = new AuthenticationProperties
            {
                RedirectUri = "/"
            };

            await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(claimsIdentity),
                    authProperties);
        }
    }
}
