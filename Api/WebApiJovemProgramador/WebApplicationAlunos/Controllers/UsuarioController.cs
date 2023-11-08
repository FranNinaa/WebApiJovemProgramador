using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplicationAlunos.Data;
using WebApplicationAlunos.Models;
using WebApplicationAlunos.Repositorios.Interfaces;

namespace WebApplicationAlunos.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public UsuarioController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        [HttpGet("emailUsuarios")]//to retrnando uma lista de alunos pelo status
        public ActionResult<IEnumerable<UsuarioModel>> GetTodosUsuarios()
        {
            return _unitOfWork.usuarioRepositorio.GetUsuarios().ToList();
        }

        [HttpGet]
        public ActionResult<IEnumerable<UsuarioModel>> Get()
        {
            var usuarios = _unitOfWork.usuarioRepositorio.Get().ToList();

            if (usuarios is null)
            {
                return NotFound("Usuário não encontrados");
            }

            return usuarios;
        }

        [HttpGet("{id:int}", Name = "ObterUsuario")]
        public ActionResult<UsuarioModel> Get(int id)
        {
            var alunos = _unitOfWork.usuarioRepositorio.GetById(a => a.Id == id);

            if (alunos is null)
            {
                return NotFound("Usuário não encontrado");
            }
            return alunos;
        }

        [HttpPost]
        public ActionResult Post(UsuarioModel usuario)
        {
            if (usuario is null)
                return BadRequest();

            _unitOfWork.usuarioRepositorio.Add(usuario);
            _unitOfWork.Commit();

            return new CreatedAtRouteResult("ObterUsuario",
                new { id = usuario.Id }, usuario);
        }

        [HttpPut("{id:int}")]
        public ActionResult Put(int id, UsuarioModel usuario)
        {
            if (id != usuario.Id)
            {
                return BadRequest();
            }

            _unitOfWork.usuarioRepositorio.Update(usuario);
            _unitOfWork.Commit();

            return Ok(usuario);

        }
        [HttpDelete("{id:int}")]
        public ActionResult Delete(int id)
        {
            var usuario = _unitOfWork.usuarioRepositorio.GetById(a => a.Id == id);

            if (usuario is null)
            {
                return NotFound("Aluno não localizado...");
            }
            _unitOfWork.usuarioRepositorio.Delete (usuario);
            _unitOfWork.Commit();

            return Ok(usuario);
        }
    }
}
