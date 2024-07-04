using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AtendimentoMultiTenant.Infra.Migrations
{
    /// <inheritdoc />
    public partial class Initialize_Db_Config : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tenant",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Secret = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    ConnectionString = table.Column<string>(type: "text", nullable: false),
                    InitialUrl = table.Column<string>(type: "text", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tenant", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Container",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ContainerName = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false),
                    ContainerImage = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false),
                    EnvironmentDbName = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false),
                    EnvironmentDbUser = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    EnvironmentDbPwd = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    ContainerPort = table.Column<string>(type: "character varying(4)", maxLength: 4, nullable: false),
                    ContainerVolume = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    ContainerNetwork = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    IsUp = table.Column<bool>(type: "boolean", nullable: false),
                    ContainerCreatedAt = table.Column<DateOnly>(type: "date", nullable: true),
                    TenantId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Container", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Container_Tenant_TenantId",
                        column: x => x.TenantId,
                        principalTable: "Tenant",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    Password = table.Column<string>(type: "text", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true),
                    TenantId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                    table.ForeignKey(
                        name: "FK_User_Tenant_TenantId",
                        column: x => x.TenantId,
                        principalTable: "Tenant",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Tenant",
                columns: new[] { "Id", "ConnectionString", "InitialUrl", "IsActive", "Name", "Secret" },
                values: new object[,]
                {
                    { new Guid("25ae8570-56b6-4a9d-9616-c15862613525"), "Host=localhost;Port=5435;Database=Cliente3DB;User ID=usercliente3;Password=pwdcliente3;Pooling=true;", "", true, "Cliente3", "123" },
                    { new Guid("64210b12-a8d4-44ae-b35e-b13b762c4179"), "Host=localhost;Port=5434;Database=Cliente2DB;User ID=usercliente2;Password=pwdcliente2;Pooling=true;", "", true, "Cliente2", "123" },
                    { new Guid("f6a2372a-b146-45f9-be70-a0be13736dd8"), "Host=localhost;Port=5433;Database=Cliente1DB;User ID=usercliente1;Password=pwdcliente1;Pooling=true;", "", true, "Cliente1", "123" }
                });

            migrationBuilder.InsertData(
                table: "Container",
                columns: new[] { "Id", "ContainerCreatedAt", "ContainerImage", "ContainerName", "ContainerNetwork", "ContainerPort", "ContainerVolume", "EnvironmentDbName", "EnvironmentDbPwd", "EnvironmentDbUser", "IsUp", "TenantId" },
                values: new object[,]
                {
                    { new Guid("338988dc-bc96-46e9-bdfa-0a5e298ae3cb"), null, "postgres:16.2", "postgresql_cliente2", "cliente2_network", "5434", "cliente2_volume", "Cliente2DB", "pwdcliente2", "usercliente2", false, new Guid("64210b12-a8d4-44ae-b35e-b13b762c4179") },
                    { new Guid("616a7837-dfcc-4ab8-9f5b-7616556bcee7"), null, "postgres:16.2", "postgresql_cliente3", "cliente3_network", "5435", "cliente3_volume", "Cliente3DB", "pwdcliente3", "usercliente3", false, new Guid("25ae8570-56b6-4a9d-9616-c15862613525") },
                    { new Guid("b9148b2f-38d2-4e01-81bc-bc3710e8fbab"), null, "postgres:16.2", "postgresql_cliente1", "cliente1_network", "5433", "cliente1_volume", "Cliente1DB", "pwdcliente1", "usercliente1", false, new Guid("f6a2372a-b146-45f9-be70-a0be13736dd8") }
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "Email", "IsActive", "Name", "Password", "TenantId" },
                values: new object[,]
                {
                    { new Guid("1f88bffa-bba7-4c14-8e51-3bfa06322616"), "usuario3@teste.com", true, "Usuario3", "123", new Guid("25ae8570-56b6-4a9d-9616-c15862613525") },
                    { new Guid("a379e99a-826a-43f5-b7eb-5d60d7b67c5f"), "usuario2@teste.com", true, "Usuario2", "123", new Guid("64210b12-a8d4-44ae-b35e-b13b762c4179") },
                    { new Guid("bf06f7b2-6376-4ad6-9ba5-2cee86c3fae3"), "usuario1@teste.com", true, "Usuario1", "123", new Guid("f6a2372a-b146-45f9-be70-a0be13736dd8") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Container_TenantId",
                table: "Container",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "Tenant_Name",
                table: "Tenant",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_User_TenantId",
                table: "User",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "User_Email",
                table: "User",
                column: "Email",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Container");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Tenant");
        }
    }
}
