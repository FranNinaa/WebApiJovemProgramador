using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using WebApplicationAlunos.Data;
using WebApplicationAlunos.Repositorios.Interfaces;

namespace WebApplicationAlunos.Repositorios
{
    //especifa uma restrição que T pode ser apenas uma classe
    //ñ podendo passaar para meu repositorio que ñ seja uma classe
    public class Repository<T> : IRepositorio<T> where T : class
    {
        protected AlunoDBcontex _context;

        //no construtor esta injetando uma instancia do contexto que é AlunoDBcontex
        //só é possivel por que foi registrado na classe program no metodo configure server
        public Repository(AlunoDBcontex contexto)
        {
            //obtendo uma instancia do contexto 
            //porque precisa dessa instancia para fazer as operações com as entidades
            _context = contexto;
        }

        //metodo get retorna IQueryable que é uma lista de entidades
        public IQueryable<T> Get()
        {
            //AsNoTracking é usado para desabilitar o rastreamento de entidades melhorando o desempenho
            return _context.Set<T>().AsNoTracking();
        }

        //retorna uma entidade pelo id - como comparando o id como criterio
        //predicate - para validar o critério se é true ou false
        //aonde que retorna o tipo
        public T GetById(Expression<Func<T, bool>> predicate)
        {
            return _context.Set<T>().SingleOrDefault(predicate);
        }

        //o metodos add e delete recebe uma entidade de um tipo
        //e usam uma instancia do contexto para fazer a operação add e delete
        public void Add(T entity)
        {
            _context.Set<T>().Add(entity);
        }

        public void Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
        }

        //no método update
        public void Update(T entity)
        {
            //recebe uma entidade definindo o estado da entidade informando que foi modificada
            _context.Entry(entity).State = EntityState.Modified;

            //usa o metodo update para atualiuzar a entidade
            _context.Set<T>().Update(entity);
        }
    }//obs é uma implementação de um repositorio generico podendo usar em quakquer lugar 
    //por que ñ tem nada especifico
}
