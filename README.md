# AtendimentoMultiTenant

Sistema Mult-Tenant de Atendimento/Controle de chamados ou ordens de serviços/tickets de suporte.

Sistema está sendo desenvolvido para ser um SaaS, um produto que poderá ser contratado futuramente por clientes, de forma automática na web.

O projeto procura estar antenado com boas práticas e arquitetura de sistemas que permitam uma rápida manutenção, com separação clara de camadas e responsabilidades, aplicando padrões de desenvolvimento de sistemas.

Na parte de tecnologias, temos até o momento as seguintes stacks:

FRONTEND
- Blazor WebAssembly (Wasm)
- MudBlazor
- Session Storage
- Refit

BACKEND
- Aspnet core (.Net 8) com C#
- Entity Framework core
- Automapper
- Fluent Validation
- JWT Authentication

BANCO DE DADOS
- PostgreSql rodando em containers, com isolamento a nível de banco de dados
- Migrations com Code-First

INFRA
- Swagger
- Docker
- Quartz.net
- NLog
