﻿global using Microsoft.AspNetCore.Mvc;
global using AtendimentoMultiTenant.Core.Interfaces;
global using Quartz;
global using System.Diagnostics;
global using Microsoft.Extensions.Options;
global using Microsoft.OpenApi.Models;
global using AtendimentoMultiTenant.Cross.Dependencies;
global using AtendimentoMultiTenant.Api.Jobs;
global using Swashbuckle.AspNetCore.Annotations;
global using AtendimentoMultiTenant.Cross.Requests;
global using AtendimentoMultiTenant.Cross.Responses;
global using AutoMapper;
global using System;
global using AtendimentoMultiTenant.Core.Entities.ConfigurationEntities;
global using AtendimentoMultiTenant.Cross.Interfaces;
global using Microsoft.AspNetCore.Authorization;
global using Microsoft.AspNetCore.Http;
global using AtendimentoMultiTenant.Cross.Auth;
global using Microsoft.AspNetCore.Authentication.JwtBearer;
global using Microsoft.IdentityModel.Tokens;
global using System.Text;
global using NLog;
global using NLog.Web;
