using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class User_Uf_County_Cep : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Ufs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Initials = table.Column<string>(type: "varchar(2)", maxLength: 2, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Name = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreateAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    UpdateAt = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ufs", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Name = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Email = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreateAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    UpdateAt = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Counties",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Name = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CodeIBGE = table.Column<int>(type: "int", nullable: false),
                    UfId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    CreateAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    UpdateAt = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Counties", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Counties_Ufs_UfId",
                        column: x => x.UfId,
                        principalTable: "Ufs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Ceps",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Cep = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Logradouro = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Numero = table.Column<string>(type: "varchar(15)", maxLength: 15, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CountyId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    CreateAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    UpdateAt = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ceps", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ceps_Counties_CountyId",
                        column: x => x.CountyId,
                        principalTable: "Counties",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Ufs",
                columns: new[] { "Id", "CreateAt", "Initials", "Name", "UpdateAt" },
                values: new object[,]
                {
                    { new Guid("7f05c57d-c8af-406d-9703-f44a81b30a5b"), new DateTime(2021, 6, 4, 16, 43, 27, 883, DateTimeKind.Utc).AddTicks(9520), "AC", "Acre", new DateTime(2021, 6, 4, 16, 43, 27, 884, DateTimeKind.Utc).AddTicks(1384) },
                    { new Guid("e515bef8-d36f-44eb-91a8-5dc31d31fc6e"), new DateTime(2021, 6, 4, 16, 43, 27, 884, DateTimeKind.Utc).AddTicks(2228), "SP", "São Paulo", new DateTime(2021, 6, 4, 16, 43, 27, 884, DateTimeKind.Utc).AddTicks(2247) },
                    { new Guid("dbbb5b5a-4be3-4bf3-8bb1-da40065cf20d"), new DateTime(2021, 6, 4, 16, 43, 27, 884, DateTimeKind.Utc).AddTicks(2263), "RJ", "Rio de Janeiro", new DateTime(2021, 6, 4, 16, 43, 27, 884, DateTimeKind.Utc).AddTicks(2265) },
                    { new Guid("e1299ddc-d20f-41b0-b745-1e6838451fbd"), new DateTime(2021, 6, 4, 16, 43, 27, 884, DateTimeKind.Utc).AddTicks(2270), "MG", "Minas Gerais", new DateTime(2021, 6, 4, 16, 43, 27, 884, DateTimeKind.Utc).AddTicks(2271) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ceps_Cep",
                table: "Ceps",
                column: "Cep",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Ceps_CountyId",
                table: "Ceps",
                column: "CountyId");

            migrationBuilder.CreateIndex(
                name: "IX_Counties_CodeIBGE",
                table: "Counties",
                column: "CodeIBGE",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Counties_UfId",
                table: "Counties",
                column: "UfId");

            migrationBuilder.CreateIndex(
                name: "IX_Ufs_Initials",
                table: "Ufs",
                column: "Initials",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_Email",
                table: "Users",
                column: "Email",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ceps");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Counties");

            migrationBuilder.DropTable(
                name: "Ufs");
        }
    }
}
