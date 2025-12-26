using SHP___Sociedade_Hípica_Paulista.Models;

namespace SHP___Sociedade_Hípica_Paulista.Services.SessaoService
{
    public interface ISessaoInterface
    {
        UsuarioModel BuscarSessao();
        void CriarSessao(UsuarioModel usuarioModel);
        void RemoveSessao();
    }
}
