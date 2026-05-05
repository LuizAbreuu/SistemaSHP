using Microsoft.EntityFrameworkCore;
using SistemaSHP.Domain.Entities;
using SistemaSHP.Domain.Interfaces;
using SistemaSHP.Infrastructure.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SistemaSHP.Infrastructure.Repositories
{
    public class NotebookDesktopRepository : INotebookDesktopRepository
    {
        private readonly ApplicationDbContext _context;

        public NotebookDesktopRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Adicionar(Notebook_DesktopModel notebookDesktop)
        {
            _context.Notebook_Desktops.Add(notebookDesktop);
            await _context.SaveChangesAsync();
        }

        public async Task Atualizar(Notebook_DesktopModel notebookDesktop)
        {
            _context.Notebook_Desktops.Update(notebookDesktop);
            await _context.SaveChangesAsync();
        }

        public async Task<Notebook_DesktopModel> BuscarPorId(int id)
        {
            return await _context.Notebook_Desktops.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<Notebook_DesktopModel>> BuscarTodos()
        {
            return await _context.Notebook_Desktops.ToListAsync();
        }

        public async Task Remover(Notebook_DesktopModel notebookDesktop)
        {
            _context.Notebook_Desktops.Remove(notebookDesktop);
            await _context.SaveChangesAsync();
        }
    }
}
