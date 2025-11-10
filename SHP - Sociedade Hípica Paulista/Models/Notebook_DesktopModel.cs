using System.ComponentModel.DataAnnotations;
using System.Security.Principal;

namespace SHP___Sociedade_Hípica_Paulista.Models
{
    public class Notebook_DesktopModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "preenchimento obrigatório")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "preenchimento obrigatório")]
        public string Tipo { get; set; }
        [Required(ErrorMessage = "preenchimento obrigatório")]
        public string ResponsavelInstalacao { get; set; }
        [Required(ErrorMessage = "preenchimento obrigatório")]
        public string Usuario { get; set; }
        [Required(ErrorMessage = "preenchimento obrigatório")]
        public string Departamento { get; set; }
        [Required(ErrorMessage = "preenchimento obrigatório")]
        public string Procedencia { get; set; }
        [Required(ErrorMessage = "preenchimento obrigatório")]
        public string Marca { get; set; }
        [Required(ErrorMessage = "preenchimento obrigatório")]
        public string Modelo { get; set; }
        [Required(ErrorMessage = "preenchimento obrigatório")]
        public string Processador { get; set; }
        [Required(ErrorMessage = "preenchimento obrigatório")]
        public int Memoria { get; set; }
        [Required(ErrorMessage = "preenchimento obrigatório")]
        public string Espaco_TipoDisco { get; set; }
        [Required(ErrorMessage = "preenchimento obrigatório")]
        public string SistemaOperacional { get; set; }
        [Required(ErrorMessage = "preenchimento obrigatório")]
        public string NumeroSerie { get; set; }
        [Required(ErrorMessage = "preenchimento obrigatório")]
        public DateTime DataInstalacao { get; set; } = DateTime.Now;
        [Required(ErrorMessage = "preenchimento obrigatório")]
        public DateTime DataInventario { get; set; }
        [Required(ErrorMessage = "preenchimento obrigatório")]
        public string LogEquipamento { get; set; }

    }
}
