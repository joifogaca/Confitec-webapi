using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ConfitecApi.Migrations
{
    public partial class inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Escolaridades",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    descricao = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Escolaridades", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nome = table.Column<string>(nullable: true),
                    sobrenome = table.Column<string>(nullable: true),
                    email = table.Column<string>(nullable: true),
                    dataNascimento = table.Column<DateTime>(nullable: false),
                    escolaridadeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.id);
                    table.ForeignKey(
                        name: "FK_Usuarios_Escolaridades_escolaridadeId",
                        column: x => x.escolaridadeId,
                        principalTable: "Escolaridades",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Escolaridades",
                columns: new[] { "id", "descricao" },
                values: new object[,]
                {
                    { 1, "Infantil" },
                    { 2, "Fundamental" },
                    { 3, "Médio" },
                    { 4, "Superior" }
                });

            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "id", "dataNascimento", "email", "escolaridadeId", "nome", "sobrenome" },
                values: new object[,]
                {
                    { 1, new DateTime(1999, 7, 7, 2, 0, 0, 0, DateTimeKind.Unspecified), "lsilva@gmail.com", 1, "Lauro", "Silva" },
                    { 4, new DateTime(1992, 12, 24, 2, 0, 0, 0, DateTimeKind.Unspecified), "r_silva@gmail.com", 1, "Rodrigo", "Silva" },
                    { 2, new DateTime(1989, 9, 3, 2, 0, 0, 0, DateTimeKind.Unspecified), "rsilva@gmail.com", 2, "Roberto", "Silva" },
                    { 3, new DateTime(1991, 10, 20, 2, 0, 0, 0, DateTimeKind.Unspecified), "r.silva@gmail.com", 3, "Ronaldo", "Silva" },
                    { 5, new DateTime(1995, 7, 17, 2, 0, 0, 0, DateTimeKind.Unspecified), "lsilva@gmail.com", 4, "Alexandre", "Silva" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_escolaridadeId",
                table: "Usuarios",
                column: "escolaridadeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Escolaridades");
        }
    }
}
