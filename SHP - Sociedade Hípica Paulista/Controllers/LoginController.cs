using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using SistemaSHP.Application.DTOs;
using SistemaSHP.Application.Interfaces;
using System.Security.Claims;
using System.Threading.Tasks;

namespace SHP___Sociedade_Hípica_Paulista.Controllers
{
    public class LoginController : Controller
    {
        private readonly ILoginInterface _loginService;

        public LoginController(ILoginInterface loginService)
        {
            _loginService = loginService;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginRequest request)
        {
            if (ModelState.IsValid)
            {
                var sucesso = await _loginService.Login(request);

                if (sucesso)
                {
                    var claims = new System.Collections.Generic.List<Claim>
                    {
                        new Claim(ClaimTypes.Name, request.Email),
                        new Claim(ClaimTypes.Email, request.Email)
                    };

                    var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    var principal = new ClaimsPrincipal(identity);

                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

                    return RedirectToAction("Index", "NotebookDesktop");
                }
                
                TempData["MensagemErro"] = "Email ou senha incorretos!";
            }
            
            return View(request);
        }

        [HttpGet]
        public IActionResult Registrar()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Registrar(UsuarioRegisterDto request)
        {
            if (ModelState.IsValid)
            {
                var resultado = await _loginService.RegistrarUsuario(request);

                if (resultado.Status)
                {
                    TempData["MensagemSucesso"] = resultado.Mensagem;
                    return RedirectToAction("Login");
                }
                
                TempData["MensagemErro"] = resultado.Mensagem;
            }
            return View(request);
        }

        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login");
        }
    }
}
