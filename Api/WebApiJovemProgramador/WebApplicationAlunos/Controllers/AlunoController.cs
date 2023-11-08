using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplicationAlunos.Data;
using WebApplicationAlunos.Models;
using WebApplicationAlunos.Repositorios.Interfaces;

namespace WebApplicationAlunos.Controllers
{
    //define a base dos endpoints
    [Route("[controller]")] //aonde a rota é os alunos
    [ApiController]
    public class AlunoController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public AlunoController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet("statusAlunos")]//to retrnando uma lista de alunos pelo status
        public ActionResult<IEnumerable<AlunoModel>> GetAlunosStatus()
        {
            return _unitOfWork.alunoRepositorio.GetStatus().ToList();
        }

        // acessa uma lista de produtos
        [HttpGet]
        public ActionResult<IEnumerable<AlunoModel>> Get2()
        {
            var alunos = _unitOfWork.alunoRepositorio.Get().ToList();

            if (alunos is null)
            {
                return _unitOfWork.alunoRepositorio.Get().AsNoTracking().ToList();
            }

            return alunos;
        }

        // acessa o alunos/id
        [HttpGet("{id:int:min(1)}", Name = "ObterAluno")]
        public ActionResult<AlunoModel> Get(int id)
        {
            //throw new Exception("Exception ao retornar o aluno pelo ID");

            try
            {
                var alunos = _unitOfWork.alunoRepositorio.GetById(a => a.Id == id);
                    

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

            _unitOfWork.alunoRepositorio.Add(aluno);
            _unitOfWork.Commit();

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

            _unitOfWork.alunoRepositorio.Update(aluno);
            _unitOfWork.Commit();

            return Ok(aluno);

        }

        [HttpDelete("{id:int}")]
        public ActionResult Delete(int id)
        {
            var aluno = _unitOfWork.alunoRepositorio.GetById(a => a.Id == id);

            if (aluno is null)
            {
                return NotFound("Aluno não localizado...");
            }
            _unitOfWork.alunoRepositorio.Delete(aluno);
            _unitOfWork.Commit();

            return Ok(aluno);
        }
    }
}
