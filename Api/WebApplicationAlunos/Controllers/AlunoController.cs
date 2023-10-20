using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplicationAlunos.Data;
using WebApplicationAlunos.Models;

namespace WebApplicationAlunos.Controllers
{
    //define a base dos endpoints
    [Route("[controller]")] //aonde a rota é os alunos
    [ApiController]
    public class AlunoController : ControllerBase
    {
        private readonly AlunoDBcontex _context;

        public AlunoController(AlunoDBcontex context)
        {
            _context = context;
        }

        // acessa uma lista de produtos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AlunoModel>>> Get2()
        {
            var alunos = _context.Alunos.ToList();

            if (alunos is null)
            {
                return await _context.Alunos.AsNoTracking().ToListAsync();
            }

            return alunos;
        }

        // acessa o alunos/id
        [HttpGet("{id:int:min(1)}", Name = "ObterAluno")]
        public async Task<ActionResult<AlunoModel>> Get(int id)
        {
            try
            {
                var alunos = await _context.Alunos.AsNoTracking().
                    FirstOrDefaultAsync(a => a.Id == id);

                if (alunos is null)
                {
                    return NotFound("Aluno não encontrado");
                }
                return alunos;
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Ocorreu um problema ao tratar a sua solitação, contate a pessoa responsável!!");
            }
           
        }

        // acessa o alunos/id/aluno aond que poder+a fazer a atualização passando o id 
        //do aluno e fazendo a alteração desejada passando as caracteristicas que tem o aluno
        [HttpPost]
        public ActionResult Post(AlunoModel aluno)
        {
            if (aluno is null)
                return BadRequest("Aluno não encontrado");

            _context.Alunos.Add(aluno);
            _context.SaveChanges();

            return new CreatedAtRouteResult("ObterAluno",
                new { id = aluno.Id }, aluno);
        }

        [HttpPut("{id:int}")]
        public ActionResult Put(int id, AlunoModel aluno)
        {
            if (id != aluno.Id)
            {
                return BadRequest();
            }

            _context.Entry(aluno).State = EntityState.Modified;
            _context.SaveChanges();

            return Ok(aluno);
        
        }

        [HttpDelete("{id:int}")]
        public ActionResult Delete(int id)
        {
            var aluno = _context.Alunos.FirstOrDefault(a => a.Id == id);

            if (aluno is null)
            {
                return NotFound("Aluno não localizado...");
            }
            _context.Alunos.Remove(aluno);
            _context.SaveChanges();

            return Ok(aluno);
        }
    }
}
