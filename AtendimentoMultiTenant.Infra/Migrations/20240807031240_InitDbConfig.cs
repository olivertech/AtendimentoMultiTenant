using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AtendimentoMultiTenant.Infra.Migrations
{
    /// <inheritdoc />
    public partial class InitDbConfig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Access_Token",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    token = table.Column<string>(type: "text", nullable: false),
                    created_at = table.Column<DateOnly>(type: "date", nullable: true, defaultValue: new DateOnly(2024, 8, 7)),
                    timed_at = table.Column<TimeOnly>(type: "time without time zone", nullable: true, defaultValue: new TimeOnly(0, 12, 39)),
                    expiring_at = table.Column<DateOnly>(type: "date", nullable: true),
                    is_active = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Access_Token", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Feature",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false),
                    description = table.Column<string>(type: "character varying(1500)", maxLength: 1500, nullable: false),
                    is_active = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Feature", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Menu",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false),
                    icone = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    route = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false),
                    description = table.Column<string>(type: "character varying(1500)", maxLength: 1500, nullable: false),
                    is_active = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Menu", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Port",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    port_number = table.Column<string>(type: "character varying(4)", maxLength: 4, nullable: false),
                    is_active = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Port", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Role",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    is_active = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tenant",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false),
                    secret = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    connection_string = table.Column<string>(type: "text", nullable: false),
                    initial_url = table.Column<string>(type: "text", nullable: false),
                    created_at = table.Column<DateOnly>(type: "date", nullable: true),
                    timed_at = table.Column<TimeOnly>(type: "time without time zone", nullable: true),
                    deactivated_at = table.Column<DateOnly>(type: "date", nullable: true),
                    deactivated_timed_at = table.Column<TimeOnly>(type: "time without time zone", nullable: true),
                    is_active = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tenant", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Role_Menu",
                columns: table => new
                {
                    RoleId = table.Column<Guid>(type: "uuid", nullable: false),
                    MenuId = table.Column<Guid>(type: "uuid", nullable: false),
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    is_active = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role_Menu", x => new { x.MenuId, x.RoleId });
                    table.ForeignKey(
                        name: "menu_Id",
                        column: x => x.MenuId,
                        principalTable: "Menu",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "role_Id",
                        column: x => x.RoleId,
                        principalTable: "Role",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Container_Db",
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
                    created_at = table.Column<DateOnly>(type: "date", nullable: true),
                    timed_at = table.Column<TimeOnly>(type: "time without time zone", nullable: true),
                    deactivated_at = table.Column<DateOnly>(type: "date", nullable: true),
                    deactivated_timed_at = table.Column<TimeOnly>(type: "time without time zone", nullable: true),
                    tenant_id = table.Column<Guid>(type: "uuid", nullable: false),
                    port_id = table.Column<Guid>(type: "uuid", nullable: false),
                    is_active = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Container_Db", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Container_Db_Port_port_id",
                        column: x => x.port_id,
                        principalTable: "Port",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Container_Db_Tenant_tenant_id",
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
                    created_at = table.Column<DateOnly>(type: "date", nullable: true),
                    timed_at = table.Column<TimeOnly>(type: "time without time zone", nullable: true),
                    deactivated_at = table.Column<DateOnly>(type: "date", nullable: true),
                    deactivates_timed_at = table.Column<TimeOnly>(type: "time without time zone", nullable: true),
                    tenant_id = table.Column<Guid>(type: "uuid", nullable: false),
                    role_id = table.Column<Guid>(type: "uuid", nullable: true),
                    access_token_id = table.Column<Guid>(type: "uuid", nullable: true),
                    is_active = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                    table.ForeignKey(
                        name: "FK_User_Access_Token_access_token_id",
                        column: x => x.access_token_id,
                        principalTable: "Access_Token",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_User_Role_role_id",
                        column: x => x.role_id,
                        principalTable: "Role",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_User_Tenant_tenant_id",
                        column: x => x.tenant_id,
                        principalTable: "Tenant",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Log_Access",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    user_id = table.Column<Guid>(type: "uuid", nullable: false),
                    created_at = table.Column<DateOnly>(type: "date", nullable: true),
                    timed_at = table.Column<TimeOnly>(type: "time without time zone", nullable: true),
                    is_active = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Log_Access", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Log_Access_User_user_id",
                        column: x => x.user_id,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "User_Feature",
                columns: table => new
                {
                    FeatureId = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    is_active = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User_Feature", x => new { x.UserId, x.FeatureId });
                    table.ForeignKey(
                        name: "feature_id",
                        column: x => x.FeatureId,
                        principalTable: "Feature",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "user_id",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Menu",
                columns: new[] { "Id", "description", "icone", "is_active", "name", "route" },
                values: new object[,]
                {
                    { new Guid("02b786ee-4e14-11ef-9dcf-0242ac1c0002"), "Description", "lists", true, "Menu", "/menus" },
                    { new Guid("af647e7a-3d74-11ef-a3ab-0242ac1c0002"), "Description", "database", true, "Containers", "/containers" },
                    { new Guid("c60de74c-4e13-11ef-9dcf-0242ac1c0002"), "Description", "person", true, "Users", "/users" },
                    { new Guid("cfc81d16-4e13-11ef-9dcf-0242ac1c0002"), "Description", "leak_add", true, "Ports", "/ports" },
                    { new Guid("d8e9b6fc-4e13-11ef-9dcf-0242ac1c0002"), "Description", "category", true, "Features", "/features" },
                    { new Guid("e1b05ce6-4e13-11ef-9dcf-0242ac1c0002"), "Description", "settings_accessibility", true, "Roles", "/roles" },
                    { new Guid("f35a4eae-6eee-49e4-95a0-3df60e6ca9b0"), "Description", "location_away", true, "Tenants", "/tenants" },
                    { new Guid("f3ff2576-4e13-11ef-9dcf-0242ac1c0002"), "Description", "token", true, "User Tokens", "/usertokens" },
                    { new Guid("fc202fe8-4e13-11ef-9dcf-0242ac1c0002"), "Description", "how_to_reg", true, "Logs", "/logs" }
                });

            migrationBuilder.InsertData(
                table: "Port",
                columns: new[] { "Id", "port_number" },
                values: new object[,]
                {
                    { new Guid("39715917-a829-41c4-8da1-64029a0c6364"), "5436" },
                    { new Guid("62afeccd-c9bb-48b2-a60b-0c5fe2b38694"), "5435" },
                    { new Guid("af647e7a-3d74-11ef-a3ab-0242ac1c0002"), "5432" },
                    { new Guid("f35a4eae-6eee-49e4-95a0-3df60e6ca9b0"), "5434" }
                });

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "Description", "name" },
                values: new object[,]
                {
                    { new Guid("45533ff6-3ba5-11ef-9476-0242ac130002"), "Desciption", "Administrador" },
                    { new Guid("6c9b91d0-3ba5-11ef-9476-0242ac130002"), "Desciption", "Operador" },
                    { new Guid("740cf11e-4e2b-11ef-9dcf-0242ac1c0002"), "Desciption", "Cliente" }
                });

            migrationBuilder.InsertData(
                table: "Tenant",
                columns: new[] { "Id", "connection_string", "created_at", "deactivated_timed_at", "deactivated_at", "initial_url", "is_active", "name", "secret", "timed_at" },
                values: new object[,]
                {
                    { new Guid("25ae8570-56b6-4a9d-9616-c15862613525"), "Host=localhost;Port=5435;Database=Cliente3DB;User ID=usercliente3;Password=pwdcliente3;Pooling=true;", null, null, null, "", true, "Tenant 3", "123", null },
                    { new Guid("64210b12-a8d4-44ae-b35e-b13b762c4179"), "Host=localhost;Port=5434;Database=Cliente2DB;User ID=usercliente2;Password=pwdcliente2;Pooling=true;", null, null, null, "", true, "Tenant 2 ", "123", null },
                    { new Guid("9cf0bfd2-3d70-11ef-a3ab-0242ac1c0002"), "Host=localhost;Port=5432;Database=AtendimentoConfigDB;User ID=postgresconfiguser;Password=atendimento@config;Pooling=true;", null, null, null, "", true, "Configuration", "123", null },
                    { new Guid("f6a2372a-b146-45f9-be70-a0be13736dd8"), "Host=localhost;Port=5433;Database=Cliente1DB;User ID=usercliente1;Password=pwdcliente1;Pooling=true;", null, null, null, "", true, "Tenant 1", "123", null }
                });

            migrationBuilder.InsertData(
                table: "Container_Db",
                columns: new[] { "Id", "container_db_image", "container_db_name", "container_db_network", "container_db_port", "container_db_volume", "created_at", "deactivated_timed_at", "deactivated_at", "environment_db_name", "environment_db_pwd", "environment_db_user", "is_up", "port_id", "tenant_id", "timed_at" },
                values: new object[,]
                {
                    { new Guid("2fb70bc4-3d70-11ef-a3ab-0242ac1c0002"), "postgres:16.2", "postgresql_configs", "db_tenant_network", "5432", "db_config_volume", null, null, null, "AtendimentoConfigDB", "atendimento@config", "postgresconfiguser", true, new Guid("af647e7a-3d74-11ef-a3ab-0242ac1c0002"), new Guid("9cf0bfd2-3d70-11ef-a3ab-0242ac1c0002"), null },
                    { new Guid("39715917-a829-41c4-8da1-64029a0c6364"), "postgres:16.2", "postgresql_cliente3", "cliente3_network", "5436", "cliente3_volume", null, null, null, "Cliente3DB", "pwdcliente3", "usercliente3", false, new Guid("39715917-a829-41c4-8da1-64029a0c6364"), new Guid("25ae8570-56b6-4a9d-9616-c15862613525"), null },
                    { new Guid("62afeccd-c9bb-48b2-a60b-0c5fe2b38694"), "postgres:16.2", "postgresql_cliente2", "cliente2_network", "5435", "cliente2_volume", null, null, null, "Cliente2DB", "pwdcliente2", "usercliente2", false, new Guid("62afeccd-c9bb-48b2-a60b-0c5fe2b38694"), new Guid("64210b12-a8d4-44ae-b35e-b13b762c4179"), null },
                    { new Guid("f35a4eae-6eee-49e4-95a0-3df60e6ca9b0"), "postgres:16.2", "postgresql_cliente1", "cliente1_network", "5434", "cliente1_volume", null, null, null, "Cliente1DB", "pwdcliente1", "usercliente1", false, new Guid("f35a4eae-6eee-49e4-95a0-3df60e6ca9b0"), new Guid("f6a2372a-b146-45f9-be70-a0be13736dd8"), null }
                });

            migrationBuilder.InsertData(
                table: "Role_Menu",
                columns: new[] { "MenuId", "RoleId", "Id", "is_active" },
                values: new object[,]
                {
                    { new Guid("02b786ee-4e14-11ef-9dcf-0242ac1c0002"), new Guid("45533ff6-3ba5-11ef-9476-0242ac130002"), new Guid("aea5373e-4e15-11ef-9dcf-0242ac1c0002"), true },
                    { new Guid("af647e7a-3d74-11ef-a3ab-0242ac1c0002"), new Guid("45533ff6-3ba5-11ef-9476-0242ac130002"), new Guid("47ed36c2-4e15-11ef-9dcf-0242ac1c0002"), true },
                    { new Guid("c60de74c-4e13-11ef-9dcf-0242ac1c0002"), new Guid("45533ff6-3ba5-11ef-9476-0242ac130002"), new Guid("73ad14e4-4e15-11ef-9dcf-0242ac1c0002"), true },
                    { new Guid("cfc81d16-4e13-11ef-9dcf-0242ac1c0002"), new Guid("45533ff6-3ba5-11ef-9476-0242ac130002"), new Guid("7add512a-4e15-11ef-9dcf-0242ac1c0002"), true },
                    { new Guid("d8e9b6fc-4e13-11ef-9dcf-0242ac1c0002"), new Guid("45533ff6-3ba5-11ef-9476-0242ac130002"), new Guid("83235528-4e15-11ef-9dcf-0242ac1c0002"), true },
                    { new Guid("e1b05ce6-4e13-11ef-9dcf-0242ac1c0002"), new Guid("45533ff6-3ba5-11ef-9476-0242ac130002"), new Guid("8b104688-4e15-11ef-9dcf-0242ac1c0002"), true },
                    { new Guid("f35a4eae-6eee-49e4-95a0-3df60e6ca9b0"), new Guid("45533ff6-3ba5-11ef-9476-0242ac130002"), new Guid("67a1a5c0-4e15-11ef-9dcf-0242ac1c0002"), true },
                    { new Guid("f3ff2576-4e13-11ef-9dcf-0242ac1c0002"), new Guid("45533ff6-3ba5-11ef-9476-0242ac130002"), new Guid("956dcc4a-4e15-11ef-9dcf-0242ac1c0002"), true },
                    { new Guid("fc202fe8-4e13-11ef-9dcf-0242ac1c0002"), new Guid("45533ff6-3ba5-11ef-9476-0242ac130002"), new Guid("a7dd1c82-4e15-11ef-9dcf-0242ac1c0002"), true }
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "created_at", "deactivates_timed_at", "deactivated_at", "email", "is_active", "name", "password", "role_id", "tenant_id", "timed_at", "access_token_id" },
                values: new object[] { new Guid("9a150059-614b-47c3-b56f-59deededd8d6"), new DateOnly(2024, 8, 7), null, null, "marcelo@sys.com", true, "Marcelo de Oliveira", "123", new Guid("45533ff6-3ba5-11ef-9476-0242ac130002"), new Guid("9cf0bfd2-3d70-11ef-a3ab-0242ac1c0002"), new TimeOnly(0, 12, 39), null });

            migrationBuilder.CreateIndex(
                name: "IX_Container_Db_port_id",
                table: "Container_Db",
                column: "port_id");

            migrationBuilder.CreateIndex(
                name: "IX_Container_Db_tenant_id",
                table: "Container_Db",
                column: "tenant_id");

            migrationBuilder.CreateIndex(
                name: "IX_Log_Access_user_id",
                table: "Log_Access",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_Role_Menu_RoleId",
                table: "Role_Menu",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_User_access_token_id",
                table: "User",
                column: "access_token_id");

            migrationBuilder.CreateIndex(
                name: "IX_User_role_id",
                table: "User",
                column: "role_id");

            migrationBuilder.CreateIndex(
                name: "IX_User_tenant_id",
                table: "User",
                column: "tenant_id");

            migrationBuilder.CreateIndex(
                name: "user_email",
                table: "User",
                column: "email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_User_Feature_FeatureId",
                table: "User_Feature",
                column: "FeatureId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Container_Db");

            migrationBuilder.DropTable(
                name: "Log_Access");

            migrationBuilder.DropTable(
                name: "Role_Menu");

            migrationBuilder.DropTable(
                name: "User_Feature");

            migrationBuilder.DropTable(
                name: "Port");

            migrationBuilder.DropTable(
                name: "Menu");

            migrationBuilder.DropTable(
                name: "Feature");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Access_Token");

            migrationBuilder.DropTable(
                name: "Role");

            migrationBuilder.DropTable(
                name: "Tenant");
        }
    }
}
