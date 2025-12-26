using Microsoft.EntityFrameworkCore;
using SHP___Sociedade_Hípica_Paulista.Data;
using SHP___Sociedade_Hípica_Paulista.Models;
using System.Collections.Generic;
using System.Data;
using System.Reflection.Metadata.Ecma335;

namespace SHP___Sociedade_Hípica_Paulista.Services.NotebookDesktopService
{
    public class NotebookDesktopService : INotebookDesktopInterface
    {
        private readonly ApplicationDbContext _context;
        public NotebookDesktopService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<DataTable> BuscarDadosNotebookDesktopExcel()
        {
            DataTable dataTable = new DataTable();

            dataTable.TableName = "Notebook´s e Desktop´s";

            dataTable.Columns.Add("Nome", typeof(string));
            dataTable.Columns.Add("Tipo", typeof(string));
            dataTable.Columns.Add("Responsável instalação", typeof(string));
            dataTable.Columns.Add("Usuário", typeof(string));
            dataTable.Columns.Add("Departamento", typeof(string));
            dataTable.Columns.Add("Procedencia", typeof(string));
            dataTable.Columns.Add("Marca", typeof(string));
            dataTable.Columns.Add("Modelo", typeof(string));
            dataTable.Columns.Add("Processador", typeof(string));
            dataTable.Columns.Add("Memoria", typeof(int));
            dataTable.Columns.Add("Espaço/Tipo disco", typeof(string));
            dataTable.Columns.Add("Sistema Operacional", typeof(string));
            dataTable.Columns.Add("Número de Série", typeof(string));
            dataTable.Columns.Add("Data Instalação", typeof(DateTime));
            dataTable.Columns.Add("Data Inventário", typeof(DateTime));
            dataTable.Columns.Add("Log Equipamento", typeof(string));

            var notebooksDesktop = await BuscarNotebookDesktop();

            if (notebooksDesktop.Dados.Count > 0)
            {
                notebooksDesktop.Dados.ForEach(Notebook_Desktop =>
                {
                    dataTable.Rows.Add(Notebook_Desktop.Nome, Notebook_Desktop.Tipo, Notebook_Desktop.ResponsavelInstalacao, Notebook_Desktop.Usuario,
                        Notebook_Desktop.Departamento, Notebook_Desktop.Procedencia, Notebook_Desktop.Marca, Notebook_Desktop.Modelo, Notebook_Desktop.Processador,
                        Notebook_Desktop.Memoria, Notebook_Desktop.Espaco_TipoDisco, Notebook_Desktop.SistemaOperacional, Notebook_Desktop.NumeroSerie, Notebook_Desktop.DataInstalacao,
                        Notebook_Desktop.DataInventario, Notebook_Desktop.LogEquipamento);
                });
            }

            return dataTable;
        }

        public async Task<ResponseModel<List<Notebook_DesktopModel>>> BuscarNotebookDesktop()
        {
            ResponseModel<List<Notebook_DesktopModel>> response = new ResponseModel<List<Notebook_DesktopModel>>();

            try
            {

                var notebooksDesktops = await _context.Notebook_Desktops.ToListAsync();
                response.Dados = notebooksDesktops;
                response.Mensagem = "Notebooks e Desktops buscados com sucesso.";

                return response;

            }
            catch (Exception ex)
            {
                response.Mensagem = ex.Message;
                response.Status = false;
                return response;
            }
        }

        public async Task<ResponseModel<Notebook_DesktopModel>> BuscarNotebookDesktopPorId(int? id)
        {
            ResponseModel<Notebook_DesktopModel> response = new ResponseModel<Notebook_DesktopModel>();

            try
            {

                if(id == null)
                {
                    response.Mensagem = "Notebook ou desktop não encontrado!";
                    response.Status = false;
                    return response;
                }

                var notebookDesktop = await _context.Notebook_Desktops.FirstOrDefaultAsync(x => x.Id == id);   
                
                if(notebookDesktop == null)
                {
                    response.Mensagem = "Notebook ou desktop não encontrado!";
                    response.Status = false;
                    return response;
                }

                response.Dados = notebookDesktop;
                response.Mensagem = "Notebook ou desktop buscado com sucesso.";

                return response;

            }
            catch (Exception ex)
            {
                response.Mensagem = ex.Message;
                response.Status = false;
                return response;
            }
        }

        public async Task<ResponseModel<Notebook_DesktopModel>> CadastrarNotebookDesktop(Notebook_DesktopModel notebook_DesktopModel)
        {
            ResponseModel<Notebook_DesktopModel> response = new ResponseModel<Notebook_DesktopModel>();

            try
            {

                _context.Add(notebook_DesktopModel);
                await _context.SaveChangesAsync();

                response.Mensagem = "Notebook ou desktop cadastrado com sucesso.";

                return response;    

            }
            catch (Exception ex)
            {
                response.Mensagem = ex.Message;
                response.Status = false;
                return response;
            }
        }

        public async Task<ResponseModel<Notebook_DesktopModel>> EditarNotebookDesktop(Notebook_DesktopModel notebook_DesktopModel)
        {
            ResponseModel<Notebook_DesktopModel> response = new ResponseModel<Notebook_DesktopModel>();

            try
            {

                var notebookDesktop = await BuscarNotebookDesktopPorId(notebook_DesktopModel.Id);

                if(notebookDesktop.Status == false)
                {
                    return notebookDesktop;
                }

                notebookDesktop.Dados.Nome = notebook_DesktopModel.Nome;
                notebookDesktop.Dados.Tipo = notebook_DesktopModel.Tipo;
                notebookDesktop.Dados.ResponsavelInstalacao = notebook_DesktopModel.ResponsavelInstalacao;
                notebookDesktop.Dados.Usuario = notebook_DesktopModel.Usuario;
                notebookDesktop.Dados.Departamento = notebook_DesktopModel.Departamento;
                notebookDesktop.Dados.Procedencia = notebook_DesktopModel.Procedencia;
                notebookDesktop.Dados.Marca = notebook_DesktopModel.Marca;
                notebookDesktop.Dados.Modelo = notebook_DesktopModel.Modelo;
                notebookDesktop.Dados.Processador = notebook_DesktopModel.Processador;
                notebookDesktop.Dados.Memoria = notebook_DesktopModel.Memoria;
                notebookDesktop.Dados.Espaco_TipoDisco = notebook_DesktopModel.Espaco_TipoDisco;
                notebookDesktop.Dados.SistemaOperacional = notebook_DesktopModel.SistemaOperacional;
                notebookDesktop.Dados.NumeroSerie = notebook_DesktopModel.NumeroSerie;
                notebookDesktop.Dados.DataInstalacao = notebook_DesktopModel.DataInstalacao;
                notebookDesktop.Dados.DataInventario = notebook_DesktopModel.DataInventario;
                notebookDesktop.Dados.LogEquipamento = notebook_DesktopModel.LogEquipamento;

                _context.Update(notebookDesktop.Dados);
                await _context.SaveChangesAsync();

                response.Mensagem = "Notebook ou desktop editado com sucesso.";

                return response;

            }
            catch (Exception ex)
            {
                response.Mensagem = ex.Message;
                response.Status = false;
                return response;
            }
        }

        public async Task<ResponseModel<Notebook_DesktopModel>> RemoveNotebookDesktop(Notebook_DesktopModel notebook_DesktopModel)
        {
            ResponseModel<Notebook_DesktopModel> response = new ResponseModel<Notebook_DesktopModel>();

            try
            {

                _context.Remove(notebook_DesktopModel);
                await _context.SaveChangesAsync();

                response.Mensagem = "Notebook ou desktop removido com sucesso.";

                return response;

            }
            catch (Exception ex)
            {
                response.Mensagem = ex.Message;
                response.Status = false;
                return response;
            }
        }
    }
}
