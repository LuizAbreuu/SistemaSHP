using SistemaSHP.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SistemaSHP.Domain.Interfaces
{
    public interface INotebookDesktopRepository
    {
        Task<List<Notebook_DesktopModel>> BuscarTodos();
        Task<Notebook_DesktopModel> BuscarPorId(int id);
        Task Adicionar(Notebook_DesktopModel notebookDesktop);
        Task Atualizar(Notebook_DesktopModel notebookDesktop);
        Task Remover(Notebook_DesktopModel notebookDesktop);
    }
}
