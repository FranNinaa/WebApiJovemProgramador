namespace WebApplicationAlunos.Repositorios.Interfaces
{
    public interface IUnitOfWork
    {
        //propriedades q recebe aluno e o usuario
        IAlunoRepositorio alunoRepositorio { get; }

        IUsuarioRepositorio usuarioRepositorio { get; }

        //metodo que salva dados aonde que persiste as transações
        void Commit();
    }
}
