using Microsoft.EntityFrameworkCore;
using SistemaSHP.Domain.Entities;

namespace SistemaSHP.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Notebook_DesktopModel> Notebook_Desktops { get; set; }
    }
}
