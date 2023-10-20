using WebApplicationAlunos.Models;

namespace WebApplicationAlunos.Repositorios.Interfaces
{
    public interface IAlunoRepositorio
    {
        Task<List<AlunoModel>> BuscarTodosUsuarios();

        Task<AlunoModel> BuscarPorId(int id);

        Task<AlunoModel> Adicionar(AlunoModel aluno);

        Task<AlunoModel> Atualizar(AlunoModel aluno, int id);

        Task<bool> Apagar(int id);
    }
}
