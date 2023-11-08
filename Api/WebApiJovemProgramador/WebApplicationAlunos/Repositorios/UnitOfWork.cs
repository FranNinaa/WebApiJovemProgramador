using WebApplicationAlunos.Data;
using WebApplicationAlunos.Repositorios.Interfaces;

namespace WebApplicationAlunos.Repositorios
{
    //para esta usando essa implementação tem que esta registrando no program

    //representa uma implementação da interface
    public class UnitOfWork : IUnitOfWork
    {
        private AlunoRepositorio _alunoRepositorio;

        private UsuarioRepositorio _usuarioRepositorio;

        public AlunoDBcontex _context;

        public UnitOfWork(AlunoDBcontex contexto)
        {
            _context = contexto;
        }

        public IAlunoRepositorio alunoRepositorio
        {
            get
            {
                return _alunoRepositorio = _alunoRepositorio ?? new AlunoRepositorio(_context);
            }
        }

        public IUsuarioRepositorio usuarioRepositorio
        {
            get
            {
                return _usuarioRepositorio = _usuarioRepositorio ?? new UsuarioRepositorio(_context);
            }
        }

        //persiste as informaçãoes no banco de dados
        public void Commit()
        {
            _context.SaveChanges();
        }

        //liberando o recurso usado na injesão do context
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
