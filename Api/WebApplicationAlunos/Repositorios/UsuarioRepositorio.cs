using Microsoft.EntityFrameworkCore;
using WebApplicationAlunos.Data;
using WebApplicationAlunos.Models;
using WebApplicationAlunos.Repositorios.Interfaces;

namespace WebApplicationAlunos.Repositorios
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        private readonly AlunoDBcontex _dbContext;

        public UsuarioRepositorio(AlunoDBcontex dbContext)
        {
            _dbContext = dbContext;   
        }
        public async  Task<UsuarioModel> BuscarPorId(int id)
        {
           return  await _dbContext.Usuarios.FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task<List<UsuarioModel>> BuscarTodosUsuarios()
        {
            return await _dbContext.Usuarios.ToListAsync();
        }

        public async Task<UsuarioModel> Adicionar(UsuarioModel usuario)
        {
            await _dbContext.Usuarios.AddAsync(usuario);
            _dbContext.SaveChanges();

            return usuario;
        }

        public async Task<UsuarioModel> Atualizar(UsuarioModel usuario, int id)
        {
           UsuarioModel usuarioModel  = await BuscarPorId(id );

            if (usuarioModel == null)
            {
                throw new Exception($"Usuario não encontrado: {id} ");
            }
            usuarioModel.Name = usuarioModel.Name;
            usuarioModel.Email = usuarioModel.Email;

            _dbContext.Usuarios.Update(usuarioModel);
           await _dbContext.SaveChangesAsync();

            return usuarioModel;
        }

        public async Task<bool> Apagar(int id)
        {
            UsuarioModel usuarioModel = await BuscarPorId(id);

            if (usuarioModel == null)
            {
                throw new Exception($"Usuario não encontrado: {id} ");
            }

            _dbContext.Usuarios.Remove(usuarioModel);
            await _dbContext.SaveChangesAsync();
            return true;
        }

       

      
    }
}
