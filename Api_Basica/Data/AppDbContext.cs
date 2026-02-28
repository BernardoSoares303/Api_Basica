using Api_Basica.Models;
using Microsoft.EntityFrameworkCore;

namespace Api_Basica.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options)   : base(options) { }


        public DbSet<usuario> Usuarios { get; set; }
        public DbSet<Projeto> Projetos { get; set; }
        public DbSet<Tarefa> Tarefas { get; set; }
    }
}
