using SistemaSHP.Application.DTOs;
using SistemaSHP.Domain.Entities;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace SistemaSHP.Application.Interfaces
{
    public interface INotebookDesktopInterface
    {
        Task<ResponseModel<List<Notebook_DesktopModel>>> BuscarNotebookDesktop();
        Task<ResponseModel<Notebook_DesktopModel>> BuscarNotebookDesktopPorId(int? id);
        Task<ResponseModel<Notebook_DesktopModel>> CadastrarNotebookDesktop(Notebook_DesktopModel notebook_DesktopModel);
        Task<ResponseModel<Notebook_DesktopModel>> EditarNotebookDesktop(Notebook_DesktopModel notebook_DesktopModel);
        Task<ResponseModel<Notebook_DesktopModel>> RemoveNotebookDesktop(Notebook_DesktopModel notebook_DesktopModel);
        Task<DataTable> BuscarDadosNotebookDesktopExcel();
    }
}
