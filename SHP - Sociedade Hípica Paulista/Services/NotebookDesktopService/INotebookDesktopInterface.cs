using SHP___Sociedade_Hípica_Paulista.Models;
using System.Data;

namespace SHP___Sociedade_Hípica_Paulista.Services.NotebookDesktopService
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
