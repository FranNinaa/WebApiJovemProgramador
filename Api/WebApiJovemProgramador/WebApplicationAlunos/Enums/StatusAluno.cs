using System.ComponentModel;

namespace WebApplicationAlunos.Enums
{
    public enum StatusAluno
    {
        [Description("Ativo")]
        Ativo = 1,

        [Description("Desistencia")]
        Desistencia = 2,

        [Description("Formado")]
        Concluido = 3,

    }
}
