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
                    { new Guid("22ffbd18-cdb9-45cc-97b0-51e97700bf71"), new DateTime(2021, 6, 8, 9, 3, 52, 405, DateTimeKind.Utc).AddTicks(7462), "AC", "Acre", null },
                    { new Guid("971dcb34-86ea-4f92-989d-064f749e23c9"), new DateTime(2021, 6, 8, 9, 3, 52, 405, DateTimeKind.Utc).AddTicks(7846), "TO", "Tocantins", null },
                    { new Guid("e7e416de-477c-4fa3-a541-b5af5f35ccf6"), new DateTime(2021, 6, 8, 9, 3, 52, 405, DateTimeKind.Utc).AddTicks(7837), "SP", "São Paulo", null },
                    { new Guid("fe8ca516-034f-4249-bc5a-31c85ef220ea"), new DateTime(2021, 6, 8, 9, 3, 52, 405, DateTimeKind.Utc).AddTicks(7827), "SE", "Sergipe", null },
                    { new Guid("b81f95e0-f226-4afd-9763-290001637ed4"), new DateTime(2021, 6, 8, 9, 3, 52, 405, DateTimeKind.Utc).AddTicks(7818), "SC", "Santa Catarina", null },
                    { new Guid("88970a32-3a2a-4a95-8a18-2087b65f59d1"), new DateTime(2021, 6, 8, 9, 3, 52, 405, DateTimeKind.Utc).AddTicks(7810), "RS", "Rio Grande do Sul", null },
                    { new Guid("9fd3c97a-dc68-4af5-bc65-694cca0f2869"), new DateTime(2021, 6, 8, 9, 3, 52, 405, DateTimeKind.Utc).AddTicks(7801), "RR", "Roraima", null },
                    { new Guid("924e7250-7d39-4e8b-86bf-a8578cbf4002"), new DateTime(2021, 6, 8, 9, 3, 52, 405, DateTimeKind.Utc).AddTicks(7792), "RO", "Rondônia", null },
                    { new Guid("542668d1-50ba-4fca-bbc3-4b27af108ea3"), new DateTime(2021, 6, 8, 9, 3, 52, 405, DateTimeKind.Utc).AddTicks(7782), "RN", "Rio Grande do Norte", null },
                    { new Guid("43a0f783-a042-4c46-8688-5dd4489d2ec7"), new DateTime(2021, 6, 8, 9, 3, 52, 405, DateTimeKind.Utc).AddTicks(7774), "RJ", "Rio de Janeiro", null },
                    { new Guid("1dd25850-6270-48f8-8b77-2f0f079480ab"), new DateTime(2021, 6, 8, 9, 3, 52, 405, DateTimeKind.Utc).AddTicks(7765), "PR", "Paraná", null },
                    { new Guid("f85a6cd0-2237-46b1-a103-d3494ab27774"), new DateTime(2021, 6, 8, 9, 3, 52, 405, DateTimeKind.Utc).AddTicks(7756), "PI", "Piauí", null },
                    { new Guid("1109ab04-a3a5-476e-bdce-6c3e2c2badee"), new DateTime(2021, 6, 8, 9, 3, 52, 405, DateTimeKind.Utc).AddTicks(7739), "PB", "Paraíba", null },
                    { new Guid("ad5969bd-82dc-4e23-ace2-d8495935dd2e"), new DateTime(2021, 6, 8, 9, 3, 52, 405, DateTimeKind.Utc).AddTicks(7748), "PE", "Pernambuco", null },
                    { new Guid("29eec4d3-b061-427d-894f-7f0fecc7f65f"), new DateTime(2021, 6, 8, 9, 3, 52, 405, DateTimeKind.Utc).AddTicks(7723), "MT", "Mato Grosso", null },
                    { new Guid("7cc33300-586e-4be8-9a4d-bd9f01ee9ad8"), new DateTime(2021, 6, 8, 9, 3, 52, 405, DateTimeKind.Utc).AddTicks(7615), "AL", "Alagoas", null },
                    { new Guid("cb9e6888-2094-45ee-bc44-37ced33c693a"), new DateTime(2021, 6, 8, 9, 3, 52, 405, DateTimeKind.Utc).AddTicks(7632), "AM", "Amazonas", null },
                    { new Guid("409b9043-88a4-4e86-9cca-ca1fb0d0d35b"), new DateTime(2021, 6, 8, 9, 3, 52, 405, DateTimeKind.Utc).AddTicks(7645), "AP", "Amapá", null },
                    { new Guid("5abca453-d035-4766-a81b-9f73d683a54b"), new DateTime(2021, 6, 8, 9, 3, 52, 405, DateTimeKind.Utc).AddTicks(7654), "BA", "Bahia", null },
                    { new Guid("8411e9bc-d3b2-4a9b-9d15-78633d64fc7c"), new DateTime(2021, 6, 8, 9, 3, 52, 405, DateTimeKind.Utc).AddTicks(7731), "PA", "Pará", null },
                    { new Guid("bd08208b-bfca-47a4-9cd0-37e4e1fa5006"), new DateTime(2021, 6, 8, 9, 3, 52, 405, DateTimeKind.Utc).AddTicks(7671), "DF", "Distrito Federal", null },
                    { new Guid("5ff1b59e-11e7-414d-827e-609dc5f7e333"), new DateTime(2021, 6, 8, 9, 3, 52, 405, DateTimeKind.Utc).AddTicks(7663), "CE", "Ceará", null },
                    { new Guid("837a64d3-c649-4172-a4e0-2b20d3c85224"), new DateTime(2021, 6, 8, 9, 3, 52, 405, DateTimeKind.Utc).AddTicks(7689), "GO", "Goiás", null },
                    { new Guid("57a9e9f7-9aea-40fe-a783-65d4feb59fa8"), new DateTime(2021, 6, 8, 9, 3, 52, 405, DateTimeKind.Utc).AddTicks(7697), "MA", "Maranhão", null },
                    { new Guid("27f7a92b-1979-4e1c-be9d-cd3bb73552a8"), new DateTime(2021, 6, 8, 9, 3, 52, 405, DateTimeKind.Utc).AddTicks(7705), "MG", "Minas Gerais", null },
                    { new Guid("3739969c-fd8a-4411-9faa-3f718ca85e70"), new DateTime(2021, 6, 8, 9, 3, 52, 405, DateTimeKind.Utc).AddTicks(7714), "MS", "Mato Grosso do Sul", null },
                    { new Guid("c623f804-37d8-4a19-92c1-67fd162862e6"), new DateTime(2021, 6, 8, 9, 3, 52, 405, DateTimeKind.Utc).AddTicks(7680), "ES", "Espírito Santo", null }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreateAt", "Email", "Name", "UpdateAt" },
                values: new object[,]
                {
                    { new Guid("48b270a8-4cd7-4af1-aa45-449be3555512"), new DateTime(2021, 6, 8, 9, 3, 52, 399, DateTimeKind.Utc).AddTicks(1166), "mariasilva@email.com", "Maria da Silva", new DateTime(2021, 6, 8, 9, 3, 52, 399, DateTimeKind.Utc).AddTicks(1168) },
                    { new Guid("b99f215d-721e-4b04-b059-119a1864fc8f"), new DateTime(2021, 6, 8, 9, 3, 52, 398, DateTimeKind.Utc).AddTicks(8608), "user@example.com", "User Padrão", new DateTime(2021, 6, 8, 9, 3, 52, 399, DateTimeKind.Utc).AddTicks(376) },
                    { new Guid("1d91565f-c033-41dc-95e9-ef8b2291df4e"), new DateTime(2021, 6, 8, 9, 3, 52, 399, DateTimeKind.Utc).AddTicks(1114), "eskokado@email.com", "Edson Shideki Kokado", new DateTime(2021, 6, 8, 9, 3, 52, 399, DateTimeKind.Utc).AddTicks(1130) },
                    { new Guid("4dcb8b0b-bbf5-4e38-88ad-38c483033ddd"), new DateTime(2021, 6, 8, 9, 3, 52, 399, DateTimeKind.Utc).AddTicks(1172), "josesouza@email.com", "José Souza", new DateTime(2021, 6, 8, 9, 3, 52, 399, DateTimeKind.Utc).AddTicks(1174) }
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
