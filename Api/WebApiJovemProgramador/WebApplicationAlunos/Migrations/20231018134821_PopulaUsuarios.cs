using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplicationAlunos.Migrations
{
    /// <inheritdoc />
    public partial class PopulaUsuarios : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("insert into Usuarios(Nome, Email, Password) Values(Gustavo dos Santos, gustavo@gmail.com, '1234')");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("delete from Usuarios");
        }
    }
}
