using Microsoft.EntityFrameworkCore;
using SistemaSHP.Domain.Entities;
using SistemaSHP.Domain.Interfaces;
using SistemaSHP.Infrastructure.Data;
using System.Threading.Tasks;

namespace SistemaSHP.Infrastructure.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly ApplicationDbContext _context;

        public UsuarioRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Adicionar(Usuario usuario)
        {
            _context.Usuarios.Add(usuario);
            await _context.SaveChangesAsync();
        }

        public async Task<Usuario> ObterPorEmail(string email)
        {
            return await _context.Usuarios.FirstOrDefaultAsync(x => x.Email == email);
        }
    }
}