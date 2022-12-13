using System.Reflection;
using Core.Security.JWT;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Validation;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Application.Services.AuthService;
using Application.Auth.Rules;
using Application.Features.AboutUs.Rules;
using Application.Features.Category.Rules;
using Application.Features.Slider.Rules;
using Application.Features.Users.Rules;
using Application.Features.Contact.Rules;
using Application.Features.Product.Rules;
using Application.Features.ProductSlider.Rules;
using Application.Features.Service.Rules;
using Application.Features.SiteIdentity.Rules;
using Application.Features.SubCategory.Rules;
using Application.Features.TablesLog.Rules;
using Application.Services.FileService;

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
            services.AddScoped<ProductBusinessRules>();
            services.AddScoped<ProductSliderBusinessRules>();
            services.AddScoped<ContactBusinessRules>();
            services.AddScoped<CategoryBusinessRules>();
            services.AddScoped<SubCategoryBusinessRules>();
            services.AddScoped<AboutUsBusinessRules>();
            services.AddScoped<SiteIdentityBusinessRules>();
            services.AddScoped<TablesLogBusinessRules>();
            services.AddScoped<ServiceBusinessRules>();

            services.AddTransient<IAuthService, AuthManager>();
            services.AddTransient<IFileService, FileManager>();
            services.AddTransient<ITokenHelper, JwtHelper>();

            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestValidationBehavior<,>));

            return services;
        }
    }
}
