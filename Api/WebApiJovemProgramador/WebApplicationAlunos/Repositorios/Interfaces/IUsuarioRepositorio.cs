using WebApplicationAlunos.Models;

namespace WebApplicationAlunos.Repositorios.Interfaces
{
    public interface IUsuarioRepositorio : IRepositorio<UsuarioModel>
    {
       IEnumerable<UsuarioModel> GetUsuarios();
    }
}
