using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplicationAlunos.Data;
using WebApplicationAlunos.Models;

namespace WebApplicationAlunos.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly AlunoDBcontex _context;

        public UsuarioController(AlunoDBcontex context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<UsuarioModel>> Get()
        {
            var usuarios = _context.Usuarios.ToList();

            if (usuarios is null)
            {
                return NotFound("Usuário não encontrados");
            }

            return usuarios;
        }
        [HttpGet("{id:int}", Name = "ObterUsuario")]
        public ActionResult<AlunoModel> Get(int id)
        {
            var alunos = _context.Alunos.FirstOrDefault(a => a.Id == id);

            if (alunos is null)
            {
                return NotFound("Aluno não encontrado");
            }
            return alunos;
        }

        [HttpPost]
        public ActionResult Post(UsuarioModel usuario)
        {
            if (usuario is null)
                return BadRequest();

            _context.Usuarios.Add(usuario);
            _context.SaveChanges();

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

            _context.Entry(usuario).State = EntityState.Modified;
            _context.SaveChanges();

            return Ok(usuario);

        }
        [HttpDelete("{id:int}")]
        public ActionResult Delete(int id)
        {
            var usuario = _context.Usuarios.FirstOrDefault(a => a.Id == id);

            if (usuario is null)
            {
                return NotFound("Aluno não localizado...");
            }
            _context.Usuarios.Remove(usuario);
            _context.SaveChanges();

            return Ok(usuario);
        }
    }
}
