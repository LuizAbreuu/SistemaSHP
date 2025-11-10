using Microsoft.EntityFrameworkCore;
using SHP___Sociedade_Hípica_Paulista.Models;

namespace SHP___Sociedade_Hípica_Paulista.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Notebook_DesktopModel> Notebook_Desktops { get; set; }
        public DbSet<UsuarioModel> Usuarios { get; set; }

    }
}

