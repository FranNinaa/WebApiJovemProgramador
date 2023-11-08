using WebApplicationAlunos.Data;
using WebApplicationAlunos.Models;
using WebApplicationAlunos.Repositorios.Interfaces;

namespace WebApplicationAlunos.Repositorios
{
    public class UsuarioRepositorio : Repository<UsuarioModel>, IUsuarioRepositorio
    {
        public UsuarioRepositorio(AlunoDBcontex contexto) : base(contexto)
        {
        }

        public IEnumerable<UsuarioModel> GetUsuarios()
        {
            return Get().OrderBy(e => e.Email).ToList();
        }
    }
}
