using SistemaSHP.Application.DTOs;
using SistemaSHP.Domain.Entities;
using System.Threading.Tasks;

namespace SistemaSHP.Application.Interfaces
{
    public interface ILoginInterface
    {
        Task<ResponseModel<Usuario>> RegistrarUsuario(UsuarioRegisterDto usuarioRegisterDto);
        Task<bool> Login(LoginRequest loginRequest);
    }
}
