using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplicationAlunos.Migrations
{
    /// <inheritdoc />
    public partial class PopulaAlunos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder mb)
        {
            mb.Sql("Insert Into Alunos(Nome, DataNascimento, Curso, Status) Values('Gustavo dos Santos', '12/08/2003', 'Auxiliar Admnistrativo', '1')");
            mb.Sql("Insert Into Alunos(Nome, DataNascimento, Curso, Status) Values('Derick dos Santos', '16/03/2015', 'Primeiros Passos na Informática', '1')");
            mb.Sql("Insert Into Alunos(Nome, DataNascimento, Curso, Status) Values('Renato de Souza Reis', '22/06/1982', 'Infraestrutura', '3')");

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder mb)
        {
            mb.Sql("Delete from Alunos");
        }
    }
}
