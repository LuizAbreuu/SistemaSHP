namespace SHP___Sociedade_Hípica_Paulista.Services.SenhaService
{
    public interface ISenhaInterface
    {
        void CriarSenhaHash(string senha, out byte[] senhaHash, out byte[] senhaSalt);
    }
}
