using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AtendimentoMultiTenant.Infra.Migrations
{
    /// <inheritdoc />
    public partial class Initialize_Configuration_DB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Port",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    port_number = table.Column<string>(type: "character varying(4)", maxLength: 4, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Port", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tenant",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    secret = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    connection_string = table.Column<string>(type: "text", nullable: false),
                    initial_url = table.Column<string>(type: "text", nullable: false),
                    is_active = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true)
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
                    container_name = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false),
                    container_image = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false),
                    environment_db_name = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false),
                    environment_db_user = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    environment_db_pwd = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    container_port = table.Column<string>(type: "character varying(4)", maxLength: 4, nullable: false),
                    container_volume = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    container_network = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    is_up = table.Column<bool>(type: "boolean", nullable: false),
                    container_created_at = table.Column<DateOnly>(type: "date", nullable: true),
                    TenantId = table.Column<Guid>(type: "uuid", nullable: false),
                    PortId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Container", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Container_Port_PortId",
                        column: x => x.PortId,
                        principalTable: "Port",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                    name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    email = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    password = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    is_active = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true),
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
                table: "Port",
                columns: new[] { "Id", "port_number" },
                values: new object[,]
                {
                    { new Guid("39715917-a829-41c4-8da1-64029a0c6364"), "5436" },
                    { new Guid("62afeccd-c9bb-48b2-a60b-0c5fe2b38694"), "5435" },
                    { new Guid("f35a4eae-6eee-49e4-95a0-3df60e6ca9b0"), "5434" }
                });

            migrationBuilder.InsertData(
                table: "Tenant",
                columns: new[] { "Id", "connection_string", "initial_url", "is_active", "name", "secret" },
                values: new object[,]
                {
                    { new Guid("25ae8570-56b6-4a9d-9616-c15862613525"), "Host=localhost;Port=5435;Database=Cliente3DB;User ID=usercliente3;Password=pwdcliente3;Pooling=true;", "", true, "Cliente3", "123" },
                    { new Guid("64210b12-a8d4-44ae-b35e-b13b762c4179"), "Host=localhost;Port=5434;Database=Cliente2DB;User ID=usercliente2;Password=pwdcliente2;Pooling=true;", "", true, "Cliente2", "123" },
                    { new Guid("f6a2372a-b146-45f9-be70-a0be13736dd8"), "Host=localhost;Port=5433;Database=Cliente1DB;User ID=usercliente1;Password=pwdcliente1;Pooling=true;", "", true, "Cliente1", "123" }
                });

            migrationBuilder.InsertData(
                table: "Container",
                columns: new[] { "Id", "container_created_at", "container_image", "container_name", "container_network", "container_port", "container_volume", "environment_db_name", "environment_db_pwd", "environment_db_user", "is_up", "PortId", "TenantId" },
                values: new object[,]
                {
                    { new Guid("39715917-a829-41c4-8da1-64029a0c6364"), null, "postgres:16.2", "postgresql_cliente3", "cliente3_network", "5436", "cliente3_volume", "Cliente3DB", "pwdcliente3", "usercliente3", false, new Guid("39715917-a829-41c4-8da1-64029a0c6364"), new Guid("25ae8570-56b6-4a9d-9616-c15862613525") },
                    { new Guid("62afeccd-c9bb-48b2-a60b-0c5fe2b38694"), null, "postgres:16.2", "postgresql_cliente2", "cliente2_network", "5435", "cliente2_volume", "Cliente2DB", "pwdcliente2", "usercliente2", false, new Guid("62afeccd-c9bb-48b2-a60b-0c5fe2b38694"), new Guid("64210b12-a8d4-44ae-b35e-b13b762c4179") },
                    { new Guid("f35a4eae-6eee-49e4-95a0-3df60e6ca9b0"), null, "postgres:16.2", "postgresql_cliente1", "cliente1_network", "5434", "cliente1_volume", "Cliente1DB", "pwdcliente1", "usercliente1", false, new Guid("f35a4eae-6eee-49e4-95a0-3df60e6ca9b0"), new Guid("f6a2372a-b146-45f9-be70-a0be13736dd8") }
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "email", "is_active", "name", "password", "TenantId" },
                values: new object[,]
                {
                    { new Guid("3b005a21-2b05-4659-b549-c1f4e7c95d7e"), "usuario2@teste.com", true, "Usuario2", "123", new Guid("64210b12-a8d4-44ae-b35e-b13b762c4179") },
                    { new Guid("fc78dca0-97d6-475d-ac9e-4f713d0df32e"), "usuario1@teste.com", true, "Usuario1", "123", new Guid("f6a2372a-b146-45f9-be70-a0be13736dd8") },
                    { new Guid("fca2fa8f-ad8e-4c0f-8a34-1a2f44d2cbe6"), "usuario3@teste.com", true, "Usuario3", "123", new Guid("25ae8570-56b6-4a9d-9616-c15862613525") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Container_PortId",
                table: "Container",
                column: "PortId");

            migrationBuilder.CreateIndex(
                name: "IX_Container_TenantId",
                table: "Container",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "Tenant_Name",
                table: "Tenant",
                column: "name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_User_TenantId",
                table: "User",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "user_email",
                table: "User",
                column: "email",
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
                name: "Port");

            migrationBuilder.DropTable(
                name: "Tenant");
        }
    }
}
