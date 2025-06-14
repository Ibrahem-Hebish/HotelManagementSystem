global using Core.GenericRespons;
global using Core.Mediator.MediatorNotification;
global using Core.Mediator.MediatorPipelines.Commands;
global using Core.Mediator.MediatorPipelines.Query;
global using Core.Validation;
global using Data.Entities;
global using FluentValidation;
global using Mapster;
global using MapsterMapper;
global using MediatR;
global using MediatR.NotificationPublishers;
global using Microsoft.AspNetCore.Http;
global using Microsoft.AspNetCore.Identity;
global using Microsoft.EntityFrameworkCore;
global using Microsoft.Extensions.Caching.Memory;
global using Microsoft.Extensions.DependencyInjection;
global using Serilog;
global using Services.Authentication;
global using Services.Email;
global using Services.Enums;
global using Services.GenericRepository;
global using Services.Repositories.Interfaces;
global using Services.UnitOfWork;
global using System.Net;


