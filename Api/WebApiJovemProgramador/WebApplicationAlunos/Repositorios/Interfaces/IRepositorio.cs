using System.Linq.Expressions;

namespace WebApplicationAlunos.Repositorios.Interfaces
{
    //interface genérica - tipo de classe que tem assinatursa do método
    public interface IRepositorio<T>
    {
        //retorna uma lista de um tipo(podendo customizar a consulta)
        //metodo consultar
        IQueryable<T> Get();

        //consultar por ID
        T GetById(Expression<Func<T, bool>> predicate);

        //adicionar
        void Add(T entity);

        //atualizar
        void Update(T entity);

        //deletar
        void Delete(T entity);

        //obs
    }
}
