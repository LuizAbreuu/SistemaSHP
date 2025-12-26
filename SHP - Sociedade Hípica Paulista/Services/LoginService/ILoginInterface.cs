using SHP___Sociedade_Hípica_Paulista.Dto;
using SHP___Sociedade_Hípica_Paulista.Models;

namespace SHP___Sociedade_Hípica_Paulista.Services.LoginService
{
    public interface ILoginInterface
    {

        Task<ResponseModel<UsuarioModel>> RegistrarUsuario(UsuarioRegisterDto usuarioRegisterDto);
        Task<ResponseModel<UsuarioModel>> Login(UsuarioLoginDto usuarioLoginDto);
    }
}
