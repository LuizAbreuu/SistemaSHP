using System.ComponentModel.DataAnnotations;

namespace SistemaSHP.Application.DTOs
{
    public class UsuarioRegisterDto
    {

        [Required(ErrorMessage = "O campo Nome é obrigatório.")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "O campo Sobrenome é obrigatório.")]
        public string Sobrenome { get; set; }
        [Required(ErrorMessage = "O campo Email é obrigatório.")]
        public string Email { get; set; }
        [Required(ErrorMessage = "O campo senha é obrigatório.")]
        public string Senha { get; set; }
        [Required(ErrorMessage = "O campo confirma senha é obrigatório."),Compare("Senha", ErrorMessage = "As senhas não estão iguais")]
        public string ConfirmaSenha { get; set; }
    }
}
