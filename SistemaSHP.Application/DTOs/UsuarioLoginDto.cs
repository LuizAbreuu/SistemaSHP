using System.ComponentModel.DataAnnotations;

namespace SistemaSHP.Application.DTOs
{
    public class LoginRequest
    {
        public string Email { get; set; }
        public string Senha { get; set; }
    }
}

