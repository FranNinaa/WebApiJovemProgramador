using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebApplicationAlunos.Enums;

namespace WebApplicationAlunos.Models
{
    [Table("Alunos")]
    public class AlunoModel : IValidatableObject
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string? Nome { get; set; }

        [Required]
        [StringLength(20)]
        public string? DataNascimento { get; set; }

        [Required]
        [StringLength(200)]
        public string? Curso { get; set; }

        public StatusAluno Status { get; set;}

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (this.Status == 0)
            {
                //indica que o método é um interador
                //para retorna cada elemento idividuamente
                //é um tipo de atalho no código
                yield return new
                    ValidationResult("Informe um status válido para este aluno diante as seguinte informações - 1 = Ativo; 2 = Desistencia; 3 = Formado;",
                    new[]
                    { nameof(this.Status) }
                );
            }
        }
    }
}
