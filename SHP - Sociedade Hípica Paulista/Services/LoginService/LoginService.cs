using SHP___Sociedade_Hípica_Paulista.Data;
using SHP___Sociedade_Hípica_Paulista.Dto;
using SHP___Sociedade_Hípica_Paulista.Models;
using SHP___Sociedade_Hípica_Paulista.Services.SenhaService;

namespace SHP___Sociedade_Hípica_Paulista.Services.LoginService
{
    public class LoginService : ILoginInterface
    {

        private readonly ApplicationDbContext _context;
        private readonly ISenhaInterface _senhaService;
        public LoginService(ApplicationDbContext context, ISenhaInterface SenhaService)
        {
            _context = context;
            _senhaService = SenhaService;
        }

        public async Task<ResponseModel<UsuarioModel>> RegistrarUsuario(UsuarioRegisterDto usuarioRegisterDto)
        {

            ResponseModel<UsuarioModel> response = new ResponseModel<UsuarioModel>();

            try
            {
                if (VerificarSeEmailExiste(usuarioRegisterDto))
                {
                    response.Mensagem = "Email já cadastrado!";
                    response.Status = false;    
                    return response;
                }

                _senhaService.CriarSenhaHash(usuarioRegisterDto.Senha, out byte[] senhaHash, out byte[] senhaSalt);

                var usuario = new UsuarioModel()
                {
                    Nome = usuarioRegisterDto.Nome,
                    Sobrenome = usuarioRegisterDto.Sobrenome,
                    Email = usuarioRegisterDto.Email,
                    SenhaHash = senhaHash,
                    SenhaSalt = senhaSalt
                };

                _context.Add(usuario);
                await  _context.SaveChangesAsync();

                response.Mensagem = "Usuário cadastrado com sucesso!";
                return response;

            }
            catch (Exception ex)
            {

                response.Mensagem = ex.Message;
                response.Status = false;
                return response;
            }
        }

        private bool VerificarSeEmailExiste(UsuarioRegisterDto usuarioRegisterDto)
        {
            var usuario = _context.Usuarios.FirstOrDefault(x => x.Email == usuarioRegisterDto.Email);

            if (usuario == null)
            {
                return false;
            }
            return true;
        }

    }
}

