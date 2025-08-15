using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PetAmparo.Migrations
{
    /// <inheritdoc />
    public partial class AdicionadoDescricaoCidade : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Cidade",
                table: "TB_Usuario",
                type: "varchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Descricao",
                table: "TB_Usuario",
                type: "varchar(150)",
                maxLength: 150,
                nullable: false,
                defaultValue: "")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Cidade",
                table: "TB_Ong",
                type: "varchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Descricao",
                table: "TB_Ong",
                type: "varchar(150)",
                maxLength: 150,
                nullable: false,
                defaultValue: "")
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Cidade",
                table: "TB_Usuario");

            migrationBuilder.DropColumn(
                name: "Descricao",
                table: "TB_Usuario");

            migrationBuilder.DropColumn(
                name: "Cidade",
                table: "TB_Ong");

            migrationBuilder.DropColumn(
                name: "Descricao",
                table: "TB_Ong");
        }
    }
}
