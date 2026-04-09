using Microsoft.AspNetCore.Mvc;
using SHP___Sociedade_Hípica_Paulista.Dto;
using SHP___Sociedade_Hípica_Paulista.Services.LoginService;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Threading.Tasks;

namespace SHP___Sociedade_Hípica_Paulista.Controllers
{
    public class LoginController : Controller
    {
        private readonly ILoginInterface _loginInterface;
        public LoginController(ILoginInterface loginInterface)
        {
            _loginInterface = loginInterface;
        }

        public IActionResult Login()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login");
        }

        public IActionResult Registrar()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Registrar(UsuarioRegisterDto usuarioRegisterDto)
        {
            if (ModelState.IsValid)
            {
                var usuario = await _loginInterface.RegistrarUsuario(usuarioRegisterDto);

                if (usuario.Status)
                {
                    TempData["MensagemSucesso"] = usuario.Mensagem;

                }
                else
                {
                    TempData["MensagemErro"] = usuario.Mensagem;
                    return View(usuarioRegisterDto);
                }

                return RedirectToAction("Index");
            }
            else
            {
                return View(usuarioRegisterDto);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Login(UsuarioLoginDto usuarioLoginDto)
        {

            if (ModelState.IsValid)
            {

                var usuario = await _loginInterface.Login(usuarioLoginDto);
                if (usuario.Status && usuario.Dados != null)
                {
                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.NameIdentifier, usuario.Dados.Id.ToString()),
                        new Claim(ClaimTypes.Name, usuario.Dados.Nome),
                        new Claim(ClaimTypes.Email, usuario.Dados.Email)
                    };

                    var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    var principal = new ClaimsPrincipal(identity);

                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

                    TempData["MensagemSucesso"] = usuario.Mensagem;
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    TempData["MensagemErro"] = usuario.Mensagem;
                    return View(usuarioLoginDto);
                }
            }
            else 
            {
                return View(usuarioLoginDto);
            }
        }
    }
}
