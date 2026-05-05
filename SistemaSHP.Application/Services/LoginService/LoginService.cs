using SistemaSHP.Application.DTOs;
using SistemaSHP.Application.Interfaces;
using SistemaSHP.Domain.Entities;
using SistemaSHP.Domain.Interfaces;
using System;
using System.Threading.Tasks;

namespace SistemaSHP.Application.Services.LoginService
{
    public class LoginService : ILoginInterface
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly ISenhaInterface _senhaInterface;

        public LoginService(IUsuarioRepository usuarioRepository, ISenhaInterface senhaInterface)
        {
            _usuarioRepository = usuarioRepository;
            _senhaInterface = senhaInterface;
        }

        public async Task<bool> Login(LoginRequest request)
        {
            var usuario = await _usuarioRepository.ObterPorEmail(request.Email);

            if (usuario == null)
                return false;

            return _senhaInterface.VerificaSenha(request.Senha, usuario.SenhaHash, usuario.SenhaSalt);
        }

        public async Task<ResponseModel<Usuario>> RegistrarUsuario(UsuarioRegisterDto usuarioRegisterDto)
        {
            ResponseModel<Usuario> response = new ResponseModel<Usuario>();

            try
            {
                if (await VerificarSeEmailExiste(usuarioRegisterDto.Email))
                {
                    response.Mensagem = "Email já cadastrado!";
                    response.Status = false;
                    return response;
                }

                _senhaInterface.CriarSenhaHash(usuarioRegisterDto.Senha, out byte[] senhaHash, out byte[] senhaSalt);

                var usuario = new Usuario
                {
                    Nome = usuarioRegisterDto.Nome,
                    Sobrenome = usuarioRegisterDto.Sobrenome,
                    Email = usuarioRegisterDto.Email,
                    SenhaHash = senhaHash,
                    SenhaSalt = senhaSalt
                };

                await _usuarioRepository.Adicionar(usuario);

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

        private async Task<bool> VerificarSeEmailExiste(string email)
        {
            var usuario = await _usuarioRepository.ObterPorEmail(email);
            return usuario != null;
        }
    }
}
