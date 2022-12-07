﻿using System;
using System.Reflection;
using Core.Security.JWT;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Validation;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Application.Services.AuthService;
using Application.Auth.Rules;
using Application.Features.Slider.Rules;
using Application.Features.Users.Rules;
using Application.Services.ImageService;

namespace Application
{
    public static class ApplicationServiceRegistration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddMediatR(Assembly.GetExecutingAssembly());

            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(AuthorizationBehavior<,>));

            services.AddScoped<AuthBusinessRules>();
            services.AddScoped<UserBusinessRules>();
            services.AddScoped<SliderBusinessRules>();

            services.AddTransient<IAuthService, AuthManager>();
            services.AddTransient<IFileService, FileManager>();
            services.AddTransient<ITokenHelper, JwtHelper>();

            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestValidationBehavior<,>));

            return services;
        }
    }
}
