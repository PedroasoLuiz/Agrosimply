using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AgroSimply_V2.Migrations
{
    /// <inheritdoc />
    public partial class mssqllocal_migration_851 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Produtor",
                columns: table => new
                {
                    IdProdutor = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CPF = table.Column<int>(type: "int", nullable: false),
                    CNPJ = table.Column<int>(type: "int", nullable: false),
                    Atividade = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produtor", x => x.IdProdutor);
                });

            migrationBuilder.CreateTable(
                name: "Propriedade",
                columns: table => new
                {
                    IdPropriedade = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cidade = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cultura = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Localização = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Extensão = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Propriedade", x => x.IdPropriedade);
                });

            migrationBuilder.CreateTable(
                name: "Telefone",
                columns: table => new
                {
                    IdTel = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProdutorId = table.Column<int>(type: "int", nullable: false),
                    Numero = table.Column<int>(type: "int", nullable: false),
                    Tipo = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Telefone", x => x.IdTel);
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    IdUsuario = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProdutorId = table.Column<int>(type: "int", nullable: false),
                    CPF = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tipo = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.IdUsuario);
                });

            migrationBuilder.InsertData(
                table: "Produtor",
                columns: new[] { "IdProdutor", "Atividade", "CNPJ", "CPF", "Email", "Nome" },
                values: new object[] { 1, "Criador", 0, 0, "Jesus@ceu.wo", "Jesus" });

            migrationBuilder.InsertData(
                table: "Propriedade",
                columns: new[] { "IdPropriedade", "Cidade", "Cultura", "Extensão", "Localização", "Nome" },
                values: new object[] { 1, "Mundo", "Arvore da Vida", 1E+19f, "Paraiso", "Jardim do Eden" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Produtor");

            migrationBuilder.DropTable(
                name: "Propriedade");

            migrationBuilder.DropTable(
                name: "Telefone");

            migrationBuilder.DropTable(
                name: "Usuario");
        }
    }
}
