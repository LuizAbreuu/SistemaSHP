using System.Security.Principal;

namespace SHP___Sociedade_Hípica_Paulista.Models
{
    public class Notebook_DesktopModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Tipo { get; set; }
        public string ResponsavelInstalacao { get; set; }
        public string? Usuario { get; set; }
        public string Departamento { get; set; }
        public string Procedencia { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public string Processador { get; set; }
        public int Memoria { get; set; }
        public string Espaco_TipoDisco { get; set; }
        public string SistemaOperacional { get; set; }
        public string NumeroSerie { get; set; }
        public DateTime DataInstalacao { get; set; } = DateTime.Now;
        public DateTime DataInventario { get; set; }
        public string LogEquipamento { get; set; }

    }
}

