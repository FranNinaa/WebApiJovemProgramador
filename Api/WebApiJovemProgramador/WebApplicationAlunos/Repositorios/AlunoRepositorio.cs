using Microsoft.EntityFrameworkCore;
using WebApplicationAlunos.Data;
using WebApplicationAlunos.Models;
using WebApplicationAlunos.Repositorios.Interfaces;

namespace WebApplicationAlunos.Repositorios
{
    public class AlunoRepositorio : Repository<AlunoModel>, IAlunoRepositorio
    {
        public AlunoRepositorio(AlunoDBcontex contexto) : base(contexto)
        {
        }

        public IEnumerable<AlunoModel> GetStatus()
        {
            return Get().OrderBy(s => s.Status).ToList();
        }
    }
}
