# AtendimentoMultiTenant

Sistema Mult-Tenant de Atendimento/Controle de chamados ou ordens de serviços ou tickets de suporte.

Sistema está sendo desenvolvido para ser um SaaS, um produto que poderá ser contratado futuramente por clientes, de forma automática na web.

O projeto procura estar antenado com boas práticas e arquitetura de sistemas que permitam uma rápida manutenção, com separação clara de camadas e responsabilidades, aplicando padrões de desenvolvimento de sistemas.

Na parte de tecnologias, temos até o momento as seguintes stacks:

FRONTEND

BACKEND
- Aspnet core (.Net 8) com C#
- Entity Framework core
- Automapper

BANCO DE DADOS
- PostgreSql rodando em containers, com isolamento a nível de banco de dados

INFRA
- Swagger
- Docker
- Quartz.net
