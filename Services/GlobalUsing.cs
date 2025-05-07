global using Data.DBContext;
global using Data.Entities;
global using MailKit.Net.Smtp;
global using MailKit.Security;
global using Microsoft.AspNetCore.Authentication.JwtBearer;
global using Microsoft.AspNetCore.Authorization;
global using Microsoft.AspNetCore.Identity;
global using Microsoft.EntityFrameworkCore;
global using Microsoft.Extensions.Caching.Memory;
global using Microsoft.Extensions.Configuration;
global using Microsoft.Extensions.DependencyInjection;
global using Microsoft.Extensions.Options;
global using Microsoft.IdentityModel.Tokens;
global using MimeKit;
global using Serilog;
global using Services.Authentication;
global using Services.Authorization.Handlers;
global using Services.Authorization.Requirments;
global using Services.Decorators.RepositoryDecorators;
global using Services.Decorators.UnitOfWorkDecorators;
global using Services.Email;
global using Services.Enums;
global using Services.GenericRepository;
global using Services.Repositories.Interfaces;
global using Services.UnitOfWork;
global using System.IdentityModel.Tokens.Jwt;
global using System.Security.Claims;
global using System.Text;



