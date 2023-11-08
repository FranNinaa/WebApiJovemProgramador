using Microsoft.EntityFrameworkCore;
using WebApplicationAlunos.Data.Map;
using WebApplicationAlunos.Models;

namespace WebApplicationAlunos.Data
{
    public class AlunoDBcontex : DbContext
    {
        public AlunoDBcontex(DbContextOptions<AlunoDBcontex> options)
            : base(options)
        {      
        }

        public DbSet<UsuarioModel> Usuarios { get; set; }

        public DbSet<AlunoModel> Alunos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UsuarioMap());
            modelBuilder.ApplyConfiguration(new AlunoMap());
            base.OnModelCreating(modelBuilder);
        }
    }
}
