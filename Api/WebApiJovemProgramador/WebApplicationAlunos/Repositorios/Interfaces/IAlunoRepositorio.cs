using WebApplicationAlunos.Models;

namespace WebApplicationAlunos.Repositorios.Interfaces
{
    public interface IAlunoRepositorio : IRepositorio<AlunoModel>
    {
        //metodo especifico onde que obtenho o aluno pelo status
        IEnumerable<AlunoModel> GetStatus();
    }
}
