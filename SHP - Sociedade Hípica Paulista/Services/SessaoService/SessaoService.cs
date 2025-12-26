using Newtonsoft.Json;
using SHP___Sociedade_Hípica_Paulista.Models;

namespace SHP___Sociedade_Hípica_Paulista.Services.SessaoService
{
    public class SessaoService : ISessaoInterface
    {
        private readonly IHttpContextAccessor _contextAccessor;
        public SessaoService(IHttpContextAccessor contextAccessor)
        {
            _contextAccessor = contextAccessor;
        }

        public UsuarioModel BuscarSessao()
        {
            var sessaoUsuario = _contextAccessor.HttpContext.Session.GetString("SessaoUsuario");
            if (string.IsNullOrEmpty(sessaoUsuario))
            {
                return null;
            }

            return JsonConvert.DeserializeObject<UsuarioModel>(sessaoUsuario);
        }

        public void CriarSessao(UsuarioModel usuarioModel)
        {
            
            var usuarioJson = JsonConvert.SerializeObject(usuarioModel);
            _contextAccessor.HttpContext.Session.SetString("SessaoUsuario", usuarioJson);

        }

        public void RemoveSessao()
        {
            _contextAccessor.HttpContext.Session.Remove("SessaoUsuario");
        }
    }
}
