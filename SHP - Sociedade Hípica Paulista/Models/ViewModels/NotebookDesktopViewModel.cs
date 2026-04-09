using System.ComponentModel.DataAnnotations;

namespace SHP___Sociedade_Hípica_Paulista.Models.ViewModels
{
    public class NotebookDesktopViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "preenchimento obrigatório")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "preenchimento obrigatório")]
        public string Tipo { get; set; }

        [Required(ErrorMessage = "preenchimento obrigatório")]
        public string ResponsavelInstalacao { get; set; }

        [Required(ErrorMessage = "preenchimento obrigatório")]
        public string? Usuario { get; set; }

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

        public static Notebook_DesktopModel ToModel(NotebookDesktopViewModel viewModel)
        {
            if (viewModel == null) return null;
            return new Notebook_DesktopModel
            {
                Id = viewModel.Id,
                Nome = viewModel.Nome,
                Tipo = viewModel.Tipo,
                ResponsavelInstalacao = viewModel.ResponsavelInstalacao,
                Usuario = viewModel.Usuario,
                Departamento = viewModel.Departamento,
                Procedencia = viewModel.Procedencia,
                Marca = viewModel.Marca,
                Modelo = viewModel.Modelo,
                Processador = viewModel.Processador,
                Memoria = viewModel.Memoria,
                Espaco_TipoDisco = viewModel.Espaco_TipoDisco,
                SistemaOperacional = viewModel.SistemaOperacional,
                NumeroSerie = viewModel.NumeroSerie,
                DataInstalacao = viewModel.DataInstalacao,
                DataInventario = viewModel.DataInventario,
                LogEquipamento = viewModel.LogEquipamento
            };
        }

        public static NotebookDesktopViewModel FromModel(Notebook_DesktopModel model)
        {
            if (model == null) return null;
            return new NotebookDesktopViewModel
            {
                Id = model.Id,
                Nome = model.Nome,
                Tipo = model.Tipo,
                ResponsavelInstalacao = model.ResponsavelInstalacao,
                Usuario = model.Usuario,
                Departamento = model.Departamento,
                Procedencia = model.Procedencia,
                Marca = model.Marca,
                Modelo = model.Modelo,
                Processador = model.Processador,
                Memoria = model.Memoria,
                Espaco_TipoDisco = model.Espaco_TipoDisco,
                SistemaOperacional = model.SistemaOperacional,
                NumeroSerie = model.NumeroSerie,
                DataInstalacao = model.DataInstalacao,
                DataInventario = model.DataInventario,
                LogEquipamento = model.LogEquipamento
            };
        }
    }
}
