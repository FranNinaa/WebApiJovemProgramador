using Microsoft.EntityFrameworkCore;
using WebApplicationAlunos.Data;
using WebApplicationAlunos.Models;
using WebApplicationAlunos.Repositorios.Interfaces;

namespace WebApplicationAlunos.Repositorios
{
    public class AlunoRepositorio : IAlunoRepositorio
    {
        private readonly AlunoDBcontex _dbContext;

        public AlunoRepositorio(AlunoDBcontex dbContext)
        {
               _dbContext = dbContext;
        }

        public async Task<AlunoModel> BuscarPorId(int id)
        {
            return await _dbContext.Alunos.FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task<List<AlunoModel>> BuscarTodosUsuarios()
        {
            return await _dbContext.Alunos.ToListAsync();
        }

        public async Task<AlunoModel> Adicionar(AlunoModel aluno)
        {
           await  _dbContext.Alunos.AddAsync(aluno);
           await _dbContext.SaveChangesAsync();

            return aluno;
        }

        public async Task<AlunoModel> Atualizar(AlunoModel aluno, int id)
        {
            AlunoModel alunoModel = await BuscarPorId(id);

            if (alunoModel == null)
            {
                throw new Exception($"Usuario não encontrado: {id} ");
            }
            alunoModel.DataNascimento = alunoModel.DataNascimento;
            alunoModel.Nome = alunoModel.Nome;
            alunoModel.Curso = alunoModel.Curso;

            _dbContext.Alunos.Update(alunoModel);
            await _dbContext.SaveChangesAsync();

            return alunoModel;
        }

        public async Task<bool> Apagar(int id)
        {
            AlunoModel alunoModel = await BuscarPorId(id);

            if (alunoModel == null)
            {
                throw new Exception($"Usuario não encontrado: {id} ");
            }

            _dbContext.Alunos.Remove(alunoModel);
           await _dbContext.SaveChangesAsync();
            return true;
        }

       

        
    }
}
