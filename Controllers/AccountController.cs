using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Threading.Tasks;
using catalogoMVC.Models;
using System.Linq;

namespace catalogoMVC.Controllers
{
    public class AccountController : Controller
    {
        private readonly ProductDbContext _context;

        public AccountController(ProductDbContext context)
        {
            _context = context;
        }

        // Exibe a tela de login
        public IActionResult Login()
        {
            return View();
        }

        // Processa o login
        [HttpPost]
        public async Task<IActionResult> Login(string username, string password)
        {
            // Verifica se o usuário e senha existem no banco de dados
            var user = _context.Users.FirstOrDefault(u => u.Username == username && u.Password == password);
            if (user != null)
            {
                // Cria a identidade do usuário
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.Username),
                    new Claim("IsAdmin", user.IsAdmin.ToString())  // Verifica se é administrador
                };

                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));

                return RedirectToAction("Index", "Home");  // Redireciona após login
            }

            // Se o login falhar
            ViewBag.Error = "Usuário ou senha inválidos";
            return View();
        }

        // Processa o logout
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login", "Account");
        }
    }
}
