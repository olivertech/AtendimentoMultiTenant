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
                name: "UserToken",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    token = table.Column<string>(type: "text", nullable: false),
                    expiration = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserToken", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserType",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ContainerDb",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    container_db_name = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false),
                    container_db_image = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false),
                    environment_db_name = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false),
                    environment_db_user = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    environment_db_pwd = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    container_db_port = table.Column<string>(type: "character varying(4)", maxLength: 4, nullable: false),
                    container_db_volume = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    container_db_network = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    is_up = table.Column<bool>(type: "boolean", nullable: false),
                    container_db_created_at = table.Column<DateOnly>(type: "date", nullable: true),
                    tenant_id = table.Column<Guid>(type: "uuid", nullable: false),
                    port_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContainerDb", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ContainerDb_Port_port_id",
                        column: x => x.port_id,
                        principalTable: "Port",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ContainerDb_Tenant_tenant_id",
                        column: x => x.tenant_id,
                        principalTable: "Tenant",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false),
                    email = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false),
                    password = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    is_active = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true),
                    tenant_id = table.Column<Guid>(type: "uuid", nullable: false),
                    user_type_id = table.Column<Guid>(type: "uuid", nullable: true),
                    user_token_id = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                    table.ForeignKey(
                        name: "FK_User_Tenant_tenant_id",
                        column: x => x.tenant_id,
                        principalTable: "Tenant",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_User_UserToken_user_token_id",
                        column: x => x.user_token_id,
                        principalTable: "UserToken",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_User_UserType_user_type_id",
                        column: x => x.user_type_id,
                        principalTable: "UserType",
                        principalColumn: "Id");
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
                table: "UserType",
                columns: new[] { "Id", "name" },
                values: new object[,]
                {
                    { new Guid("45533ff6-3ba5-11ef-9476-0242ac130002"), "Administrador" },
                    { new Guid("6c9b91d0-3ba5-11ef-9476-0242ac130002"), "Cliente" }
                });

            migrationBuilder.InsertData(
                table: "ContainerDb",
                columns: new[] { "Id", "container_db_created_at", "container_db_image", "container_db_name", "container_db_network", "container_db_port", "container_db_volume", "environment_db_name", "environment_db_pwd", "environment_db_user", "is_up", "port_id", "tenant_id" },
                values: new object[,]
                {
                    { new Guid("39715917-a829-41c4-8da1-64029a0c6364"), null, "postgres:16.2", "postgresql_cliente3", "cliente3_network", "5436", "cliente3_volume", "Cliente3DB", "pwdcliente3", "usercliente3", false, new Guid("39715917-a829-41c4-8da1-64029a0c6364"), new Guid("25ae8570-56b6-4a9d-9616-c15862613525") },
                    { new Guid("62afeccd-c9bb-48b2-a60b-0c5fe2b38694"), null, "postgres:16.2", "postgresql_cliente2", "cliente2_network", "5435", "cliente2_volume", "Cliente2DB", "pwdcliente2", "usercliente2", false, new Guid("62afeccd-c9bb-48b2-a60b-0c5fe2b38694"), new Guid("64210b12-a8d4-44ae-b35e-b13b762c4179") },
                    { new Guid("f35a4eae-6eee-49e4-95a0-3df60e6ca9b0"), null, "postgres:16.2", "postgresql_cliente1", "cliente1_network", "5434", "cliente1_volume", "Cliente1DB", "pwdcliente1", "usercliente1", false, new Guid("f35a4eae-6eee-49e4-95a0-3df60e6ca9b0"), new Guid("f6a2372a-b146-45f9-be70-a0be13736dd8") }
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "email", "is_active", "name", "password", "tenant_id", "user_token_id", "user_type_id" },
                values: new object[,]
                {
                    { new Guid("4214fa3a-91a6-41a7-b2ab-e39be9ef5128"), "cliente1@teste.com", true, "cliente1", "123", new Guid("64210b12-a8d4-44ae-b35e-b13b762c4179"), null, new Guid("6c9b91d0-3ba5-11ef-9476-0242ac130002") },
                    { new Guid("60a52233-dbd8-426d-8724-38dcedaa24d9"), "admin1@teste.com", true, "admin", "123", new Guid("f6a2372a-b146-45f9-be70-a0be13736dd8"), null, new Guid("45533ff6-3ba5-11ef-9476-0242ac130002") },
                    { new Guid("806a18fa-a650-446b-bb9f-4cb495ba0533"), "cliente2@teste.com", true, "cliente2", "123", new Guid("25ae8570-56b6-4a9d-9616-c15862613525"), null, new Guid("6c9b91d0-3ba5-11ef-9476-0242ac130002") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ContainerDb_port_id",
                table: "ContainerDb",
                column: "port_id");

            migrationBuilder.CreateIndex(
                name: "IX_ContainerDb_tenant_id",
                table: "ContainerDb",
                column: "tenant_id");

            migrationBuilder.CreateIndex(
                name: "IX_User_tenant_id",
                table: "User",
                column: "tenant_id");

            migrationBuilder.CreateIndex(
                name: "IX_User_user_token_id",
                table: "User",
                column: "user_token_id");

            migrationBuilder.CreateIndex(
                name: "IX_User_user_type_id",
                table: "User",
                column: "user_type_id");

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
                name: "ContainerDb");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Port");

            migrationBuilder.DropTable(
                name: "Tenant");

            migrationBuilder.DropTable(
                name: "UserToken");

            migrationBuilder.DropTable(
                name: "UserType");
        }
    }
}
