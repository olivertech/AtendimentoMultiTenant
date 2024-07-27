﻿// <auto-generated />
using System;
using AtendimentoMultiTenant.Infra.ManagementArea.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace AtendimentoMultiTenant.Infra.Migrations
{
    [DbContext(typeof(ManagementAreaDbContext))]
    partial class ManagementAreaDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("AtendimentoMultiTenant.Core.ManagementArea.Entities.ContainerDb", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("Id");

                    b.Property<string>("ContainerDbImage")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("character varying(250)")
                        .HasColumnName("container_db_image");

                    b.Property<string>("ContainerDbName")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("character varying(250)")
                        .HasColumnName("container_db_name");

                    b.Property<string>("ContainerDbNetwork")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("container_db_network");

                    b.Property<string>("ContainerDbPort")
                        .IsRequired()
                        .HasMaxLength(4)
                        .HasColumnType("character varying(4)")
                        .HasColumnName("container_db_port");

                    b.Property<string>("ContainerDbVolume")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("container_db_volume");

                    b.Property<DateOnly?>("CreatedAt")
                        .HasColumnType("date")
                        .HasColumnName("container_db_created_at");

                    b.Property<string>("EnvironmentDbName")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("character varying(250)")
                        .HasColumnName("environment_db_name");

                    b.Property<string>("EnvironmentDbPwd")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("environment_db_pwd");

                    b.Property<string>("EnvironmentDbUser")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("environment_db_user");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsUp")
                        .HasColumnType("boolean")
                        .HasColumnName("is_up");

                    b.Property<Guid>("PortId")
                        .HasColumnType("uuid")
                        .HasColumnName("port_id");

                    b.Property<Guid>("TenantId")
                        .HasColumnType("uuid")
                        .HasColumnName("tenant_id");

                    b.HasKey("Id");

                    b.HasIndex("PortId");

                    b.HasIndex("TenantId");

                    b.ToTable("Container_Db", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("2fb70bc4-3d70-11ef-a3ab-0242ac1c0002"),
                            ContainerDbImage = "postgres:16.2",
                            ContainerDbName = "postgresql_configs",
                            ContainerDbNetwork = "db_tenant_network",
                            ContainerDbPort = "5432",
                            ContainerDbVolume = "db_config_volume",
                            CreatedAt = new DateOnly(2024, 7, 27),
                            EnvironmentDbName = "AtendimentoConfigDB",
                            EnvironmentDbPwd = "atendimento@config",
                            EnvironmentDbUser = "postgresconfiguser",
                            IsActive = false,
                            IsUp = true,
                            PortId = new Guid("af647e7a-3d74-11ef-a3ab-0242ac1c0002"),
                            TenantId = new Guid("9cf0bfd2-3d70-11ef-a3ab-0242ac1c0002")
                        },
                        new
                        {
                            Id = new Guid("f35a4eae-6eee-49e4-95a0-3df60e6ca9b0"),
                            ContainerDbImage = "postgres:16.2",
                            ContainerDbName = "postgresql_cliente1",
                            ContainerDbNetwork = "cliente1_network",
                            ContainerDbPort = "5434",
                            ContainerDbVolume = "cliente1_volume",
                            CreatedAt = new DateOnly(2024, 7, 27),
                            EnvironmentDbName = "Cliente1DB",
                            EnvironmentDbPwd = "pwdcliente1",
                            EnvironmentDbUser = "usercliente1",
                            IsActive = false,
                            IsUp = false,
                            PortId = new Guid("f35a4eae-6eee-49e4-95a0-3df60e6ca9b0"),
                            TenantId = new Guid("f6a2372a-b146-45f9-be70-a0be13736dd8")
                        },
                        new
                        {
                            Id = new Guid("62afeccd-c9bb-48b2-a60b-0c5fe2b38694"),
                            ContainerDbImage = "postgres:16.2",
                            ContainerDbName = "postgresql_cliente2",
                            ContainerDbNetwork = "cliente2_network",
                            ContainerDbPort = "5435",
                            ContainerDbVolume = "cliente2_volume",
                            CreatedAt = new DateOnly(2024, 7, 27),
                            EnvironmentDbName = "Cliente2DB",
                            EnvironmentDbPwd = "pwdcliente2",
                            EnvironmentDbUser = "usercliente2",
                            IsActive = false,
                            IsUp = false,
                            PortId = new Guid("62afeccd-c9bb-48b2-a60b-0c5fe2b38694"),
                            TenantId = new Guid("64210b12-a8d4-44ae-b35e-b13b762c4179")
                        },
                        new
                        {
                            Id = new Guid("39715917-a829-41c4-8da1-64029a0c6364"),
                            ContainerDbImage = "postgres:16.2",
                            ContainerDbName = "postgresql_cliente3",
                            ContainerDbNetwork = "cliente3_network",
                            ContainerDbPort = "5436",
                            ContainerDbVolume = "cliente3_volume",
                            CreatedAt = new DateOnly(2024, 7, 27),
                            EnvironmentDbName = "Cliente3DB",
                            EnvironmentDbPwd = "pwdcliente3",
                            EnvironmentDbUser = "usercliente3",
                            IsActive = false,
                            IsUp = false,
                            PortId = new Guid("39715917-a829-41c4-8da1-64029a0c6364"),
                            TenantId = new Guid("25ae8570-56b6-4a9d-9616-c15862613525")
                        });
                });

            modelBuilder.Entity("AtendimentoMultiTenant.Core.ManagementArea.Entities.Feature", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("Id");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.HasKey("Id");

                    b.ToTable("Feature", (string)null);
                });

            modelBuilder.Entity("AtendimentoMultiTenant.Core.ManagementArea.Entities.LogAccess", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("Id");

                    b.Property<DateOnly?>("CreatedAt")
                        .IsRequired()
                        .HasColumnType("date")
                        .HasColumnName("access_datetime");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid")
                        .HasColumnName("user_id");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Log_Access", (string)null);
                });

            modelBuilder.Entity("AtendimentoMultiTenant.Core.ManagementArea.Entities.Port", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("Id");

                    b.Property<string>("PortNumber")
                        .IsRequired()
                        .HasMaxLength(4)
                        .HasColumnType("character varying(4)")
                        .HasColumnName("port_number");

                    b.HasKey("Id");

                    b.ToTable("Port", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("af647e7a-3d74-11ef-a3ab-0242ac1c0002"),
                            PortNumber = "5432"
                        },
                        new
                        {
                            Id = new Guid("f35a4eae-6eee-49e4-95a0-3df60e6ca9b0"),
                            PortNumber = "5434"
                        },
                        new
                        {
                            Id = new Guid("62afeccd-c9bb-48b2-a60b-0c5fe2b38694"),
                            PortNumber = "5435"
                        },
                        new
                        {
                            Id = new Guid("39715917-a829-41c4-8da1-64029a0c6364"),
                            PortNumber = "5436"
                        });
                });

            modelBuilder.Entity("AtendimentoMultiTenant.Core.ManagementArea.Entities.Tenant", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("Id");

                    b.Property<string>("ConnectionString")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("connection_string");

                    b.Property<DateOnly?>("CreatedAt")
                        .HasColumnType("date");

                    b.Property<string>("InitialUrl")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("initial_url");

                    b.Property<bool>("IsActive")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("boolean")
                        .HasDefaultValue(true)
                        .HasColumnName("is_active");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("name");

                    b.Property<string>("Secret")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("character varying(20)")
                        .HasColumnName("secret");

                    b.HasKey("Id");

                    b.ToTable("Tenant", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("9cf0bfd2-3d70-11ef-a3ab-0242ac1c0002"),
                            ConnectionString = "Host=localhost;Port=5432;Database=AtendimentoConfigDB;User ID=postgresconfiguser;Password=atendimento@config;Pooling=true;",
                            InitialUrl = "",
                            IsActive = true,
                            Name = "Configuration",
                            Secret = "123"
                        },
                        new
                        {
                            Id = new Guid("f6a2372a-b146-45f9-be70-a0be13736dd8"),
                            ConnectionString = "Host=localhost;Port=5433;Database=Cliente1DB;User ID=usercliente1;Password=pwdcliente1;Pooling=true;",
                            InitialUrl = "",
                            IsActive = true,
                            Name = "Tenant 1",
                            Secret = "123"
                        },
                        new
                        {
                            Id = new Guid("64210b12-a8d4-44ae-b35e-b13b762c4179"),
                            ConnectionString = "Host=localhost;Port=5434;Database=Cliente2DB;User ID=usercliente2;Password=pwdcliente2;Pooling=true;",
                            InitialUrl = "",
                            IsActive = true,
                            Name = "Tenant 2 ",
                            Secret = "123"
                        },
                        new
                        {
                            Id = new Guid("25ae8570-56b6-4a9d-9616-c15862613525"),
                            ConnectionString = "Host=localhost;Port=5435;Database=Cliente3DB;User ID=usercliente3;Password=pwdcliente3;Pooling=true;",
                            InitialUrl = "",
                            IsActive = true,
                            Name = "Tenant 3",
                            Secret = "123"
                        });
                });

            modelBuilder.Entity("AtendimentoMultiTenant.Core.ManagementArea.Entities.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("Id");

                    b.Property<DateOnly?>("CreatedAt")
                        .HasColumnType("date");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("character varying(250)")
                        .HasColumnName("email");

                    b.Property<bool>("IsActive")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("boolean")
                        .HasDefaultValue(true)
                        .HasColumnName("is_active");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("character varying(250)")
                        .HasColumnName("name");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("password");

                    b.Property<Guid>("TenantId")
                        .HasColumnType("uuid")
                        .HasColumnName("tenant_id");

                    b.Property<Guid?>("UserTokenId")
                        .HasColumnType("uuid")
                        .HasColumnName("user_token_id");

                    b.Property<Guid?>("UserTypeId")
                        .HasColumnType("uuid")
                        .HasColumnName("user_type_id");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique()
                        .HasDatabaseName("user_email");

                    b.HasIndex("TenantId");

                    b.HasIndex("UserTokenId");

                    b.HasIndex("UserTypeId");

                    b.ToTable("User", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("91b35c63-49d0-44ce-9eec-6f95a48d52d2"),
                            Email = "marcelo@sys.com",
                            IsActive = true,
                            Name = "Marcelo de Oliveira",
                            Password = "123",
                            TenantId = new Guid("9cf0bfd2-3d70-11ef-a3ab-0242ac1c0002"),
                            UserTypeId = new Guid("45533ff6-3ba5-11ef-9476-0242ac130002")
                        },
                        new
                        {
                            Id = new Guid("9802e62a-899b-4b55-87e6-cb56038010f6"),
                            Email = "joao@sys.com",
                            IsActive = true,
                            Name = "João da Silva",
                            Password = "123",
                            TenantId = new Guid("9cf0bfd2-3d70-11ef-a3ab-0242ac1c0002"),
                            UserTypeId = new Guid("45533ff6-3ba5-11ef-9476-0242ac130002")
                        },
                        new
                        {
                            Id = new Guid("c3013462-1855-4fda-a20b-21a44b6cfc74"),
                            Email = "maria@sys.com",
                            IsActive = true,
                            Name = "maria da Silva",
                            Password = "123",
                            TenantId = new Guid("9cf0bfd2-3d70-11ef-a3ab-0242ac1c0002"),
                            UserTypeId = new Guid("45533ff6-3ba5-11ef-9476-0242ac130002")
                        },
                        new
                        {
                            Id = new Guid("8454e2ce-bcce-4c9d-b0b4-c65f4eb65d37"),
                            Email = "paulo@tenant1.com",
                            IsActive = true,
                            Name = "Paulo da Silva",
                            Password = "123",
                            TenantId = new Guid("64210b12-a8d4-44ae-b35e-b13b762c4179"),
                            UserTypeId = new Guid("6c9b91d0-3ba5-11ef-9476-0242ac130002")
                        },
                        new
                        {
                            Id = new Guid("ecf810fb-c01d-4fe8-8e87-d39e1f262143"),
                            Email = "jorge@tenant2.com",
                            IsActive = true,
                            Name = "Jorge da Silva",
                            Password = "123",
                            TenantId = new Guid("25ae8570-56b6-4a9d-9616-c15862613525"),
                            UserTypeId = new Guid("6c9b91d0-3ba5-11ef-9476-0242ac130002")
                        });
                });

            modelBuilder.Entity("AtendimentoMultiTenant.Core.ManagementArea.Entities.UserFeature", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("FeatureId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("Id")
                        .HasColumnType("uuid");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean")
                        .HasColumnName("is_active");

                    b.HasKey("UserId", "FeatureId");

                    b.HasIndex("FeatureId");

                    b.ToTable("User_Feature", (string)null);
                });

            modelBuilder.Entity("AtendimentoMultiTenant.Core.ManagementArea.Entities.UserToken", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("Id");

                    b.Property<DateTime?>("CreatedAt")
                        .IsRequired()
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("creation_date");

                    b.Property<DateTime?>("ExpiringAt")
                        .IsRequired()
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("expiration_date");

                    b.Property<string>("Token")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("token");

                    b.HasKey("Id");

                    b.ToTable("User_Token", (string)null);
                });

            modelBuilder.Entity("AtendimentoMultiTenant.Core.ManagementArea.Entities.UserType", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("Id");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("name");

                    b.HasKey("Id");

                    b.ToTable("User_Type", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("45533ff6-3ba5-11ef-9476-0242ac130002"),
                            Name = "Administrador"
                        },
                        new
                        {
                            Id = new Guid("6c9b91d0-3ba5-11ef-9476-0242ac130002"),
                            Name = "Cliente"
                        });
                });

            modelBuilder.Entity("AtendimentoMultiTenant.Core.ManagementArea.Entities.ContainerDb", b =>
                {
                    b.HasOne("AtendimentoMultiTenant.Core.ManagementArea.Entities.Port", "Port")
                        .WithMany()
                        .HasForeignKey("PortId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AtendimentoMultiTenant.Core.ManagementArea.Entities.Tenant", "Tenant")
                        .WithMany()
                        .HasForeignKey("TenantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Port");

                    b.Navigation("Tenant");
                });

            modelBuilder.Entity("AtendimentoMultiTenant.Core.ManagementArea.Entities.LogAccess", b =>
                {
                    b.HasOne("AtendimentoMultiTenant.Core.ManagementArea.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("AtendimentoMultiTenant.Core.ManagementArea.Entities.User", b =>
                {
                    b.HasOne("AtendimentoMultiTenant.Core.ManagementArea.Entities.Tenant", "Tenant")
                        .WithMany()
                        .HasForeignKey("TenantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AtendimentoMultiTenant.Core.ManagementArea.Entities.UserToken", "UserToken")
                        .WithMany()
                        .HasForeignKey("UserTokenId");

                    b.HasOne("AtendimentoMultiTenant.Core.ManagementArea.Entities.UserType", "UserType")
                        .WithMany()
                        .HasForeignKey("UserTypeId");

                    b.Navigation("Tenant");

                    b.Navigation("UserToken");

                    b.Navigation("UserType");
                });

            modelBuilder.Entity("AtendimentoMultiTenant.Core.ManagementArea.Entities.UserFeature", b =>
                {
                    b.HasOne("AtendimentoMultiTenant.Core.ManagementArea.Entities.Feature", "Feature")
                        .WithMany("UserFeatures")
                        .HasForeignKey("FeatureId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("feature_id");

                    b.HasOne("AtendimentoMultiTenant.Core.ManagementArea.Entities.User", "User")
                        .WithMany("UserFeatures")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("user_id");

                    b.Navigation("Feature");

                    b.Navigation("User");
                });

            modelBuilder.Entity("AtendimentoMultiTenant.Core.ManagementArea.Entities.Feature", b =>
                {
                    b.Navigation("UserFeatures");
                });

            modelBuilder.Entity("AtendimentoMultiTenant.Core.ManagementArea.Entities.User", b =>
                {
                    b.Navigation("UserFeatures");
                });
#pragma warning restore 612, 618
        }
    }
}
