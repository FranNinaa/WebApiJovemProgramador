using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebApplicationAlunos.Enums;

namespace WebApplicationAlunos.Models
{
    [Table("Alunos")]
    public class AlunoModel
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
    }
}
